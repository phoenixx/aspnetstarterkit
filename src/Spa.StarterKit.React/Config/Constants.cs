using System;
using Microsoft.AspNetCore.Http;

namespace Spa.StarterKit.React.Config
{
    public static class Constants
    {
        public static class DisplayOptions
        {
            public const int TABLE_PAGE_SIZE = 10;
        }

        public static class Passwords
        {
            public const string VALIDATION_REGEX =
                @"(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}";

            public const string VALIDATION_ERROR_MESSAGE =
                "Password must contain between 8 and 30 characters with at least one" +
                " number, one letter and one special character '$@$!%*#?&' ";
        }

        public static class UiStrings
        {
            public const string NotApplicable = "N/A";
            public const string Yes = "Yes";
            public const string No = "No";
            public const string ManualUpload = "Manual";
            public const string AnErrorOccured = "An error occured. Please contact customer services.";
            public const string MinimumValueIsParam = "Minimum value is '{0}'";
            public const string ParamIsNotAValidNumber = "'{0}' is not a valid number";
        }

        public static class AppSettingKeys
        {
            public const string ManualUploadMaxPackages = "ManualUploadMaxPackages";
            public const string GetConsignmentsLimit = "MPD.Configuration.GetConsignmentLimit";
            public const string FileUploadMaxInvoiceUploadFileSizeInMb = "FileUpload.MaxInvoiceUploadFileSizeInMb";
            public const string FileUploadAllowedFileTypes = "FileUpload.AllowedFileTypes";
            public const string FileUploadInvoiceContainerName = "FileUpload.InvoiceContainerName";
        }

        public static class SessionKeys
        {
            public const string AccountSessionKey = "Account";
            public const string CustomerSessionKey = "Customer";
            public const string AuthToken = "AuthToken";
            public const string AccountTimeZone = "AccountTimeZone";
            public const string MyAccountLink = "MyAccountLink";

            public const string ImpersonatedAccountSessionKey = "ImpersonateAccount";
            public const string ImpersonatedCustomerSessionKey = "ImpersonateCustomer";

            public const string TopUpTransactionSessionKey = "TopUpTransaction";

            public const string AccountNameAndCompany = "AccountNameAndCompany";

            public const string PrimaryApiKey = "PrimaryApiKey";
            public const string SecondaryApiKey = "SecondaryApiKey";
        }

        public static class AlertSettings
        {
            public const int DefaultAlertTimeout = 5000;
        }

        public static class CultureSettings
        {
            public static string DefaultTimeZone
            {
                get
                {
                    throw new NotImplementedException("netcore");
                    //var timezone = System.Configuration.ConfigurationManager.AppSettings["DefaultTimezone"];
                    //return timezone;
                }
            }
        }

        public static class PayPalSettings
        {
            public static class TopUpFunds
            {
                public static string ReturnUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Paypal.TopUpFunds.ReturnUrl"];
                        //return Utility.BuildUri(path);
                    }
                }

                public static string CancelUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Paypal.TopUpFunds.CancelUrl"];
                        //return Utility.BuildUri(path);
                    }
                }
            }

            public static class UpgradeSubscription
            {
                public static string ReturnUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //return System.Configuration.ConfigurationManager.AppSettings["Paypal.UpgradeSubscription.ReturnUrl"];
                    }
                }

                public static string CancelUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

//                        return System.Configuration.ConfigurationManager.AppSettings["Paypal.UpgradeSubscription.CancelUrl"];
                    }
                }
            }

            public static class SignUp
            {
                public static string ReturnUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Paypal.Signup.ReturnUrl"];
                        //return Utility.BuildUri(path);
                    }
                }

                public static string CancelUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Paypal.Signup.CancelUrl"];
                        //return Utility.BuildUri(path);
                    }
                }
            }
        }

        public static class PaymentSettings
        {
            public static class TopUpFunds
            {
                public static string CallbackUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Payments.TopUpFunds.CallbackUrl"];
                        //return Utility.BuildUri(path);
                    }
                }
            }

            public static class SignUp
            {
                public static string CallbackUrl
                {
                    get
                    {
                        throw new NotImplementedException("netcore");

                        //var path = System.Configuration.ConfigurationManager.AppSettings["Payments.SignUp.CallbackUrl"];
                        //return Utility.BuildUri(path);
                    }
                }
            }

            public static bool Perform3DsChecks
            {
                get
                {
                    throw new NotImplementedException("netcore");

                    //return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Payments.Perform3DsCheck"]);
                }
            }
        }

        public static class Utility
        {
            public static string BuildUri(string path)
            {
                throw new NotImplementedException("netcore");

                //var host = HttpContext.Current.Request.Url.Authority;
                //var scheme = HttpContext.Current.Request.Url.Scheme;
                //return string.Format("{0}://{1}{2}", scheme, host, path);
            }
        }

        public static class Consignments
        {
            public static int DaysData
            {
                get
                {
                    const int DEFAULT_VALUE = 30;
                    return DEFAULT_VALUE;
                    //throw new NotImplementedException("netcore");

                    //var value = System.Configuration.ConfigurationManager.AppSettings["Consignments.DefaultDaysData"];
                    //if (string.IsNullOrEmpty(value)) return DEFAULT_VALUE;
                    //int result;
                    //return !int.TryParse(value, out result) ? DEFAULT_VALUE : result;
                }
            }
        }
    }
}