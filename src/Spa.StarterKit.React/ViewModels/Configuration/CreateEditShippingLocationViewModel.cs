using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class CreateEditShippingLocationViewModel
    {
        public CreateEditShippingLocationViewModel()
        {
            ShippingLocation = new ShippingLocationViewModel();
        }

        [JsonIgnore]
        public bool IsEditMode { get; set; }

        [JsonIgnore]
        public SelectList AvailableCountries { get; set; }

		public SelectList Titles { get; set; }

        public ShippingLocationViewModel ShippingLocation { get; set; }

        public IList<System.Collections.Generic.KeyValuePair<string, string>> AvailableAccounts { get; set; }

        public Guid AccountReference { get; set; }
    }
}