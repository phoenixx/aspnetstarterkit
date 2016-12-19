namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class OnboardingModel<T>
    {
        /// <summary>
        /// This holds the structure for the wizard's navigation
        /// </summary>
       // public ManageCustomerWizardViewModel OnboardingWizardVM { get; set; }

        /// <summary>
        /// The actual view model for the razor template(s)
        /// </summary>
        public T OnboardingWizardContentVM { get; set; }

        /// <summary>
        /// used to make binding on the Post side easier - if you copy the refenence into here, 
        /// you can use Html.HiddenFor and it will map to your viewmodel's Reference rather than 
        /// use an underscore separated path.
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Used to show confirmation of save on next screen.
        /// e.g. Basic details Save called, customer is not complete 
        /// so save redirects to manage subscription plan but we still want 
        /// feedback to show that customer was created/edited successfully
        /// </summary>
        public string MessageFromPreviousStep { get; set; }
    }
}