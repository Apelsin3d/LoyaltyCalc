namespace LoyaltyCalc
{
    public class DataParcer
    {
        public List<OrderModel> StringParce(string data) 
        {
            data.Replace("\r", "");
            var rows = data.Split("\n");

            var listOrder = new List<OrderModel>();

            foreach (var row in rows)
            {

                if (row == "Дата\tНомер\tСумма\tВид продажи\r")
                {
                    rows = rows.Skip(1).ToArray();
                }
                else if(row == "" || row.Length < 4)
                {
                    rows = rows.Take(rows.Length - 1).ToArray();
                }
                var columns = row.Split("\t");
                var date = DateTime.Parse(columns[0]);
                var number = columns[1];
                var price = decimal.Parse(columns[2]);
                var status = columns[3];

                var order = new OrderModel(date, number, price, status);
                listOrder.Add(order);

            }
            return listOrder;
        }
    }
}
