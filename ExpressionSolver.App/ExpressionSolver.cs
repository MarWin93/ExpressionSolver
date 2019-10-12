using EquationsSolver.Engine;
using System;

namespace EquationsSolver.App
{
    public class ExpressionSolver
    {
        static void Main(string[] args)
        {
            try
            {
                var input = args[0];

                Console.WriteLine($"Welcome in Expression Solver!");
                Console.WriteLine($"Your expression is: {input}");

                var equationCalculator = new ExpressionCalculator();
                var result = equationCalculator.Calculate(input);

                Console.WriteLine($"Expression has been calculated successfully.");
                Console.WriteLine($"The result is: {result}");

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Expression is invalid.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unrecognized error occured. Error Details:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
