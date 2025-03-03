namespace LoyaltyCalc
{
    public class OrderModel
    {
        public DateTime Date { get; set; }
        public string OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }


        public OrderModel (DateTime date, string orderNumber, decimal amount, string status)
        {
            //TODO: Add validation
            Date = date;
            OrderNumber = orderNumber;
            Amount = amount;
            Status = status;
        }
    }


}
