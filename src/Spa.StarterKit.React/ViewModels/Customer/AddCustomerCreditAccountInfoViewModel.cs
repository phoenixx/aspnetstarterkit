namespace Spa.StarterKit.React.ViewModels.Customer
{
	public class AddCustomerCreditAccountInfoViewModel
	{
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public decimal CreditLimit { get; set; }
        public int PaymentTerms { get; set; }
	}
}
