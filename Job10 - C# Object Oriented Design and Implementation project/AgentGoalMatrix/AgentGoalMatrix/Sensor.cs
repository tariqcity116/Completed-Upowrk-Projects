namespace AgentGoalMatrix
{
    internal class Sensor : Base
    {
        //  sensor class
        public double Range { get; }

        public Sensor(int x, int y, double range):base(x,y)
        {
            X = x;
            Y = y;
            Range = range;
        }
    }
}
