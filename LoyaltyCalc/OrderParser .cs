// Ignore Spelling: Calc

using System.Text.RegularExpressions;

namespace LoyaltyCalc
{
    public static class DataParser
    {
        public static List<OrderModel> StringParse(string data)
        {
            var orders = new List<OrderModel>();
            data = data.Replace("\r", "");
            data = data.Replace("\t", " ");
            var rows = new List<string>(data.Split('\n').Where(r => !string.IsNullOrWhiteSpace(r)).Skip(1)); // Skip header and empty lines

            var pattern = @"(?<Дата>\d{2}\.\d{2}\.\d{4} \d{2}:\d{2}:\d{2})\s*(?<Номер>РОЗ\d+)\s*(?<Сумма>[\d\s,]+)\s*(?<ВидПродажи>.+)";

            foreach (var item in rows)
            {
                var match = Regex.Match(item, pattern);

                if (match.Success)
                {
                        orders.Add(new OrderModel(
                            DateTime.Parse(match.Groups["Дата"].Value),
                            match.Groups["Номер"].Value,
                            decimal.Parse(match.Groups["Сумма"].Value.Replace(" ", "")),
                            match.Groups["ВидПродажи"].Value.Trim()
                        ));
                }
                else
                {
                    Console.WriteLine($"Failed to parse line: {item}");
                }
            }

            return orders;
        }
    }
}
