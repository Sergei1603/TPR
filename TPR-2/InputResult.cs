using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPR_2
{
    public enum TypeElem
    {
        And,
        Or,
        Init
    }

    public class InputResult
    {
        public InputResult(TypeElem type)
        {
            Type = type;
            Id = counter;
            counter++;
        }

        public int? Id;

        public string Name { get; set; }
        public double? Probably { get; set; }
        public TypeElem Type { get; set; }
        public InputResult Parent { get; set; }

        public static int counter = 0;
    }
}
