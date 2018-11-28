using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classses
{
    public class Calculate
    {
        //Add delegate
        private delegate double OperationDelegate(double x, double y);
        private Dictionary<string, OperationDelegate> _operations;

        //Add methods calculate
        private double Division(double x, double y) { return x / y; }
        private double Multiplay(double x, double y) { return x * y; }
        private double Subtraction(double x, double y) { return x - y; }
        private double Addition(double x, double y) { return x + y; }


        public Calculate()
        {
            _operations =
                new Dictionary<string, OperationDelegate>
                {
            { "+", this.Addition },
            { "-", this.Subtraction },
            { "*", this.Multiplay },
            { "/", this.Division },
                };
        }


        public double PerformOperation(string op, double x, double y)
        {
            if (!_operations.ContainsKey(op))
                throw new ArgumentException(string.Format("Operation {0} is invalid", op), "op");
            return _operations[op](x, y);
        }

    }
}
