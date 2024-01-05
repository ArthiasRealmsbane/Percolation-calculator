
public class RandomGridGenerator
{
    /// <summary>
    /// Generates an dimension by dimension grid where each cell in 
    /// the grid is open (vacant) with the given probability 
    /// </summary> 
    /// <param name="dimension">the dimension of the grid</param>
    /// <param name="probability">the probability of vacancy</param>
    /// <returns></returns>
    public static bool[,] Generate(int dimension, double probability)
    {
        bool[,] grid = new bool[dimension, dimension];

        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                grid[i, j] = Bernoulli(probability);
            }
        }
        return grid;
    }            
    /// <summary>
    /// Based on the given probability of vacancy, decides whether the cell is to be open or blocked.
    /// </summary>
    /// <param name="probability">probability of vacancy</param>
    /// <returns>true if the cell is to be open, false otherwise</returns>
    /// <exception cref="ArgumentException">thrown if invalid probability</exception>
    public static bool Bernoulli(double probability)
    {
        if (1 < probability || probability < 0)
            throw new ArgumentException("Invalid probability value"); //extra safe guard for future changeability
        Random random = new Random();
        if (random.NextDouble() < probability)
            return true;
        return false;
    }
}