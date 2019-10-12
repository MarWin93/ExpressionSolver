namespace EquationsSolver.Engine.Operators
{
    public abstract class Operator
    {
        public abstract int Priority { get; }

        public abstract decimal Calculate(decimal a, decimal b);
    }
}
