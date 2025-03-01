namespace TPR
{
    internal class Strategy
    {
        public List<List<double>> Profit { get; set; }
        public List<List<double>>  Probabilites { get; set; }

        public List<double> CountExpectedProfit()
        {
            var list = new List<double>();
            for (int i = 0; i < Profit.Count; i++)
            {
                var value = 0.0;
                for (int j = 0; j < Profit[i].Count; j++)
                {
                    value += Profit[i][j] * Probabilites[i][j];
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
