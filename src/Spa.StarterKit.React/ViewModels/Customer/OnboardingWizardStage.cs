using Spa.StarterKit.React.Extensions;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class OnboardingWizardStage
    {
        public CustomerOnboardingStages Stage { get; set; }
        public string Name => Stage.ToDisplayName();
        public string Url { get; set; }

        public string @Class { get; set; }

        public bool IsActive { get; set; }

        public bool IsCurrent { get; set; }
    }
}