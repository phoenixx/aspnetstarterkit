//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Spa.StarterKit.React.ViewModels.Customer
//{
//    public class ManageCustomerWizardViewModel
//    {
//        private readonly HttpContextBase _httpContext;

//        #region Construction

//        public static ManageCustomerWizardViewModel Create(HttpContextBase httpContext, string customerReference, string subscriptionPlanReference, PaymentModel paymentModel)
//        {
//            var model = Create(httpContext, customerReference, subscriptionPlanReference, (PaymentModel?)paymentModel);
//            SetupStage(CustomerOnboardingStages.Users, model, customerReference, paymentModel != PaymentModel.CustomerNotComplete);
//            return model;
//        }

//        private static ManageCustomerWizardViewModel Create(HttpContextBase httpContext, string customerReference, string subscriptionPlanReference, PaymentModel? paymentModel)
//        {
//            var model = Create(httpContext, customerReference, subscriptionPlanReference);
//            SetupStage(CustomerOnboardingStages.PaymentDetails, model, customerReference, 
//                (!string.IsNullOrEmpty(subscriptionPlanReference) && subscriptionPlanReference != Guid.Empty.ToString())
//                );
//            return model;
//        }
        
//        private static ManageCustomerWizardViewModel Create(HttpContextBase httpContext, string customerReference, string subscriptionPlanReference)
//        {
//            var model = Create(httpContext, customerReference);
//            SetupStage(CustomerOnboardingStages.SubscriptionPlan, model, customerReference, !string.IsNullOrWhiteSpace(customerReference));
//            return model;
//        }

//        private static ManageCustomerWizardViewModel Create(HttpContextBase httpContext, string customerReference)
//        {
//            var model = new ManageCustomerWizardViewModel(httpContext);
//            SetupStage(CustomerOnboardingStages.BasicDetails, model, customerReference, true);
//            return model;
//        }

//        private static ManageCustomerWizardViewModel Create(HttpContextBase httpContext)
//        {
//            var model = new ManageCustomerWizardViewModel(httpContext);
//            SetupStage(CustomerOnboardingStages.BasicDetails, model, null, true);
//            return model;
//        }
        
//        private ManageCustomerWizardViewModel(HttpContextBase httpContext)
//        {
//            _httpContext = httpContext;
//            Stages = new List<OnboardingWizardStage>()
//            {
//                new OnboardingWizardStage()
//                {
//                    Stage = CustomerOnboardingStages.BasicDetails,
//                    Url = "",
//                    Class = "inactive first",
//                    IsActive = true
//                },
//                new OnboardingWizardStage()
//                {
//                    Stage = CustomerOnboardingStages.SubscriptionPlan,
//                    Url = "inactive",
//                    IsActive = false
//                },
//                new OnboardingWizardStage()
//                {
//                    Stage = CustomerOnboardingStages.PaymentDetails,
//                    Url = "inactive",
//                    IsActive = false
//                },
//                new OnboardingWizardStage()
//                {
//                    Stage = CustomerOnboardingStages.Users,
//                    Url = "",
//                    Class = "inactive last",
//                    IsActive = false
//                }
//            };
//        }

//        #endregion

       
//        public List<OnboardingWizardStage> Stages { get; set; }
//        public string ReferenceString { get; set; }
//        public string NextStageUrl {
//            get
//            {
//                var currentStage = this.Stages.First(x => x.IsCurrent);
//                return this.Stages.First(x => x.Stage == currentStage.Stage.GetNextCustomerOnboardingStage()).Url;
//            }
//        }

//        public OnboardingWizardStage GetStageFor(CustomerOnboardingStages stage)
//        {
//            return Stages.FirstOrDefault(x => x.Stage == stage);
//        }
       

//        private string SetupClassses(OnboardingWizardStage currentStage)
//        {
//            var classes = currentStage.Class ?? "inactive"; // always set it to default to inactive
//            if (currentStage.IsActive)
//            {
//                classes = classes.Replace("inactive", "active");
//            }
//            if (currentStage.IsCurrent)
//            {
//                classes += $"{(classes.Length > 0 ? " " : "")} current";
//            }
//            return classes;
//        }

//        private bool IsCurrentStage(string url)
//        {
//            return _httpContext.Request.Path.ToLower().Contains(url);
//        }


//        private static void SetupStage(CustomerOnboardingStages stageToSetup, ManageCustomerWizardViewModel model, string customerReference, bool secondaryActiveCriteria)
//        {
//            var currentStage = model.Stages.First(x => x.Stage == stageToSetup);
//            currentStage.Url = ManageCustomerOnboardingWizardService.GetUrlForStage(
//                currentStage.Stage,
//                customerReference);
//            currentStage.IsCurrent = model.IsCurrentStage(currentStage.Url);
//            currentStage.IsActive =
//                ManageCustomerOnboardingWizardService.ArePreviousStagesAllActive(model, currentStage) &&
//                secondaryActiveCriteria;
//            currentStage.Class = model.SetupClassses(currentStage);
//        }
//    }
//}