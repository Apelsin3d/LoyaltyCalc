using LoyaltyCalc;
using System.Net.WebSockets;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
using var reader = new StreamReader("orders.txt");
var data = reader.ReadToEnd();

Console.WriteLine(LoyaltyCalculator.LoyaltyCalculate(DataParser.StringParse(data)));

Console.ReadLine();