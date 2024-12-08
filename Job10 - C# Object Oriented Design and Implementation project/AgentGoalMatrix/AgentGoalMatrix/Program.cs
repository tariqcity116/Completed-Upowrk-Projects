using System;

namespace AgentGoalMatrix
{
    class Program
    {
        //  main execution point to run the program
        static void Main(string[] args)
        {
            DoAgain:
            try
            {
                IMission mission = new Mission();
                while (true)
                {
                    Console.WriteLine("Select one of the following options");
                    Console.WriteLine("g) Add Obstacle");
                    Console.WriteLine("f) Add Fence");
                    Console.WriteLine("s) Add Sensor");
                    Console.WriteLine("c) Add Camera");
                    Console.WriteLine("d) Show safe directions");
                    Console.WriteLine("m) Display obstacle map");
                    Console.WriteLine("p) Find Safe Path");
                    Console.WriteLine("x) Exit");
                    Console.WriteLine("Enter code: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {

                        case "g":
                        tryGardLocAgain:
                            Console.WriteLine("Enter the guard's location (X,Y): ");
                            var obstacle = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(obstacle[0], obstacle[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryGardLocAgain;
                            }
                            int x = int.Parse(obstacle[0]) ;
                            int y = int.Parse(obstacle[1]) ;
                            mission.AddObstacle(x, y);
                            break;

                        case "f":
                        tryFenceLocStartAgain:
                            Console.WriteLine("Enter the location where the fence starts (X,Y): ");
                            var fenceStart = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(fenceStart[0], fenceStart[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryFenceLocStartAgain;
                            }
                            int fenceX1 = int.Parse(fenceStart[0]) ;
                            int fenceY1 = int.Parse(fenceStart[1]) ;
                        tryFenceLocEndStartAgain:
                            Console.WriteLine("Enter the location where the fence ends (X,Y): ");
                            var fenceEnd = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(fenceEnd[0], fenceEnd[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryFenceLocEndStartAgain;
                            }

                            int fenceX2 = int.Parse(fenceEnd[0]) ;
                            int fenceY2 = int.Parse(fenceEnd[1]) ;
                            mission.AddFence(fenceX1, fenceY1, fenceX2, fenceY2);
                            break;

                        case "s":
                        trySensorLocAgain:
                            Console.WriteLine("Enter the location where the Sensor: ");

                            var sensorStart = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(sensorStart[0], sensorStart[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto trySensorLocAgain;
                            }
                            int sensorX = int.Parse(sensorStart[0]) ;
                            int sensorY = int.Parse(sensorStart[1]) ;
                            Console.WriteLine("Enter Sensor Range: ");
                            double sensorRange = double.Parse(Console.ReadLine());
                            mission.AddSensor(sensorX, sensorY, sensorRange);
                            break;

                        case "c":
                        tryCameraLocAgain:
                            Console.WriteLine("Enter the location where the Camera: ");
                            var cameraStart = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(cameraStart[0], cameraStart[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryCameraLocAgain;
                            }
                            int cameraX = int.Parse(cameraStart[0]) ;
                            int cameraY = int.Parse(cameraStart[1]) ;
                            Console.WriteLine("Enter Camera Direction (North,East,West,South): ");
                            string cameraDirection = Console.ReadLine();
                            mission.AddCamera(cameraX, cameraY, cameraDirection);
                            break;

                        case "d":
                        trySaveDirCurAgain:
                            Console.WriteLine("Enter your current location (X,Y): ");
                            var currentLocation1 = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(currentLocation1[0], currentLocation1[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto trySaveDirCurAgain;
                            }
                            int startX1 = int.Parse(currentLocation1[0]) ;
                            int startY1 = int.Parse(currentLocation1[1]) ;

                            // Calculate the dimensions of the child matrix
                            mission.gridTopLeftX = int.Parse(currentLocation1[0]) - 1000;
                            mission.gridTopLeftY = int.Parse(currentLocation1[1]) - 1000;
                            mission.gridBottomRightX = int.Parse(currentLocation1[0]) + 1000;
                            mission.gridBottomRightY = int.Parse(currentLocation1[1]) + 1000;

                            mission.gridXSize = (mission.gridBottomRightX > mission.gridTopLeftX ? (mission.gridBottomRightX - mission.gridTopLeftX) : (mission.gridTopLeftX - mission.gridBottomRightX)) ;
                            mission.gridYSize = (mission.gridBottomRightY > mission.gridTopLeftY ? (mission.gridBottomRightY - mission.gridTopLeftY) : (mission.gridTopLeftY - mission.gridBottomRightY)) ;

                            mission.missionGrid = new char[mission.gridXSize, mission.gridYSize];
                            mission.AddHurdlesInGrid(mission.gridTopLeftX, mission.gridTopLeftY);

                            mission.GetSafeDirections(startX1 - mission.gridTopLeftX, startY1 - mission.gridTopLeftY);

                            break;

                        case "m":
                        tryabstacleMapXAgain:
                            Console.WriteLine("Enter the location of the top-left cell of the map (X,Y): ");
                            var topLeftCellLocation = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(topLeftCellLocation[0], topLeftCellLocation[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryabstacleMapXAgain;
                            }
                            int topLeftCellX = int.Parse(topLeftCellLocation[0]) ;
                            int topLeftCellY = int.Parse(topLeftCellLocation[1]) ;
                            mission.gridTopLeftX = topLeftCellX;
                            mission.gridTopLeftY = topLeftCellY;
                            tryabstacleMapYAgain:
                            Console.WriteLine("Enter the location of the bottom-right cell of the map (X,Y): ");
                            var bottomRightCellLocation = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(bottomRightCellLocation[0], bottomRightCellLocation[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto tryabstacleMapYAgain;
                            }
                            int bottomRightCellX = int.Parse(bottomRightCellLocation[0]) ;
                            int bottomRightCellY = int.Parse(bottomRightCellLocation[1]) ;

                            // Calculate the dimensions of the child matrix
                            mission.gridTopLeftX = int.Parse(topLeftCellLocation[0]) - 1000;
                            mission.gridTopLeftY = int.Parse(topLeftCellLocation[1]) - 1000;
                            mission.gridBottomRightX = int.Parse(topLeftCellLocation[0]) + 1000;
                            mission.gridBottomRightY = int.Parse(topLeftCellLocation[1]) + 1000;

                            mission.gridXSize = (mission.gridBottomRightX > mission.gridTopLeftX ? (mission.gridBottomRightX - mission.gridTopLeftX) : (mission.gridTopLeftX - mission.gridBottomRightX));
                            mission.gridYSize = (mission.gridBottomRightY > mission.gridTopLeftY ? (mission.gridBottomRightY - mission.gridTopLeftY) : (mission.gridTopLeftY - mission.gridBottomRightY));

                            mission.missionGrid = new char[mission.gridXSize, mission.gridYSize];
                            mission.AddHurdlesInGrid(mission.gridTopLeftX, mission.gridTopLeftY);

                            mission.DisplayObstacleMap(topLeftCellX - mission.gridTopLeftX, topLeftCellY - mission.gridTopLeftY, bottomRightCellX - mission.gridTopLeftX, bottomRightCellY - mission.gridTopLeftY);
                            break;

                        case "p":
                        trySavePathCurrAgain:
                            Console.WriteLine("Enter your current location (X,Y): ");
                            var currentLocation = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(currentLocation[0], currentLocation[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto trySavePathCurrAgain;
                            }
                            int startX = int.Parse(currentLocation[0]) ;
                            int startY = int.Parse(currentLocation[1]) ;
                        trySavePathObjAgain:
                            Console.WriteLine("Enter the location of your objective (X,Y): ");
                            var objectiveLocation = Console.ReadLine().Split(",");
                            if (!mission.IsValidInput(objectiveLocation[0], objectiveLocation[1]))
                            {
                                Console.WriteLine("Invalid Input.");
                                goto trySavePathObjAgain;
                            }
                            int targetX = int.Parse(objectiveLocation[0]) ;
                            int targetY = int.Parse(objectiveLocation[1]) ;

                            // Calculate the dimensions of the child matrix
                            mission.gridTopLeftX = int.Parse(currentLocation[0]) - 1000;
                            mission.gridTopLeftY = int.Parse(currentLocation[1]) - 1000;
                            mission.gridBottomRightX = int.Parse(objectiveLocation[0]) + 1000;
                            mission.gridBottomRightY = int.Parse(objectiveLocation[1]) + 1000;

                            mission.gridXSize = (mission.gridBottomRightX > mission.gridTopLeftX ? (mission.gridBottomRightX - mission.gridTopLeftX) : (mission.gridTopLeftX - mission.gridBottomRightX)) ;
                            mission.gridYSize = (mission.gridBottomRightY > mission.gridTopLeftY ? (mission.gridBottomRightY - mission.gridTopLeftY) : (mission.gridTopLeftY - mission.gridBottomRightY)) ;

                            mission.missionGrid = new char[mission.gridXSize, mission.gridYSize];
                            mission.AddHurdlesInGrid(mission.gridTopLeftX, mission.gridTopLeftY);

                            mission.GetSafePath(startX - mission.gridTopLeftX, startY - mission.gridTopLeftY, targetX - mission.gridTopLeftX, targetY - mission.gridTopLeftY);
                            break;

                        case "x":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong.");
                goto DoAgain;
            }
        }
    }
}