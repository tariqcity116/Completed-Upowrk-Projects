using AgentGoalMatrix;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

class Mission : IMission
{
    // veriables
    public int gridXSize { get; set; }
    public int gridYSize  { get; set; }
    public int gridTopLeftX  { get; set; }
    public int gridTopLeftY  { get; set; }
    public int gridBottomRightX  { get; set; }
    public int gridBottomRightY  { get; set; }
    public char[,] missionGrid { get; set; }
    private List<Obstacle> obstacles;
    private List<Fence> fences;
    private List<Sensor> sensors;
    private List<Camera> cameras;


    //  constructor
    public Mission()
    {
        gridXSize = 0;
        gridYSize = 0;
        
        
        obstacles = new List<Obstacle>();
        fences = new List<Fence>();
        sensors = new List<Sensor>();
        cameras = new List<Camera>();
    }
    
    public void DisplayObstacleMap(int topLeftCellX,int topLeftCellY,int bottomRightCellX,int bottomRightCellY)
    {
        for (int j = 0; j < gridYSize; j++)
        {
            for (int i = 0; i < gridXSize; i++)
            {
                if (i >= topLeftCellX && i <= bottomRightCellX && j >= topLeftCellY && j <= bottomRightCellY)
                {
                    if (missionGrid[i, j] == '\0')
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(missionGrid[i, j]);
                    }
                }
            }
            if (j >= topLeftCellY && j <= bottomRightCellY)
                Console.WriteLine();
        }
    }

    public void AddHurdlesInGrid(int topLeftX,int topLeftY)
    {
        // Add Obstacle
        if (obstacles.Count > 0)
        {
            foreach(Obstacle obstacle in obstacles)
            {
                    AddObstacleInGrid(obstacle.X - topLeftX, obstacle.Y - topLeftY);
            }
        }

        // Add fance
        if (fences.Count > 0)
        {
            foreach (Fence fence in fences)
            {
                AddFenceInGrid(fence.X1 - topLeftX, fence.Y1 - topLeftY, fence.X2 - topLeftX, fence.Y2 - topLeftY);
            }
        }

        // Add Sensor
        if (sensors.Count > 0)
        {
            foreach (Sensor sensor in sensors)
            {
                AddSensorInGrid(sensor.X- topLeftX, sensor.Y - topLeftY, sensor.Range);
            }
        }

        // Add Camera
        if (cameras.Count > 0)
        {
            foreach (Camera camera in cameras)
            {
                AddCameraInGrid(camera.X- topLeftX, camera.Y - topLeftY, camera.Direction);
            }
        }

    }
    public void AddObstacle(int x, int y)
    {
        obstacles.Add(new Obstacle(x, y));
    }

    public void AddObstacleInGrid(int x, int y)
    {
        if (x >= 0 && x < gridXSize && y >= 0 && y < gridYSize)
        {
            missionGrid[x, y] = 'g';
        }
        else
        {
            Console.WriteLine("Invalid position. Obstacle not added.");
        }
    }

    public void AddFence(int x1, int y1, int x2, int y2)
    {
        fences.Add(new Fence(x1, y1, x2, y2));
    }

    public void AddFenceInGrid(int x1, int y1, int x2, int y2)
    {
        
        if (x1 >= 0 && x1 < gridXSize && y1 >= 0 && y1 < gridYSize
            && x2 >= 0 && x2 < gridXSize && y2 >= 0 && y2 < gridYSize)
        {
           
            if (x1 != x2)
            {
                if (x2 > x1 && y1 == y2)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            missionGrid[i, j] = 'f';
                        }
                    }
                }
                else if (x1 > x2 && y1 == y2)
                {
                    for (int i = x2; i <= x1; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            missionGrid[i, j] = 'f';
                        }
                    }
                }
            }

            if (y1 != y2)
            {
                if (y2 > y1)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            missionGrid[i, j] = 'f';
                        }
                    }
                }
                else if (y1 > y2)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y2; j <= y1; j++)
                        {
                            missionGrid[i, j] = 'f';
                        }
                    }
                }
            }



        }
        else
        {
            Console.WriteLine("Invalid fence coordinates. Fence not added.");
        }
    }

    public void AddSensor(int x, int y, double range)
    {
        sensors.Add(new Sensor(x, y, range));
    }

    public void AddSensorInGrid(int x, int y, double range)
    {
        DisplaySensorOnGrid();
    }

    public void DisplaySensorOnGrid()
    {
        for (int i = 0; i < missionGrid.GetLength(0); i++)
        {
            for (int j = 0; j < missionGrid.GetLength(1); j++)
            {
                char cell = missionGrid[i, j];

                // Check if the cell represents a sensor or its range
                foreach (var sensor in sensors)
                {
                    if (sensor.X - gridTopLeftX == i && sensor.Y - gridTopLeftY == j)
                    {
                        missionGrid[i, j] = 's'; // 'S' represents a sensor
                        break;
                    }
                    else if (IsWithinSensorRange(i, j, sensor))
                    {
                        missionGrid[i, j] = 's'; // 'R' represents sensor range
                    }
                }
            }
        }
    }

    public void AddCamera(int x, int y, string direction)
    {
        cameras.Add(new Camera(x, y, direction));
    }

    public void AddCameraInGrid(int x, int y, string direction)
    {
        if (x >= 0 && x < gridXSize && y >= 0 && y < gridYSize)
        {
            missionGrid[x, y] = 'c';
            MarkCameraDirection(x, y, direction);
        }
        else
        {
            Console.WriteLine("Invalid camera parameters. Camera not added.");
        }
    }


    public List<Point> FindSafePath(int startX, int startY, int targetX, int targetY)
    {
       
        // Create a list of nodes representing the grid
        Node[,] nodes = new Node[gridXSize, gridYSize];
        for (int x = 0; x < gridXSize; x++)
        {
            for (int y = 0; y < gridYSize; y++)
            {
                nodes[x, y] = new Node(x, y, missionGrid[x, y]);
            }
        }

        // Initialize the open and closed sets
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        // Find the start and target nodes

        Node startNode =   nodes[startX , startY];
        Node targetNode = nodes[targetX, targetY];

        // Add the start node to the open set
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            // Find the node with the lowest f cost in the open set
            Node currentNode = openSet.OrderBy(node => node.F).First();

            // Remove the current node from the open set
            openSet.Remove(currentNode);

            // Add the current node to the closed set
            closedSet.Add(currentNode);

            // If we have reached the target node, reconstruct the path
            if (currentNode == targetNode)
            {
                List<Point> path = new List<Point>();
                Node current = targetNode;
                while (current != null)
                {
                    path.Add(new Point(current.X, current.Y));
                    missionGrid[current.X, current.Y] = 'p';
                    current = current.Parent;
                }
                path.Reverse();
                return path;
            }

            // Get neighboring nodes
            List<Node> neighbors = GetNeighbors(nodes, currentNode);

            foreach (Node neighbor in neighbors)
            {
                if (closedSet.Contains(neighbor) || neighbor.Type == 'g' || neighbor.Type == 'f' || neighbor.Type == 's' || neighbor.Type == 'c')
                    continue;

                int tentativeG = currentNode.G + 1; // Assuming each move has a cost of 1

                if (!openSet.Contains(neighbor) || tentativeG < neighbor.G)
                {
                    neighbor.Parent = currentNode;
                    neighbor.G = tentativeG;
                    neighbor.H = Heuristic(neighbor, targetNode);
                    neighbor.F = neighbor.G + neighbor.H;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        // No path found
        return null;
    }

    public List<string> GetSafeDirections(int startX, int startY)
    {
        List<string> safeDirections = new List<string>();

        //  check is there any obstical in that South direction
        var isNorthSaveDirection = true;
        for (int i = startY - 1; i >= 0; i--)
        {
            if (missionGrid[startX, i] != '\0')
            {
                isNorthSaveDirection = false;
            }
        }
        if (isNorthSaveDirection)
            safeDirections.Add("N");

        //  check is there any obstical in that North direction
        var isSouthSaveDirection = true;
        for (int i = startY + 1; i <= missionGrid.GetLength(1) - 1; i++)
        {
            if (missionGrid[startX, i] != '\0')
            {
                isSouthSaveDirection = false;
            }
        }
        if (isSouthSaveDirection)
            safeDirections.Add("S");



        //  check is there any obstical in that east direction
        var isEastSaveDirection = true;
        for (int i = startX + 1; i <= missionGrid.GetLength(0) - 1; i++)
        {
            if (missionGrid[i, startY] != '\0')
            {
                isEastSaveDirection = false;
            }
        }
        if (isEastSaveDirection)
            safeDirections.Add("E");


        //  check is there any obstical in that west direction
        var isWestSaveDirection = true;
        for (int i = startX - 1; i >= 0; i--)
        {
            if (missionGrid[i, startY] != '\0')
            {
                isWestSaveDirection = false;
            }
        }
        if (isWestSaveDirection)
            safeDirections.Add("W");

        if (safeDirections.Count > 0)
        {
            var dirs = string.Empty;
            foreach (var direction in safeDirections)
            {
                dirs += direction;
            }

            Console.WriteLine("You can safely take any of the following directions: " + dirs);
        }
        else
        {
            Console.WriteLine("You cannot safely move in any direction. Abort mission."); 
        }

        return safeDirections;
    }

    public List<string> GetSafePath(int startX, int startY, int targetX, int targetY)
    {
        List<Point> safePath = FindSafePath(startX, startY, targetX, targetY);

        if (safePath == null || safePath.Count == 0)
        {
            return null; // No safe path found
        }

        List<string> directions = new List<string>();

        for (int i = 1; i < safePath.Count; i++)
        {
            int deltaX = safePath[i].X - safePath[i - 1].X;
            int deltaY = safePath[i].Y - safePath[i - 1].Y;

            if (deltaX == 1)
            {
                directions.Add("E");
            }
            else if (deltaX == -1)
            {
                directions.Add("W");
            }
            else if (deltaY == 1)
            {
                directions.Add("S");
            }
            else if (deltaY == -1)
            {
                directions.Add("N");
            }
        }

        if (directions.Count > 0)
        {
            var dirs = string.Empty;
            foreach (var direction in directions)
            {
                dirs += direction;
            }
            Console.WriteLine("The following path will take you to the objective: ");
            Console.WriteLine(dirs);
        }

        return directions;
    }

    public void MarkPathOnGrid(List<Point> path)
    {
        foreach (Point point in path)
        {
            missionGrid[point.X, point.Y] = 'P'; // 'P' represents the path
        }
    }

    public Boolean IsValidInput(string coorX, string coorY)
    {
        int x, y;
        var result = true;


        if (
            !int.TryParse(coorX, out x) ||
            !int.TryParse(coorY, out y) 
             )
        {
            result = false;
            // Console.WriteLine("Invalid input. Please enter the location in the format 'X,Y' where X and Y are integers within the grid bounds.");
        }

        return result;

    }


    private List<Node> GetNeighbors(Node[,] nodes, Node node)
    {
        List<Node> neighbors = new List<Node>();
        int x = node.X;
        int y = node.Y;

        if (x > 0) neighbors.Add(nodes[x - 1, y]);
        if (x < nodes.GetLength(0) - 1) neighbors.Add(nodes[x + 1, y]);
        if (y > 0) neighbors.Add(nodes[x, y - 1]);
        if (y < nodes.GetLength(1) - 1) neighbors.Add(nodes[x, y + 1]);

        return neighbors;
    }

    private int Heuristic(Node a, Node b)
    {
        // Calculate Manhattan distance as the heuristic
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private bool IsWithinSensorRange(int x, int y, Sensor sensor)
    {
        long distance = Convert.ToInt64(Math.Sqrt(Math.Pow(x - (sensor.X - gridTopLeftX), 2) + Math.Pow(y - (sensor.Y - gridTopLeftY), 2)));
        return distance <= sensor.Range;
    }

    private void MarkCameraDirection(int row, int col, string direction)
    {
        // Calculate the visible points within a 90-degree cone of vision
        int halfCone = 45; // Half of 90 degrees
        int numRows = missionGrid.GetLength(0);
        int numCols = missionGrid.GetLength(1);

        // Convert camera direction to degrees
        int degrees = 0;
        switch (direction.ToUpper())
        {
            case "S":
                degrees = 0;
                break;
            case "N":
                degrees = 180;
                break;
            case "E":
                degrees = 90;
                break;
            case "W":
                degrees = 270;
                break;
        }

        // Iterate through the grid and mark visible points
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                // Calculate the angle between the camera direction and the point
                double angle = Math.Atan2(i - row, j - col) * (180.0 / Math.PI);
                angle = (angle + 360) % 360; // Normalize angle to [0, 360)

                // Check if the point is within the visible cone
                if (Math.Abs(angle - ((angle > 270 && degrees == 0) ? 360 : degrees)) <= halfCone)
                {
                    missionGrid[i, j] = 'c'; // Mark visible points
                }
            }
        }
    }


}
