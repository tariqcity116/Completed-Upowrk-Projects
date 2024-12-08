namespace AgentGoalMatrix
{
    //  Camera class
    internal class Camera : Base
    {
        public string Direction { get; }

        public Camera(int x, int y, string direction) : base(x, y)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
