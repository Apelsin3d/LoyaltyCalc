namespace LoyaltyCalc
{
    public class OrderModel
    {
        public DateTime Date { get; set; }
        public string OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }


        private static readonly HashSet<string> CompletedStatuses = new()
        {
            "Выполнен (из магазина)", "Исполняется (в магазине)", "Выполнен (УкрПошта)", "Выполнен (Мост Экспресс)",
            "Исполняется (УкрПошта)", "Исполняется (Нова Почта)", "Выполнен (Нова Почта)", "Исполняется (Франчайзинг)",
            "Выполнен (в регионе)", "Выполнен (ДжастИн)", "Исполняется (ДжастИн)", "Выполнен (доставка)",
            "Исполняется (Octopus)", "Выполнен (Octopus)", "Исполняется (Мост Экспресс)", "Выполнен (курьером)",
            "Выполнен (Киевская обл.)"
        };
        private static readonly HashSet<string> RejectedStatuses = new()
        {
            "Магазин", "Снят с резерва (Нова Почта)", "Отклонен", "Снят с резерва (магазин)", "Снят с резерва (доставка)",
            "Снят с резерва (Мост Экспресс)", "Снят Резерв", "Снят с резерва (Франчайзинг)"
        };
        private static List<OrderModel> ParseData(string data)
        {
            var rows = new List<string>();
            var orders = new List<OrderModel>();

            data = data.Substring(30);
            data = data.Replace("\r\n", "\n");
            rows = data.Split('\n').ToList();


            foreach (var item in rows)
            {

                //TODO: Add validation for the row
                if (string.IsNullOrEmpty(item))
                {
                    break;
                }
                var order = new OrderModel();
                order.Date = DateTime.Parse(item.Split('\t')[0]);
                order.OrderNumber = item.Split('\t')[1];
                order.Amount = decimal.Parse(item.Split('\t')[2]);
                order.Status = item.Split('\t')[3];

                orders.Add(order);
            }
            return orders;
        }
        private static string CalculateLoyalty(List<OrderModel> orders)
        {
            var completedOrders = orders.Where(x => CompletedStatuses.Contains(x.Status)).ToList();
            var rejectedOrders = orders.Where(x => RejectedStatuses.Contains(x.Status)).ToList();
            var sum = completedOrders.Sum(x => x.Amount);
            var loyalty = sum * 0.03m;

            return $"Виконаних замовлень:{completedOrders.Count} \nСкасованих замовлень:{rejectedOrders.Count} \nСума виконаних замовлень:{sum}\nЛояльність:{loyalty}";
        }
        public static string GetLoyalty(string data)
        {
            var orders = ParseData(data);
            return CalculateLoyalty(orders);
        }
    }


}
