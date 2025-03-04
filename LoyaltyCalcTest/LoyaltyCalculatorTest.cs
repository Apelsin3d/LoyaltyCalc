using LoyaltyCalc;

namespace LoyaltyCalcTest
{
    public class LoyaltyCalculatorTest
    {
        [Fact]

        public void LoyaltyCalculateTest()
        {
            var orderList = new List<OrderModel>();
            orderList.Add(new OrderModel(
                new DateTime(2025, 2, 23, 19, 15, 34),
                "РОЗ505050272",
                353.00m,
                "Выполнен (Франчайзинг)"
            ));
            orderList.Add(new OrderModel(
                new DateTime(2025, 1, 22, 17, 8, 29),
                "РОЗ502024810",
                294.00m,
                "Выполнен (Франчайзинг)"
            ));
            orderList.Add(new OrderModel(
                new DateTime(2025, 1, 22, 16, 55, 35),
                "РОЗ502023258",
                1099.00m,
                "Выполнен (Франчайзинг)"
            ));


            var loyaltyResult = new LoyaltyResult(new Dictionary<int, int>(), 0, 0, 0, 0);
            loyaltyResult.TotalCompleted = 3;
            loyaltyResult.TotalAmount = 1746.00m;
            loyaltyResult.YearValuePairs.Add(2025, 3);
            loyaltyResult.TotalLoyalty = loyaltyResult.TotalAmount * 0.03m;

            Assert.Equal(loyaltyResult, LoyaltyCalculator.LoyaltyCalculate(orderList));
        }

    
    }
}
