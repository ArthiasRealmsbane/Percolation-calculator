using Simulation;

public class Percolation
{

    // You are allowed to add reasonable helper method(s) to this class (only this class).

    /// <summary>
    /// Given a grid, it calculates and returns another grid of the same size
    /// where only open cell that can be filled remain true.
    /// All other cells must be false (i.e. cells that are blocked or open
    /// cells that are not full).
    /// The original grid must not be mutated.
    /// </summary>
    /// <param name="grid">
    /// an NxN Boolean grid (true means open and false means blocked)
    /// </param>
    /// <returns>another NxN Boolean grid</returns>
    public static bool[,] Infiltrate(bool[,] grid)
    {
        int gridSize = grid.GetLength(0); // Get grid size from row.

        bool[,] infiltratedGrid = new bool[gridSize, gridSize]; // Create new grid.

        for (int col = 0; col < gridSize; col++) // Iterate and infiltrate through each open cell in the first row.
        {
            if (grid[0, col])
            {
                InfiltrateHelper(grid, infiltratedGrid, 0, col); // Call helper method.
            }
        }

        return infiltratedGrid;
    }

    /// <summary>
    /// Given a grid, it calculates whether the grid percolates
    /// </summary>
    /// <param name="grid">
    /// an NxN Boolean grid (true means open and false means blocked)
    /// </param>
    /// <returns>true if percolates, false otherwise</returns>
    public static bool IsPercolating(bool[,] grid)
    {
        int gridSize = grid.GetLength(0); // Get grid size from row.

        bool[,] infiltratedGrid = Infiltrate(grid); // Create new grid.

        for (int col = 0; col < gridSize; col++)  // Check if any cell in the last row is open.
        {
            if (infiltratedGrid[gridSize - 1, col])
            {
                return true;
            }
        }

        return false;
    }

    // Helper method for recursive infiltration.
    private static void InfiltrateHelper(bool[,] grid, bool[,] infiltratedGrid, int row, int col)
    {
        int gridSize = grid.GetLength(0); // Get grid size from row.

        if (!(row >= 0 && row < gridSize && col >= 0 && col < gridSize) || !grid[row, col] || infiltratedGrid[row, col]) // Base case for if the cell is out of bounds of grid or blocked.
        {
            return;
        }

        infiltratedGrid[row, col] = true; // Change current cell as open.

        InfiltrateHelper(grid, infiltratedGrid, row - 1, col); // Recursively infiltrate above current cell.
        InfiltrateHelper(grid, infiltratedGrid, row + 1, col); // Recursively infiltrate below the current cell.
        InfiltrateHelper(grid, infiltratedGrid, row, col - 1); // Recursively infiltrate left of the current cell.
        InfiltrateHelper(grid, infiltratedGrid, row, col + 1); // Recursively infiltrate right of the current cell.
    }

}
