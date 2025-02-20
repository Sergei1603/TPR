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
        public MarkModel() { }


    }
}
