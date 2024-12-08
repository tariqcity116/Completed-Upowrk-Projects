namespace AgentGoalMatrix
{
    // class to find the safe path
    internal class Node : Base
    {
        public char Type { get; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, char type) : base(x, y)
        {
            X = x;
            Y = y;
            Type = type;
            F = 0;
            G = 0;
            H = 0;
            Parent = null;
        }
    }
}
