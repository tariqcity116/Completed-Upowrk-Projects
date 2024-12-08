namespace CalculaterApi
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Add(Calculation calculation)
        {
            return calculation.Operand1 + calculation.Operand2;
        }

        public decimal Subtract(Calculation calculation)
        {
            return calculation.Operand1 - calculation.Operand2;
        }

        public decimal Multiply(Calculation calculation)
        {
            return calculation.Operand1 * calculation.Operand2;
        }

        public decimal Divide(Calculation calculation)
        {
            if (calculation.Operand2 == 0)
            {
                throw new ArgumentException("Cannot divide by zero");
            }

            return calculation.Operand1 / calculation.Operand2;
        }
    }
}