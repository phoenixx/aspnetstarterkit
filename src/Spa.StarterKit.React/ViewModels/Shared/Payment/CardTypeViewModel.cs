using System;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    [Serializable]
    public class CardTypeViewModel
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public ChargeTypeViewModel ChargeType { get; set; }
    }
}