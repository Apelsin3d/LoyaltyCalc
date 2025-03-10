// Ignore Spelling: Calc

using LoyaltyCalc;

namespace LoyaltyCalcTest
{
    public class OrderParserTest
    {
        [Fact]
        public void StringToOrderTest()
        {
            var data = "Дата Номер Сумма  Вид продажи\r\n" +
                "23.02.2025 19:15:34 РОЗ505050272\t353,00 Выполнен (Франчайзинг)\r\n" +
                "22.01.2025 17:08:29 РОЗ502024810\t294,00 Выполнен (Франчайзинг)\r\n" +
                "22.01.2025 16:55:35 РОЗ502023258\t1 099,00 Выполнен (Франчайзинг)";

            var order = new List<OrderModel>();
            order.Add(new OrderModel(
                new DateTime(2025, 2, 23, 19, 15, 34),
                "РОЗ505050272",
                353.00m,
                "Выполнен (Франчайзинг)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 1, 22, 17, 8, 29),
                "РОЗ502024810",
                294.00m,
                "Выполнен (Франчайзинг)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 1, 22, 16, 55, 35),
                "РОЗ502023258",
                 1099.00m,
                 "Выполнен (Франчайзинг)"
            ));
            Assert.Equal(order, DataParser.StringParse(data));
        }

        [Fact]
        public void EmptyStringTest()
        {
            var data = "Дата Номер Сумма Вид продажи\r\n" +
                "13.02.2025 11:15:38 РОЗ504061779\t18 387,00 Выполнен (из магазина)\r\n" +
                "07.02.2025 11:27:41 РОЗ503441490\t999,00 Выполнен (Франчайзинг)\r\n" +
                "22.01.2025 14:29:32 РОЗ502005700  Выполнен (Франчайзинг)";

            var order = new List<OrderModel>();
            order.Add(new OrderModel(
                new DateTime(2025, 2, 13, 11, 15, 38),
                "РОЗ504061779",
                18387.00m,
                "Выполнен (из магазина)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 2, 7, 11, 27, 41),
                "РОЗ503441490",
                999.00m,
                "Выполнен (Франчайзинг)"
            ));
            Assert.Equal(order, DataParser.StringParse(data));
        }
    }
}