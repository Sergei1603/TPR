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


        public MarkModel()
        {
            StateCount = 1;
            StrategyCount = 1;
            Steps = 1;
        }
        //public List<Strategy> Strategies { get; set; }
        //public MarkModel(int strategyCount, int stateCount, int Steps)
        //{
        //    this.StateCount = stateCount;
        //    this.StrategyCount = strategyCount;
        //    this.Steps = Steps;
        //    this.Strategies = new List<Strategy>();
        //}


    }
}
