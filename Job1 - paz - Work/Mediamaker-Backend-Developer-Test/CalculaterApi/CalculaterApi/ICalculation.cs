namespace CalculaterApi
{
    public interface ICalculatorService
    {
        decimal Add(Calculation calculation);
        decimal Subtract(Calculation calculation);
        decimal Multiply(Calculation calculation);
        decimal Divide(Calculation calculation);
    }
}