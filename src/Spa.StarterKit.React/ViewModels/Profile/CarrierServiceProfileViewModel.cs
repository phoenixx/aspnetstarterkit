using System;
using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;
using Spa.StarterKit.React.ViewModels.Configuration.ShippingRules;

namespace Spa.StarterKit.React.ViewModels.Profile
{
    public class CarrierServiceProfileViewModel
    {
        public Guid CompanyReference { get; set; }
        public int Id { get; set; }
        public CarrierServiceViewModel Service { get; set; }

        public IList<LocationRestrictionViewModel> LocationRestrictions { get; set; }
        public IList<DimensionRestrictionViewModel> DimensionRestrictions { get; set; }
        public CompensationAndValueViewModel CompensationAndValue { get; set; }

        public CarrierServiceProfileViewModel()
        {
            DimensionRestrictions = new List<DimensionRestrictionViewModel>();
            LocationRestrictions = new List<LocationRestrictionViewModel>();
            CompensationAndValue = new CompensationAndValueViewModel();
        }
    }
}