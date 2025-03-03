namespace LoyaltyCalc
{
    public class DataParcer
    {
        public List<OrderModel> StringParce(string data) 
        {
            data.Replace("\r", "");
            var rows = data.Split("\n");






            return new List<OrderModel>();
        }
    }
}
