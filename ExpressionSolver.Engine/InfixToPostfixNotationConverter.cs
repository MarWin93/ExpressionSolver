using EquationsSolver.Engine.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquationsSolver.Engine
{
    internal class InfixToPostfixNotationConverter
    {
        internal IEnumerable<string> Convert(string[] equationElements, IDictionary<string, Operator> operators)
        {
            var stack = new Stack<Operator>(equationElements.Length);
            var outputElements = new List<string>(equationElements.Length);

            try
            {
                foreach (var equationElement in equationElements)
                {
                    if (int.TryParse(equationElement, out var number))
                    {
                        outputElements.Add(number.ToString());
                        continue;
                    }

                    if (!operators.TryGetValue(equationElement, out var op))
                    {
                        throw new ArgumentException($"Expression contains invalid element:'{equationElement}'");
                    }

                    if (!stack.TryPeek(out var vertexOp))
                    {
                        stack.Push(op);
                        continue;
                    }

                    if (op.Priority > vertexOp.Priority)
                    {
                        stack.Push(op);
                        continue;
                    }

                    do
                    {
                        vertexOp = stack.Pop();
                        outputElements.Add(vertexOp.ToString());

                        if (!stack.TryPeek(out vertexOp))
                        {
                            break;
                        }

                    } while (op.Priority <= vertexOp?.Priority);

                    stack.Push(op);
                }

                var leftovers = stack.Select(x => x.ToString());

                return outputElements.Concat(leftovers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
