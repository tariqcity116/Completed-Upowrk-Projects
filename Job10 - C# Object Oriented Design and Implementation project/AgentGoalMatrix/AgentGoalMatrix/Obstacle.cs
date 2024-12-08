using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentGoalMatrix
{
    //  Obstacle class
    internal class Obstacle :Base
    {
        public Obstacle(int x, int y):base(x,y)
        {
            X = x;
            Y = y;
        }
    }
}
