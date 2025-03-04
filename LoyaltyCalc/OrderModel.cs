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
            //TODO: Add validation (maybe)
            Date = date;
            OrderNumber = orderNumber;
            Amount = amount;
            Status = status;
        }
        //TODO: Add GetHashCode
        public override bool Equals(object? obj)
        {
            if(obj is not OrderModel)
            {
                return false;
            }
            return Date == ((OrderModel)obj).Date &&
                OrderNumber == ((OrderModel)obj).OrderNumber &&
                Amount == ((OrderModel)obj).Amount &&
                Status == ((OrderModel)obj).Status;
        }
    }


}
