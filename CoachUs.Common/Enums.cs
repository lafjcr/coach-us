namespace CoachUs.Common.Enums
{
    public enum Gender
    {
        Female = 'F',
        Male = 'M'
    }

    public enum Laterality
    {
        Right = 'R',
        Left = 'L'
    }

    public enum PaymentOrderType
    {
        New = 'N',
        Renew = 'R',
        Upgrade = 'U',
        UpgradeRenew = 'Y'
    }

    public enum PaymentType
    {
        None = 'N',
        Cash = 'C',
        Deposit = 'D',
        Paypal = 'P',
        Card = 'K'
    }
}
