using System;
public class MonteCarloSimulation
{
    /// <summary>
    /// Estimates and returns the percolation probability using the Monte Carlo method
    /// </summary>
    /// <param name="dimension">the grid dimension (each sides of a square two-dimensional grid)</param>
    /// <param name="probability">probability of vacancy</param>
    /// <param name="numOfTrials">number of simulation/trials</param>
    /// <returns>the estimated percolation probability</returns>
    public static double Estimate(int dimension, double probability, int numOfTrials)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException("n must be a positive number.");
        }
        int possiblePercolation = 0;                     ///initially count is 0

        for (int trial = 0; trial < numOfTrials; trial++)          ///loops as long as total number of trials instructs
        {
            bool[,] grid = RandomGridGenerator.Generate(dimension, probability);                 ///generates grid according to dimensions and vacancy probability


            if (Percolation.IsPercolating(grid))                      ///Checks if Percolation is possible
            {
                possiblePercolation++;                                 ///If yes,adds 1 to the count

            }
        }
        double estimate = (double)possiblePercolation / numOfTrials;                  ///calculates the probability by dividing the count with number of total trials

        return estimate;                                 ///returns the estimated probability of percolation


    }
}