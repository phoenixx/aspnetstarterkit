namespace Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums
{
    public enum SurchargeModelType
    {
        Unknown = 0,
        Fuel = 1,
        SpecificDayDelivery = 2,
        SpecificDayCollection = 3,
        NothingToCollect = 4,
        OutOfArea = 5,
        OutOfGaugeLength = 6,
        OutOfGaugeWeight = 7,
        OutOfGaugeVolume = 8,
        OutOfGaugeSecondDimension = 9,
        OutOfGaugeThirdDimension = 10,
        OutOfGaugeMaxDimensions = 11,
        OutOfGaugeGirth = 12,
        OutOfGaugeCombinedDimensions = 13,
        ConsignmentValue = 14,
        ResidentialSurcharge = 15,
        FixedAdditionalCharge = 16,
        Other = 99
    }
}