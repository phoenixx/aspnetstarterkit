using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.Allocation.Enums
{
    public enum ShippingType
    {
        [Display(Name = "Collection > Delivery")]
        CollectionDelivery = 0,

        [Display(Name = "Drop-off > Delivery")]
        DropOffDelivery,

        [Display(Name = "Collection > Pick up from Carrier")]
        CollectionPickUp,

        [Display(Name = "Drop-off > Pick up from Carrier")]
        DropOffPickUp
    }
}
