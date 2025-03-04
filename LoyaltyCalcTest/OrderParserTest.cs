using LoyaltyCalc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoyaltyCalcTest
{
    public class OrderParserTest
    {
        [Fact]
        public void StringToOrderTest()
        {
            var data = "����\t�����\t�����\t��� �������\r\n" +
                "23.02.2025 19:15:34\t���505050272\t353,00\t�������� (�����������)\r\n" +
                "22.01.2025 17:08:29\t���502024810\t294,00\t�������� (�����������)\r\n" +
                "22.01.2025 16:55:35\t���502023258\t1�099,00\t�������� (�����������)";

            var order = new List<OrderModel>();
            order.Add(new OrderModel(
                new DateTime(2025, 2, 23, 19, 15, 34),
                "���505050272",
                353.00m,
                "�������� (�����������)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 1, 22, 17, 8, 29),
                "���502024810",
                294.00m,
                "�������� (�����������)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 1, 22, 16, 55, 35),
                "���502023258",
                 1099.00m,
                 "�������� (�����������)"
            ));
            Assert.Equal(order, new DataParcer().StringParce(data));
        }

        [Fact]
        public void EmptyStringTest()
        {
            var data = "����\t�����\t�����\t��� �������\r\n" +
                "13.02.2025 11:15:38\t���504061779\t18�387,00\t�������� (�� ��������)\r\n" +
                "07.02.2025 11:27:41\t���503441490\t999,00\t�������� (�����������)\r\n" +
                "22.01.2025 14:29:32\t���502005700\t\t�������� (�����������)";

            var order = new List<OrderModel>();
            order.Add(new OrderModel(
                new DateTime(2025, 2, 13, 11, 15, 38),
                "���504061779",
                18387.00m,
                "�������� (�� ��������)"
            ));
            order.Add(new OrderModel(
                new DateTime(2025, 2, 7, 11, 27, 41),
                "���503441490",
                999.00m,
                "�������� (�����������)"
            ));
            Assert.Equal(order, new DataParcer().StringParce(data));
        }
    }
}