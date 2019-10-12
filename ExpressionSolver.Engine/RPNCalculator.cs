using ExpressionSolver.Engine.Operators;
using System;
using System.Collections.Generic;

namespace ExpressionSolver.Engine
{
    internal class RPNCalculator
    {
        internal decimal Calculate(
            IEnumerable<string> postfixFormElements,
            IDictionary<string, Operator> operators,
            int expressionElementsLength)
        {
            var stack = new Stack<decimal>(expressionElementsLength);

            try
            {
                foreach (string element in postfixFormElements)
                {
                    if (decimal.TryParse(element, out var digit))
                    {
                        stack.Push(digit);
                        continue;
                    }

                    var op = operators[element];
                    var a = stack.Pop();
                    var b = stack.Pop();

                    var operationResult = op.Calculate(b, a);

                    stack.Push(operationResult);
                }

                return stack.Pop();
            }
            catch (DivideByZeroException ex)
            {
                throw new ArgumentException($"Given expression contains division by 0.", ex);
            }
        }
    }
}
