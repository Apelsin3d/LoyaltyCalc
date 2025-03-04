using LoyaltyCalc;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var open = new StreamReader("orders.txt");
var data = open.ReadToEnd();


Console.WriteLine(LoyaltyCalculator.LoyaltyCalculate(DataParcer.StringParce(data)));