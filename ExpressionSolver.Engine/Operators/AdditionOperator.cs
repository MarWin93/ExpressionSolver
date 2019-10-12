namespace ExpressionSolver.Engine.Operators
{
    public class AdditionOperator : Operator
    {
        public override int Priority => 1;

        public override decimal Calculate(decimal a, decimal b)
        {
            return a + b;
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
