using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var str = "Дата\tНомер\tСумма\tВид продажи\r\n" +
                "23.02.2025 19:15:34\tРОЗ505050272\t353,00\tВыполнен (Франчайзинг)\r\n" +
                "22.01.2025 17:08:29\tРОЗ502024810\t294,00\tВыполнен (Франчайзинг)\r\n" +
                "22.01.2025 16:55:35\tРОЗ502023258\t1 099,00\tВыполнен (Франчайзинг)";


var strdata = "02.03.2025 11:30:36";
var data = DateTime.Parse(strdata);

Console.WriteLine(data.Year.ToString());

Console.ReadLine();