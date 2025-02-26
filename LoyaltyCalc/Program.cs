using System.Text;

var data = new StringBuilder();
string line;

while ((line =Console.ReadLine()) != null && line != "")
{
    data.AppendLine(line);
}

string result = data.ToString();
Console.WriteLine(LoyaltyCalc.OrderModel.GetLoyalty(result));

Console.ReadLine();

