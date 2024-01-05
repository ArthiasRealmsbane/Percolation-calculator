public class Visualization
{
    /// <summary>
    /// Helper method that draws the top line for the grid visualization
    /// </summary>
    /// <param name="dimension">grid dimension</param>
    static void DrawTopLine(int dimension)
    {
        DrawLine(dimension, corner1: 0x250C, middle: 0x252C, corner2: 0x2510);
    }
    /// <summary>
    /// Helper method that draws the bottom line for the grid visualization
    /// </summary>
    /// <param name="dimension">grid dimension</param>
    static void DrawBottomLine(int dimension)
    {
        DrawLine(dimension, corner1: 0x2514, middle: 0x2534, corner2: 0x2518);
    }
    /// <summary>
    /// Helper method that draws a line of specific shape
    /// </summary>
    /// <param name="dimension">grid dimension</param>
    /// <param name="corner1">right corner symbol</param>
    /// <param name="middle">middle symbols</param>
    /// <param name="corner2">left corner symbol</param>
    static void DrawLine(int dimension, int corner1, int middle, int corner2)
    {
        Console.Write(Convert.ToChar(corner1));
        for (int i = 0; i < dimension - 1; i++)
        {
            Console.Write(Convert.ToChar(0x2500));
            Console.Write(Convert.ToChar(middle));
        }

        Console.Write(Convert.ToChar(0x2500));
        Console.Write(Convert.ToChar(corner2));
        Console.WriteLine();
    }
    /// <summary>
    /// Visualizes a given grid by printing it on the console
    /// A cell that is false is represented by x and a cell that is true
    /// by a square-like symbol depending on the colour
    /// </summary>
    /// <param name="grid">the NxN Boolean grid</param>
    /// <param name="colour">the default colour or green</param>
    public static void VisualizeGrid(bool[,] grid, string colour = "default")
    {
        int xDimension = grid.GetLength(0);
        int yDimension = grid.GetLength(1);


        //Console.OutputEncoding = Encoding.UTF8;    //extra safe guard  
        DrawTopLine(xDimension);
        for (int i = 0; i < xDimension; i++)
        {
            for (int j = 0; j < yDimension; j++)
            {
                Console.Write("|");
                if (grid[i, j] == true)
                    if (colour.ToLower() == "green")
                        Console.Write("\u001b[32m" + Convert.ToChar(0x2588) + "\u001b[0m"); //Unicode for █ 
                    else //the default colour
                        Console.Write(Convert.ToChar("\u2588"));
                else
                    Console.Write("x");
            }
            Console.Write("|");
            Console.WriteLine();
        }
        DrawBottomLine(xDimension);
    }
    /// <summary>
    /// Visualizes a complete grid combining the original grid (where true 
    /// means open and false means blocked cells) and a fullColoured grid 
    /// (where true means a full cell and false means a blocked or open 
    /// cell that is not full). 
    /// </summary>
    /// <param name="grid">the original NxN Boolean grid</param>
    /// <param name="fullColoured">
    /// an NxN grid where true means a full cell, and false means a blocked cell or
    /// open cell that is not full
    /// </param>
    /// <exception cref="Exception">thrown if the two grids are mismatched</exception>
    public static void VisualizeProcessedGrid(bool[,] grid, bool[,] fullColoured)
    {
        int xDimension;
        int yDimension = xDimension = grid.GetLength(0);
        if (xDimension != fullColoured.GetLength(0)) //extra safe guard for future changeability
            throw new Exception("The two grids are not the same size");

        //Console.OutputEncoding = Encoding.UTF8;   //extra safe guard 
        DrawTopLine(xDimension);
        for (int i = 0; i < xDimension; i++)
        {
            for (int j = 0; j < yDimension; j++)
            {
                Console.Write("|");
                if (fullColoured[i, j] == true) //full: visualize by a green square
                    Console.Write("\u001b[32m" + Convert.ToChar(0x2588) + "\u001b[0m"); //Unicode for █ 
                else if (grid[i, j] == true) //open but not full: visualize by a white square
                    Console.Write(Convert.ToChar(0x2588)); //Unicode for ░ 
                else //blocked: visualilze by an x
                    Console.Write("x");
            }
            Console.Write("|");
            Console.WriteLine();
        }
        DrawBottomLine(xDimension);

    }
}