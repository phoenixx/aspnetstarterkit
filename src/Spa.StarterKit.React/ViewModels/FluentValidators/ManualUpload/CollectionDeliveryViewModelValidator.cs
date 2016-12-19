using System;
using FluentValidation;
using Spa.StarterKit.React.Config;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class CollectionDeliveryViewModelValidator : AbstractValidator<CreateConsignmentViewModel>
    {
        public CollectionDeliveryViewModelValidator()
        {
            RuleFor(x => x.Packages)
                    .SetCollectionValidator(new PackageViewModelValidator());

                RuleFor(x => x.Consignment)
                .SetValidator(new ConsignmentValidator());

            var maxUploadPackages = "10";
#warning removed config setting for maxupload packages

            //ConfigurationManager.AppSettings[Constants.AppSettingKeys.ManualUploadMaxPackages];

            var maxPackages = 0;
            if (!Int32.TryParse(maxUploadPackages, out maxPackages))
            {
                throw new Exception("Unable to parse ManualUploadMaxPackages appSetting value to int32");
            }

            RuleFor(x => x.NumberOfPackages)
                .GreaterThan(0)
                .LessThanOrEqualTo(maxPackages);

            RuleFor(x => x.ServiceGroup)
                .NotEmpty()
                .When(x => x.QueueOption == QueueOption.SpecifyCarrierGroup && IsCollectionService(x))
                .WithMessage("Please choose a carrier service group or choose all services");

            RuleFor(x => x.SelectedShippingDate)
                .NotEmpty()
                .When(x => x.ShippingDateOption == ShippingDateOption.Specify);

            RuleFor(x => x.SelectedDeliveryDate)
                .NotEmpty()
                .When(x => x.DeliveryDateOption == DeliveryDateOption.Specify);

            RuleFor(x => x.SelectedDeliveryDate)
                .GreaterThan(x => x.SelectedShippingDate.Value)
                .When(x => x.SelectedShippingDate.HasValue && x.SelectedDeliveryDate.HasValue)
                .WithMessage("Requested delivery date must be greater than shipping date");

            RuleFor(x => x.QueueOption)
                .NotNull()
                .When(x => x.AllocationOption == AllocationOption.QueueConsignment && IsCollectionService(x))
                .WithMessage("Please choose which services to use for auto allocation");

            RuleFor(x => x.AllocationOption)
                .NotNull()
                .WithMessage("Please choose an allocation option");

            RuleFor(x => x.SelectedCarrierCode)
                .NotEmpty()
                .When(x => x.CarrierSelectionOption == CarrierSelectionOption.SpecifyCarrier && IsDropOffService(x))
                .WithMessage("Please choose a carrier service");

            RuleFor(x => x.SelectedScheduledOrAdhocServiceCode)
                .NotEmpty()
                .When(x => x.ShippingType == ShippingType.CollectionPickUp)
                .WithMessage("Please choose a carrier service");

            RuleFor(x => x.DropOffPostcodeSource)
                .NotEmpty()
                .When(x => x.DropOffOption == DropOffOption.AnotherPostcode && IsDropOffService(x))
                .WithMessage("Please enter a postcode to find drop off locations");
        }

        private bool IsDropOffService(CreateConsignmentViewModel model)
        {
            return (model.ShippingType == ShippingType.DropOffDelivery ||
                    model.ShippingType == ShippingType.DropOffPickUp);
        }

        private bool IsCollectionService(CreateConsignmentViewModel model)
        {
            return (model.ShippingType == ShippingType.CollectionDelivery ||
                    model.ShippingType == ShippingType.CollectionPickUp);
        }
    }
}