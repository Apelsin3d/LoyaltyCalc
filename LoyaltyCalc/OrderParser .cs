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

            var pattern = @"(^[^а-яА-ЯҐґЄєІіЇї]*)(\S*)([^а-яА-ЯҐґЄєІіЇї]*)(.*$)";

            foreach (var item in rows)
            {
                var match = Regex.Match(item, pattern);

                //TODO: Add validation 
                if (match.Success)
                {
                    if(!decimal.TryParse(match.Groups[3].Value.Replace(" ", ""), out var result))
                    {
                        continue;
                    }
                    orders.Add(new OrderModel(
                        DateTime.Parse(match.Groups[1].Value),
                        match.Groups[2].Value,
                        result,
                        match.Groups[4].Value.Trim()
                    ));
                }
            }

            return orders;
        }
    }
}
