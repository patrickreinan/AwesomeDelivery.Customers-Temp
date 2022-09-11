namespace AwesomeDelivery.Customers.Application.InputModels
{
    public class PaymentMethodInputModel {
        public List<PaymentMethodItemInputModel> Items { get; set; }
    }

    public class PaymentMethodItemInputModel {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}