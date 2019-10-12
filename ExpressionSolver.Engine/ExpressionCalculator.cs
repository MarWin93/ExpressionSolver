using EquationsSolver.Engine.Operators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EquationsSolver.Engine
{
    public class ExpressionCalculator
    {
        private readonly IDictionary<string, Operator> _operators;

        public ExpressionCalculator()
        {
            _operators = new Dictionary<string, Operator>
            {
                { "+", new AdditionOperator() },
                { "-", new SubtractionOperator() },
                { "*", new MultiplicationOperator() },
                { "/", new DivisionOperator() }
            };
        }

        public decimal Calculate(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentException($"Given expression cannot be null or empty.");
                }

                var converter = new InfixToPostfixNotationConverter();
                var calculator = new RPNCalculator();
                
                var equationElements = GetEquationElements(input);
                var postfixFormElements = converter.Convert(equationElements, _operators);

                return calculator.Calculate(postfixFormElements, _operators, equationElements.Length);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string[] GetEquationElements(string input)
        {
            var formattedExpression = Regex.Replace(input, @"\s+", "");
            var expRegString = "(?<=[-+*/()])|(?=[-+*/()])";

            var regex = new Regex(expRegString);
            return regex.Split(formattedExpression);
        }
    }
}
