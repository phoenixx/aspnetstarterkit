using System;
using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Configuration.Enums;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    /// <summary>    
    /// NOTE: Cannot name this more suitably to "ShippingLocationViewModel" as one already exists :)
    /// </summary>
    public class ShippingLocationItemViewModel
    {        
        public int Id { get; set; }        
        public string Reference { get; set; }        
        public string Name { get; set; }        
        public ShippingLocationType ShippingLocationType { get; set; }        
        public bool DefaultLocationForReturns { get; set; }        
        public string Notes { get; set; }        
        public Guid CustomerReference { get; set; }        
        public List<ShippingLocationAccountViewModel> LinkedAccounts { get; set; }        
        public AddressViewModel Address { get; set; }
    }
}