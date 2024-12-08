using System;
using System.Collections.Generic;
using System.Drawing;

interface IMission
{
    // definations for mission methods mission interface

    public int gridXSize { get; set; }
    public int gridYSize  { get; set; }
    public int gridTopLeftX  { get; set; }
    public int gridTopLeftY  { get; set; }
    public int gridBottomRightX  { get; set; }
    public int gridBottomRightY  { get; set; }
    public char[,] missionGrid { get; set; }

    public void AddHurdlesInGrid(int topLeftX,int topLeftY);
    public void DisplayObstacleMap(int topLeftCellX, int topLeftCellY, int bottomRightCellX, int bottomRightCellY);
    public void AddObstacle(int x, int y);
    public void AddFence(int x1, int y1, int x2, int y2);
    public void AddSensor(int x, int y, double range);
    public void DisplaySensorOnGrid();
    public void AddCamera(int x, int y, string direction);
    public List<Point> FindSafePath(int startX, int startY, int targetX, int targetY);
    public List<string> GetSafeDirections(int startX, int startY);
    public List<string> GetSafePath(int startX, int startY, int targetX, int targetY);
    public void MarkPathOnGrid(List<Point> path);
    public Boolean IsValidInput(string coorX, string coorY);
}
