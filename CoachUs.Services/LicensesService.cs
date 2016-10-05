using CoachUs.Common;
using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Common.Data.Services;
using CoachUs.Common.Enums;
using CoachUs.Data.Entities;
using CoachUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace CoachUs.Services
{
    class LicensesService : BaseService<License>, ILicenseService
    {
        readonly CallerUserInfo callerUserInfo;

        public LicensesService(CallerUserInfo callerUserInfo, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.callerUserInfo = callerUserInfo;
            AddRepository<LicensePaymentOrder>();
            AddRepository<LicensePackagePrice>();
        }

        public IEnumerable<LicenseResponseModel> GetLicenses()
        {
            ICollection<LicenseResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.Get().ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public IEnumerable<LicenseGroupedResponseModel> GetGroupedLicenses()
        {
            ICollection<LicenseGroupedResponseModel> result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.Get().GroupBy(i => i.Owner).ToList().ToModelList();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicenseResponseModel GetLicense(int id)
        {
            LicenseResponseModel result = null;
            if (callerUserInfo.IsAdmin)
            {
                result = MainRepository.GetById(id).ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }

        public LicenseCreatedResponseModel AddLicense(LicenseCreateRequestModel model, IUsersService userService)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var user = userService.GetUserDetails(model.OwnerId);
                if (user == null)
                    throw new ArgumentException("Invalid Owner Id");

                var licensePackagePrice = LicensePackagePriceRepository.GetById(model.LicensePackagePriceId);
                if (licensePackagePrice == null)
                    throw new ArgumentException("Invalid License Package Price Id");

                var entity = model.ToEntity();
                entity.CreatedDate = DateTime.UtcNow;

                Action extraActions = () =>
                {
                    entity = MainRepository.Insert(entity);
                    Commit();
                    MainRepository.LoadReference(entity, e => e.Owner);
                    MainRepository.LoadCollection(entity, e => e.LicensePaymentOrders);
                    MainRepository.LoadCollection(entity, e => e.LicenseHistories);
                };

                var paymentOrder = CreatePaymentOrderAndHistory(entity, licensePackagePrice, model.Users, PaymentOrderType.New, null, null, 0, 0, extraActions);

                var result = entity.ToCreateModel();
                result.PaymentOrder = paymentOrder.ToModel();
                return result;
            }
            throw new UnauthorizedAccessException();
        }
        
        public void UpdateLicense(LicenseUpdateRequestModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = MainRepository.GetById(model.Id);
                if (entity == null)
                    throw new ObjectNotFoundException();

                entity = model.ToEntity(entity);
                MainRepository.Update(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }

        public void DeleteLicense(int id)
        {
            if (callerUserInfo.IsAdmin)
            {
                var entity = MainRepository.GetById(id);
                if (entity == null)
                    throw new ObjectNotFoundException();
                MainRepository.Delete(entity);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }
                        
        public void PayLicense(int licensedId, LicensePaymentOrderPayModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                var entity = MainRepository.GetById(licensedId);
                if (entity == null)
                    throw new ObjectNotFoundException();

                var paymentOrder = entity.LicensePaymentOrders.SingleOrDefault(i => i.Id == model.Id);
                if (paymentOrder == null)
                    throw new ObjectNotFoundException();

                if (paymentOrder.PaidDate != null)
                    throw new InvalidOperationException("The Payment Order is already paid.");

                paymentOrder = model.ToEntity(paymentOrder);
                var dateNow = DateTime.UtcNow;
                paymentOrder.ModifiedDate = dateNow;
                paymentOrder.PaidDate = dateNow;
                LicensePaymentOrderRepository.Update(paymentOrder);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }

        public void ConfirmPayment(int licensedId, int paymentId)
        {
            if (callerUserInfo.IsAdmin)
            {
                var entity = MainRepository.GetById(licensedId);
                if (entity == null)
                    throw new ObjectNotFoundException();

                var paymentOrder = entity.LicensePaymentOrders.SingleOrDefault(i => i.Id == paymentId);
                if (paymentOrder == null)
                    throw new ObjectNotFoundException();

                if (paymentOrder.PaymentConfirmed)
                    throw new InvalidOperationException("The Payment Order is already confirmed.");

                paymentOrder.PaymentConfirmed = true;
                paymentOrder.ModifiedDate = DateTime.UtcNow;
                LicensePaymentOrderRepository.Update(paymentOrder);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }

        public void Renew(int licensedId)
        {
            Renew(licensedId, 0, 0);
        }

        private void Renew(int licensedId, int licensePackagePriceId, int users, bool upgrade = false)
        {
            if (callerUserInfo.IsAdmin)
            {
                var entity = MainRepository.GetById(licensedId);
                if (entity == null)
                    throw new ObjectNotFoundException();

                var licenseHistory = GetLatestHistory(entity);
                if (licenseHistory == null)
                    throw new ObjectNotFoundException();

                if (licenseHistory.LicensePackagePriceId == licensePackagePriceId)
                    throw new InvalidOperationException("The license package price must be different than current one.");

                var paymentOrderType = PaymentOrderType.Renew;
                var pendingDays = 0;
                var upgradeCredit = 0m;
                var dateNow = DateTime.UtcNow;
                var startDate = licenseHistory.ExpirationDate > dateNow ? licenseHistory.ExpirationDate.AddDays(1) : dateNow;

                if (licenseHistory.StartDate > DateTime.UtcNow)
                {
                    //if (!upgrade)
                        throw new InvalidOperationException("The license is already renewed.");

                    //paymentOrderType = PaymentOrderType.UpgradeRenew;
                    //upgradeCredit = CalculateCredit(licenseHistory, licenseHistory.StartDate, out pendingDays);
                    //startDate = licenseHistory.StartDate;
                }

                licensePackagePriceId = licensePackagePriceId > 0 ? licensePackagePriceId : licenseHistory.LicensePackagePrice.LicensePackageId;
                var licensePackagePrice = LicensePackagePriceRepository.GetById(licensePackagePriceId);
                if (licensePackagePrice == null)
                    throw new ArgumentException("Invalid License Package Price Id");

                if (licensePackagePrice.LicensePackage.Name == "CUTRIAL")
                {
                    licensePackagePriceId++;
                    licensePackagePrice = LicensePackagePriceRepository.GetById(licensePackagePriceId);
                }

                users = users > 0 ? users : licenseHistory.MaxUsers;

                //TODO: Validate Users vs current License Users

                CreatePaymentOrderAndHistory(entity, licensePackagePrice, users, paymentOrderType, startDate, null, 0, upgradeCredit);
            }
            else throw new UnauthorizedAccessException();
        }

        public void ChangeLicense(LicenseChangeRequestModel model)
        {
            if (callerUserInfo.IsAdmin)
            {
                if (model.Now)
                {
                    var entity = MainRepository.GetById(model.Id);
                    if (entity == null)
                        throw new ObjectNotFoundException();
                    
                    var licenseHistory = GetLatestHistory(entity);
                    if (licenseHistory == null)
                        throw new ObjectNotFoundException();

                    var licensePackagePrice = LicensePackagePriceRepository.GetById(model.LicensePackagePriceId);
                    if (licensePackagePrice == null)
                        throw new ArgumentException("Invalid License Package Price Id");

                    var upgradeUsers = model.Users > licenseHistory.MaxUsers;
                    var upgradeMonths = licensePackagePrice.Months > licenseHistory.LicensePackagePrice.Months;
                    
                    if (upgradeUsers || upgradeMonths)
                    {
                        var dateNow = DateTime.UtcNow;
                        var upgradeCredit = 0m;
                        var currentPendingDays = 0;

                        // Already renewed
                        if (licenseHistory.StartDate > dateNow)
                        {
                            // Current period credit
                            var currentLicenseHistory = GetCurrentHistory(entity);
                            if (currentLicenseHistory.LicensePaymentOrder.PaymentConfirmed)
                                upgradeCredit = CalculateCredit(currentLicenseHistory, dateNow, out currentPendingDays);
                        }
                        var pendingStartDate = licenseHistory.StartDate > dateNow ? licenseHistory.StartDate.AddDays(1) : dateNow;
                        var pendingDays = 0;
                        
                        if (licenseHistory.LicensePaymentOrder.PaymentConfirmed)
                            upgradeCredit += CalculateCredit(licenseHistory, pendingStartDate, out pendingDays);

                        pendingDays += currentPendingDays;

                        DateTime? expirationDate = null;
                        expirationDate = !upgradeMonths ? licenseHistory.ExpirationDate : expirationDate;
                        CreatePaymentOrderAndHistory(entity, licensePackagePrice, model.Users, PaymentOrderType.Upgrade, dateNow, expirationDate, pendingDays, upgradeCredit);
                    }
                    else
                    {
                        // Finish current paid period and renew with new selected package price
                        Renew(model.Id, model.LicensePackagePriceId, model.Users, true);
                    }
                }
                else
                {
                    // Finish current paid period and renew with new selected package price
                    Renew(model.Id, model.LicensePackagePriceId, model.Users, true);
                }                
            }
            else throw new UnauthorizedAccessException();
        }

        private decimal CalculateCredit(LicenseHistory currentLicenseHistory, DateTime startDate, out int currentPendingDays)
        {
            currentPendingDays = (currentLicenseHistory.ExpirationDate - startDate).Days;
            var currentPendingDaysPackageQty = CalculatePackagesQty(currentLicenseHistory.MaxUsers, currentLicenseHistory.LicensePackagePrice.LicensePackage.Users);
            var upgradeCredit = CalculatePackageTotalAmount(CalculatePackageUnitAmount(currentLicenseHistory.LicensePackagePrice.Price, currentPendingDays), currentPendingDaysPackageQty);
            return upgradeCredit;
        }

        private LicensePaymentOrder CreatePaymentOrderAndHistory(License license, LicensePackagePrice licensePackagePrice, int users, PaymentOrderType paymentOrderType, DateTime? startDate = null, DateTime? expirationDate = null, int pendingDays = 0, decimal upgradeCredit = 0, Action beginAction = null, Action finishAction = null)
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    if (beginAction != null)
                        beginAction();

                    var paymentOrder = CreateLicensePaymentOrder(license.Id, paymentOrderType, licensePackagePrice, users, pendingDays, upgradeCredit);
                    license.LicensePaymentOrders.Add(paymentOrder);
                    Commit();

                    var newLicenseHistory = CreateLicenseHistory(license.Id, licensePackagePrice, users, startDate, expirationDate);
                    newLicenseHistory.LicensePaymentOrder = paymentOrder;
                    license.LicenseHistories.Add(newLicenseHistory);
                    Commit();

                    if (finishAction != null)
                        finishAction();

                    transaction.Commit();

                    return paymentOrder;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        EntityBaseRepository<LicensePackagePrice> LicensePackagePriceRepository
        {
            get
            {
                return Repository<LicensePackagePrice>();
            }
        }

        EntityBaseRepository<LicensePaymentOrder> LicensePaymentOrderRepository
        {
            get
            {
                return Repository<LicensePaymentOrder>();
            }
        }

        private LicensePaymentOrder CreateLicensePaymentOrder(int licenseId, PaymentOrderType paymentOrderType, LicensePackagePrice licensePackagePrice, int users, int days = 0, decimal upgradeCredit = 0)
        {
            if (!ValidUsers(users, licensePackagePrice.LicensePackage))
                throw new ArgumentException("Invalid License Users");

            var dateNow = DateTime.UtcNow;
            days = days > 0 ? days : licensePackagePrice.Months * Constants.MonthDays;
            var unitAmount = CalculatePackageUnitAmount(licensePackagePrice.Price, days);
            var qty = CalculatePackagesQty(users, licensePackagePrice.LicensePackage.Users);
            var result = new LicensePaymentOrder()
            {
                LicenseId = licenseId,
                LicensePackagePrice = licensePackagePrice,
                PaymentOrderTypeValue = paymentOrderType,
                Qty = qty,
                Users = users,
                UnitAmount = unitAmount,
                UpgradeCredit = upgradeCredit,
                CreatedDate = dateNow,
                ModifiedDate = dateNow
            };
            if (result.TotalAmount == 0)
            {
                result.PaidDate = dateNow;
                result.PaymentTypeValue = Common.Enums.PaymentType.None;
                result.PaymentConfirmed = true;
            }
            return result;
        }

        private bool ValidUsers(int users, LicensePackage licensePackage)
        {
            if (users % licensePackage.Users == 0
                    && users > licensePackage.MinUsers
                    && users <= licensePackage.MaxUsers)
                return true;
            return false;
        }

        private int CalculatePackagesQty(int users, int packageUsers)
        {
            return users / packageUsers;
        }

        private decimal CalculatePackageUnitAmount(decimal price, int days = Constants.MonthDays)
        {
            var result = price / Constants.MonthDays * days;
            return result;
        }

        private decimal CalculatePackageTotalAmount(decimal amount, int quantity, decimal upgradeCredit = 0)
        {
            var result = (amount * quantity) - upgradeCredit;
            return result;
        }

        private LicenseHistory CreateLicenseHistory(int licenseId, LicensePackagePrice licensePackagePrice, int users, DateTime? startDate = null, DateTime? expirationDate = null)
        {
            var dateNow = DateTime.UtcNow;

            if (!startDate.HasValue)
                startDate = dateNow;

            if (!expirationDate.HasValue)
                expirationDate = startDate.Value.AddMonths(licensePackagePrice.Months).AddDays(-1);

            var result = new LicenseHistory()
            {
                LicenseId = licenseId,
                LicensePackagePrice = licensePackagePrice,
                MaxUsers = users,
                StartDate = startDate.Value,
                ExpirationDate = expirationDate.Value,
                CreatedDate = dateNow,
                ModifiedDate = dateNow
            };

            return result;
        }

        private LicenseHistory GetCurrentHistory(License license)
        {
            var dateNow = DateTime.UtcNow;
            return license.LicenseHistories.Where(i => i.StartDate < dateNow && dateNow < i.ExpirationDate).OrderByDescending(i => i.Id).FirstOrDefault();
        }

        private LicenseHistory GetLatestHistory(License license)
        {
            return license.LicenseHistories.OrderByDescending(i => i.Id).FirstOrDefault();
        }
    }
}
