using System;

public class RoutePlanner
{
    public int toRow;
    public int toColumn;
    public bool[,] mapMatrix;
    public bool[,] visitedMatrix;
    public RoutePlanner(int _toRow, int _toColumn, bool[,] _mapMatrix)
    {
        toRow = _toRow;
        toColumn = _toColumn;
        mapMatrix = _mapMatrix;
        visitedMatrix = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];
    }
    public bool UncheckedRoad(int rowToCheck, int colToCheck)
    {
        // Check if the dimensions exist within the mapMatrix bounds
        if (rowToCheck >= 0 && colToCheck >= 0 && rowToCheck < this.mapMatrix.GetLength(0) && colToCheck < this.mapMatrix.GetLength(1))
        {
            // Check if there is a road there that hasn't been visited
            if (mapMatrix[rowToCheck, colToCheck] && !visitedMatrix[rowToCheck, colToCheck])
            {
                // Valid unchecked road found
                return true;
            }
        }
        // Dimensions do not represent a valid unchecked road
        return false;
    }
    public bool TraversePath(int currentRow, int currentCol)
    {
        // Check if the currentRoad doesn't exist or is visited already
        if (!this.UncheckedRoad(currentRow, currentCol))
        {
            return false;
        }
        // Check if the target has been found
        if (currentRow == this.toRow && currentCol == this.toColumn)
        {
            return true;
        }
        // Mark road as visited
        this.visitedMatrix[currentRow, currentCol] = true;

        // Return the result of the traversal of the four path options (Up, Right, Down, Left)
        return (this.TraversePath(currentRow - 1, currentCol)) ||
                (this.TraversePath(currentRow, currentCol + 1)) ||
                (this.TraversePath(currentRow + 1, currentCol)) ||
                (this.TraversePath(currentRow, currentCol - 1));
    }
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn, bool[,] mapMatrix)
    {
        // Instantiate a new RoutePlanner object with target and mapMatrix
        RoutePlanner routePlanner = new RoutePlanner(toRow, toColumn, mapMatrix);
        // Find the destination if it exists
        return routePlanner.TraversePath(fromRow, fromColumn);
    }

    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };

        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}