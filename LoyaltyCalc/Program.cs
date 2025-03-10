using LoyaltyCalc;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var open = new StreamReader("orders.txt");
var data = open.ReadToEnd();
open.Dispose();


Console.WriteLine(LoyaltyCalculator.LoyaltyCalculate(DataParcer.StringParce(data)));
Console.Read();