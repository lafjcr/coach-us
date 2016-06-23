using CoachUs.Common.Data.Infrastructure;
using CoachUs.Common.Data.Repositories;
using CoachUs.Common.Data.Services;
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

                var entity = model.ToEntity();
                entity.CreatedDate = DateTime.UtcNow;

                using (var transaction = BeginTransaction())
                {
                    try
                    {
                        entity = MainRepository.Insert(entity);
                        Commit();
                        MainRepository.LoadReference(entity, e => e.Owner);
                        MainRepository.LoadCollection(entity, e => e.LicensePaymentOrders);

                        var paymentOrder = CreateLicensePaymentOrder(entity.Id, model.LicensePackagePriceId, model.Users);
                        entity.LicensePaymentOrders.Add(paymentOrder);
                        Commit();

                        var result = entity.ToCreateModel();
                        result.PaymentOrder = paymentOrder.ToModel();

                        transaction.Commit();

                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }                
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


        EntityBaseRepository<LicensePaymentOrder> LicensePaymentOrderRepository
        {
            get
            {
                return Repository<LicensePaymentOrder>();
            }
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

                paymentOrder = model.ToEntity(paymentOrder);
                paymentOrder.ModifiedDate = paymentOrder.PaidDate = DateTime.UtcNow;
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

                paymentOrder.PaymentConfirmed = true;
                paymentOrder.ModifiedDate = DateTime.UtcNow;
                LicensePaymentOrderRepository.Update(paymentOrder);
                Commit();
            }
            else throw new UnauthorizedAccessException();
        }


        EntityBaseRepository<LicensePackagePrice> LicensePackagePriceRepository
        {
            get
            {
                return Repository<LicensePackagePrice>();
            }
        }

        private LicensePaymentOrder CreateLicensePaymentOrder(int licenseId, int licensePackagePriceId, int users)
        {
            var licensePackagePrice = LicensePackagePriceRepository.GetById(licensePackagePriceId);
            if (licensePackagePrice == null)
                throw new ArgumentException("Invalid License Package Price Id");

            var dateNow = DateTime.UtcNow;
            var result = new LicensePaymentOrder()
            {
                LicenseId = licenseId,
                LicensePackagePrice = licensePackagePrice,
                Qty = users / licensePackagePrice.LicensePackage.Users,
                Users = users,
                UnitAmount = licensePackagePrice.Price,
                TotalAmount = users / licensePackagePrice.LicensePackage.Users * licensePackagePrice.Price,
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
    }
}
