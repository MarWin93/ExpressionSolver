namespace EquationsSolver.Engine.Operators
{
    public class DivisionOperator : Operator
    {
        public override int Priority => 2;

        public override decimal Calculate(decimal a, decimal b)
        {
            return a / b;
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
