namespace LoyaltyCalc
{
    public class LoyaltyCalculator
    {
        //TODO : Read from JSON and write to JSON (in future) and consider the need for rejection statuses
        private static readonly HashSet<string> CompletedStatuses = new()
        {
            "Выполнен (из магазина)", "Исполняется (в магазине)", "Выполнен (УкрПошта)", "Выполнен (Мост Экспресс)",
            "Исполняется (УкрПошта)", "Исполняется (Нова Почта)", "Выполнен (Нова Почта)", "Исполняется (Франчайзинг)",
            "Выполнен (в регионе)", "Выполнен (ДжастИн)", "Исполняется (ДжастИн)", "Выполнен (доставка)",
            "Исполняется (Octopus)", "Выполнен (Octopus)", "Исполняется (Мост Экспресс)", "Выполнен (курьером)",
            "Выполнен (Киевская обл.)","Выполнен (Франчайзинг)"
        };
        private static readonly HashSet<string> RejectedStatuses = new()
        {
            "Магазин", "Снят с резерва (Нова Почта)", "Отклонен", "Снят с резерва (магазин)", "Снят с резерва (доставка)",
            "Снят с резерва (Мост Экспресс)", "Снят Резерв", "Снят с резерва (Франчайзинг)"
        };

        public static LoyaltyResult LoyaltyCalculate(List<OrderModel> orderList)
        {
            var completedOrder = 0;
            var rejectedOrder = 0;
            var loyalty = 0;
            var totalAmount = 0m;

            var loyaltyResult = new LoyaltyResult(new Dictionary<int, int>(), totalAmount, completedOrder, rejectedOrder, loyalty);

            foreach (var order in orderList)
            {
                if (CompletedStatuses.Contains(order.Status))
                {
                    loyaltyResult.TotalCompleted++;
                    loyaltyResult.TotalAmount += order.Amount;

                    if (loyaltyResult.YearValuePairs.ContainsKey(order.Date.Year))
                    {
                        loyaltyResult.YearValuePairs[order.Date.Year]++;
                    }
                    else
                    {
                        loyaltyResult.YearValuePairs.Add(order.Date.Year, 1);
                    }
                }
                else
                {
                    loyaltyResult.TotalRejected++;
                }

                loyaltyResult.TotalLoyalty = loyaltyResult.TotalAmount * 0.03m;
            }
            return loyaltyResult;
        }
    }
}
