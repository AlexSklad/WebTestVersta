namespace WebTestVersta.Models
{
    public class NewOrderModel
    {
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        public Order order { get; set; }
        public NewOrderModel()
        {
            sender = new Sender();
            recipient = new Recipient();
            order = new Order();
        }
    }
}
