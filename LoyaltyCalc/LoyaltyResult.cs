namespace LoyaltyCalc
{
    public class LoyaltyResult
    {
        public Dictionary<int,int> YearValuePairs {get; set;} = new Dictionary<int,int>();
        public decimal TotalAmount {get; set;}
        public int TotalCompleted {get; set;}
        public int TotalRejected {get; set;}
        public decimal TotalLoyalty {get; set;}

        public LoyaltyResult(Dictionary<int, int> yearValuePairs, decimal totalAmount, int totalCompleted, int totalRejected, decimal totalLoyalty)
        {
            YearValuePairs = yearValuePairs;
            TotalAmount = totalAmount;
            TotalCompleted = totalCompleted;
            TotalRejected = totalRejected;
            TotalLoyalty = totalLoyalty;
        }

        //TODO add HashCode
        public override bool Equals(object? obj)
        {
            if (obj is not LoyaltyResult)
            {
                return false;
            }

            var areEqual = 
                YearValuePairs.Count == ((LoyaltyResult)obj).YearValuePairs.Count && !YearValuePairs.Except(((LoyaltyResult)obj).YearValuePairs).Any();



            return areEqual &&
                TotalAmount == ((LoyaltyResult)obj).TotalAmount &&
                TotalCompleted == ((LoyaltyResult)obj).TotalCompleted &&
                TotalRejected == ((LoyaltyResult)obj).TotalRejected &&
                TotalLoyalty == ((LoyaltyResult)obj).TotalLoyalty;
        }
    }


}
