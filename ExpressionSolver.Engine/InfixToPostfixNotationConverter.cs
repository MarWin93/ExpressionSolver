using ExpressionSolver.Engine.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionSolver.Engine
{
    internal class InfixToPostfixNotationConverter
    {
        internal IEnumerable<string> Convert(string[] expressionElements, IDictionary<string, Operator> operators)
        {
            var stack = new Stack<Operator>(expressionElements.Length);
            var outputElements = new List<string>(expressionElements.Length);

            try
            {
                foreach (var expressionElement in expressionElements)
                {
                    if (int.TryParse(expressionElement, out var number))
                    {
                        outputElements.Add(number.ToString());
                        continue;
                    }

                    if (!operators.TryGetValue(expressionElement, out var op))
                    {
                        throw new ArgumentException($"Expression contains invalid element:'{expressionElement}'");
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
