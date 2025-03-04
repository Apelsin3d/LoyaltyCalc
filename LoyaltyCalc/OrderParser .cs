using System.Globalization;

namespace LoyaltyCalc
{
    public class DataParcer
    {
        public static List<OrderModel> StringParce(string data)
        {
            data = data.Replace("\r", "");
            var rows = data.Split("\n");

            var listOrder = new List<OrderModel>();

            foreach (var row in rows.Skip(1)) // Skip header
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }
                var column = row.Split("\t");
                if (!DateTime.TryParse(column[0], out var date))
                {
                    continue;
                }
                var number = column[1].Trim();
                if (string.IsNullOrWhiteSpace(number))
                {
                    continue;
                }
                if (!decimal.TryParse(column[2].Replace("\u00A0", "").Replace(" ", "").Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
                {
                    continue;
                }
                var status = column[3].Trim();
                if (string.IsNullOrWhiteSpace(status))
                {
                    continue;
                }

                var order = new OrderModel(date, number, price, status);
                listOrder.Add(order);
            }
            return listOrder;
        }
    }
}
