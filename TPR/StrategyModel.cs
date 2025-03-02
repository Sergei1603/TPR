namespace TPR
{
    internal class Strategy
    {
        public List<List<double>> Profit { get; set; }
        public List<List<double>>  Probabilites { get; set; }

        public List<double> CountExpectedProfit(List<double>? maxProfitsByState = null, List<double>? profitAfterFirstStep = null)
        {
            var list = new List<double>();
            for (int i = 0; i < Profit.Count; i++)
            {
                var value = 0.0;
                if (maxProfitsByState != null)
                {
                    value += profitAfterFirstStep.ElementAt(i);
                    for (int j = 0; j < maxProfitsByState.Count; j++)
                    {
                        value += maxProfitsByState[j] * Probabilites[i][j];
                    }
                }
                else
                {
                    for (int j = 0; j < Profit[i].Count; j++)
                    {
                        value += Profit[i][j] * Probabilites[i][j];
                    }
                }
                list.Add(value);
            }
            return list;
        }
        public void UpdateStrats(Tuple<List<object?>, List<object?>> newValues, int index)
        {

        }
    }
}
