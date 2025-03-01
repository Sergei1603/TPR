using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPR
{
    internal class MarkModel
    {
        public int StrategyCount { get; set; }
        public int StateCount { get; set; }
        public int Steps { get; set; }

        public List<Strategy> Strategies { get; set; }

        public void UpdateMatrix(int StraregyCount, int StateCount)
        {
            var tmp1 = new List<List<double>>();
            for (int i = 0; i < StateCount; i++)
            {
                tmp1.Add(new List<double>(StateCount));
                for (int j = 0; j < StateCount; j++)
                {
                    tmp1[i].Add(0);
                }
            }

            for (int i = 0; i < StraregyCount; i++)
            {
                var strat = new Strategy();
                strat.Probabilites = new(tmp1);
                strat.Profit = new(tmp1);
                Strategies.Add(strat);
            }
        }

        internal void RemoveStrats(int start, int count)
        {
            this.Strategies.RemoveRange(start, count - start);
        }   
        internal void ClearStrats()
        {
            this.Strategies.Clear();
        }

        internal List<List<double>> Count()
        {
            List<List<double>> result = new();
            for (int i = 0; i < Strategies.Count; i++)
            {
                var expectedProfit = Strategies[i].CountExpectedProfit();
                result.Add(expectedProfit);
            }

            return result;
        }

        public MarkModel()
        {
            StateCount = 1;
            StrategyCount = 1;
            Steps = 1;
            Strategies = new();
            this.UpdateMatrix(StrategyCount, StateCount);
        }

        public MarkModel(int strategyCount, int stateCount, int steps, List<Strategy> strategies)
        {
            StrategyCount = strategyCount;
            StateCount = stateCount;
            Steps = steps;
            Strategies = strategies;
        }
    }
}
