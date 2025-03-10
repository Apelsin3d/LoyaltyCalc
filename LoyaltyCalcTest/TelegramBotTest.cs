using LoyaltyCalc;
using Xunit;

namespace LoyaltyCalcTest
{
    public static class TelegramBotTest
    {
        [Fact]
        public static void TelegramDataLoyaltyResultTest()
        {
            var data = "Дата Номер Сумма Вид продажи\r\n" +
                "08.02.2025 19:20:44 РОЗ503610081 15 099,00 Выполнен (Франчайзинг)\r\n" +
                "23.01.2025 20:35:32 РОЗ502140144 110,00 Выполнен (Франчайзинг)\r\n" +
                "23.01.2025 20:33:43 РОЗ502140037 599,00 Выполнен (Франчайзинг)\r\n" +
                "21.12.2024 0:20:39 РОЗ436452621 1 899,00 Выполнен (Франчайзинг)\r\n" +
                "24.10.2024 11:02:24 РОЗ429458033 1 699,00 Выполнен (Франчайзинг)\r\n" +
                "24.10.2024 11:02:22 РОЗ429458015 1 277,00 Выполнен (Франчайзинг)\r\n" +
                "05.04.2024 15:37:02 РОЗ409828367 954,00 Выполнен (Франчайзинг)\r\n" +
                "03.11.2023 15:45:43 РОЗ326658859 2 899,00 Выполнен (Франчайзинг)\r\n" +
                "13.06.2023 9:44:08 РОЗ312725356 698,00 Исполняется (Франчайзинг)\r\n" +
                "12.06.2023 20:24:25 РОЗ312695338 345,00 Выполнен (Франчайзинг)\r\n" +
                "12.06.2023 20:24:25 РОЗ312695339 3 189,00 Выполнен (Франчайзинг)";

            var expectedResult = new LoyaltyResult(new Dictionary<int, int>(), 0, 0, 0, 0);
            expectedResult.TotalCompleted = 11;
            expectedResult.TotalRejected = 0;
            expectedResult.TotalAmount = 28768.00m;
            expectedResult.TotalLoyalty = expectedResult.TotalAmount * 0.03m;
            expectedResult.YearValuePairs.Add(2025, 3);
            expectedResult.YearValuePairs.Add(2024, 4);
            expectedResult.YearValuePairs.Add(2023, 4);


            Assert.Equal(LoyaltyCalculator.LoyaltyCalculate(DataParser.StringParse(data)).ToString(), expectedResult.ToString());
        }
    }
}
