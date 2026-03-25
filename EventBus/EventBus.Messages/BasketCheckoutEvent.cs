namespace EventBus.Messages
{
    public class BasketCheckoutEvent
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalProductsPrice { get; set; }
        public decimal? Shipping { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
