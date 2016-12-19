using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts;
using Spa.StarterKit.React.Extensions;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class CustomerPaymentMethodViewModel
    {
        public CustomerPaymentMethodViewModel()
        {
            ValidationErrors = new List<ValidationError>();
        }
        public string CustomerReference { get; set; }
        public decimal CreditLimit { get; set; }
        public int PaymentTerms { get; set; }
        public PaymentModel PaymentModel { get; set; }
        public string CurrencyIsoCode { get; set; }

        public string InvalidPaymentOption => ((int)PaymentModel.CustomerNotComplete).ToString(); 

        private static SelectList _paymentModels;
        public SelectList PaymentModels
        {
            get
            {
                if (_paymentModels == null)
                {
                    var dictionary = new Dictionary<int, string>();
                    foreach (var value in Enum.GetValues(typeof(PaymentModel)))
                    {
                        dictionary.Add((int)value, ((PaymentModel)value).ToDescription());
                    }

                    _paymentModels = new SelectList(dictionary, "Key", "Value");
                }
                return _paymentModels;
            }
            //set { }
        }

        private static SelectList _paymentTermOptions;
        public SelectList PaymentTermsOptions
        {
            get
            {
                if (_paymentTermOptions == null)
                {
                    var dictionary = new Dictionary<int, string>();
                    foreach (var value in Enum.GetValues(typeof(PaymentTerms)))
                    {
                        dictionary.Add((int)value, ((PaymentTerms)value).ToDescription());
                    }
                    _paymentTermOptions = new SelectList(dictionary, "Key", "Value");
                }
                return _paymentTermOptions;
            }
        }

        public SelectList SupportedCurrenciesOptions{ get; set; }

        public List<ValidationError> ValidationErrors { get; set; }
    }
}