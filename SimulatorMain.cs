using System;

namespace Simulation
{
    class SimulationMain
    {             
        public static void Main()
        {
            int dimension = 3;  //initial grid dimension
            double vacancyProbability = 0.593; //initial vacancy probability
            int numOfTrials = 100;  //initial num of trials for MC
            bool[,] grid = new bool[3, 3]  //initial default grid;
                                           //also helpful for initial testing considering a specific grid 
            
            {
                { false, false, false},
                { false, false, false},
                { true, true, false}
            };


            while (true)

            {
                Console.WriteLine("Select from this menu :");
                Console.WriteLine("Grid parameters: di(m)ension, (v)acancy probability, (n)um of trials, (g)et parameters");
                Console.WriteLine("Single grid: (c)reate a grid, (d)isplay, (p)ercolate");
                Console.WriteLine("Monte Carlo: start Mon(t)e Carlo simulation");
                Console.WriteLine("Quit: (q)uit");
                Console.Write("\nYour choice: ");
                string choice;
                string result = "";
                try
                {
                    choice = Console.ReadLine().Trim().ToLower();
                }
                catch (Exception)
                {
                    Console.WriteLine($"IO error");
                    continue;
                }

                //if user enters m allows user to modify dimension of grid 
                if (choice.StartsWith("m"))
                {
                   
                    Console.WriteLine("Please enter the new dimension for the grid:");
                    if (GetInt(out int newDimension, 1,100, ref result))
                    {

                        dimension = newDimension;
                        Console.WriteLine($"New updated grid dimension is {dimension}");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }


                }

                //If user enters m allows user to modify vacancy probability 
                else if (choice.StartsWith("v"))
                {
                    Console.WriteLine("Please enter the new vacancy probability (between 0 and 1):");
                    if (GetDouble(out vacancyProbability, 0.0, 1.0, ref result))
                    {
                        Console.WriteLine("Vacancy probability updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }

                //If user enters d generates a default grid 
                else if (choice.StartsWith("d"))
                {
                    Visualization.VisualizeGrid(grid);
                }

                //If user enters p makes a duplicate of initial grid 
                else if (choice.StartsWith("p"))
                {
                    bool[,] grid1 = (bool[,])grid.Clone(); //Makes duplicate grid 

                    Visualization.VisualizeGrid(grid);
                    bool[,] infiltratedGrid = Percolation.Infiltrate(grid); 
                    bool percolation = Percolation.IsPercolating(infiltratedGrid);

                    //If grid percolates, the percolated grid is displayed 
                    if (percolation)
                    {
                        bool[,] percolatedGrid = Percolation.Infiltrate(grid); 
                        Visualization.VisualizeProcessedGrid(grid, percolatedGrid); // Displays percolated grid
                        Console.WriteLine("The grid percolates!");
                    }
                    else
                    {
                        Visualization.VisualizeGrid(grid1); //initial grid instead of infiltrated grid is displayed 
                        Console.WriteLine("The grid does not percolate.");
                    }

                    // Check for green squares in grid that is displayed
                    bool Greensquare = false;
                    for (int i = 0; i < grid.GetLength(0); i++)
                    {
                        for (int j = 0; j < grid.GetLength(1); j++)
                        {
                            if (grid[i, j])
                            {
                                Greensquare = true;
                                break;
                            }
                        }
                        if (Greensquare) break;
                    }


                    if (!Greensquare) //If there are green squares present, displays them on the grid 
                    {
                        Visualization.VisualizeGrid(grid1);
                    }

                }

                //Generates a random grid of dimensions specified with open and closed cell boxes.
                else if (choice.StartsWith("c"))
                {

                    //generates the random grid
                    grid = RandomGridGenerator.Generate(dimension, vacancyProbability);

                    

                    // Display the grid
                    Visualization.VisualizeGrid(grid);

                  

                }


                //Displays current dimension, vacancy probability, and no. of trials for the grid 
                else if (choice.StartsWith("g"))
                {
                    Console.WriteLine($"Current dimension: {dimension}");
                    Console.WriteLine($"Current vacancy probability: {vacancyProbability}");
                    Console.WriteLine($"Current number of trials: {numOfTrials}");
                }

                //Runs Monte Carlo simulation approach and comes up with estimated percolation probability
                else if (choice.StartsWith("t"))
                {

                    Console.WriteLine($"Monte Carlo Simulation initializing with {numOfTrials} trials...");

                    // Runs the Monte Carlo simulation
                    double estimatedPercolationProbability = MonteCarloSimulation.Estimate(dimension, vacancyProbability, numOfTrials);
                    int percolatedCount = (int)(estimatedPercolationProbability * numOfTrials);

                    Console.WriteLine($"{percolatedCount} Percolates out of {numOfTrials}");

                    Console.WriteLine($"Percolation probability is {estimatedPercolationProbability}");
                }


                //If user enters n, user can modify number of trials 
                else if (choice.StartsWith("n"))
                {
                    Console.WriteLine("Enter the number of trials:");
                    if (GetInt(out numOfTrials, 1, int.MaxValue, ref result))
                    {
                        Console.WriteLine($"Number of trials set to: {numOfTrials}");
                    }
                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                    }
                }

                //If user enters q the program breaks 
                else if (choice.StartsWith("q"))
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }

            }




            }


            /// <summary>
            /// Gets an int from the command line within the range [min, max]. 
            /// If the provided num is not acceptable, str will contain an error message.
            /// </summary>
            /// <param name="num">Nummber received from the user and returned through the out argument.</param>
            /// <param name="min">Min acceptable range for num.</param>
            /// <param name="max">Max acceptable range for num.</param>
            /// <param name="str">Contains an error message if not successful.</param>
            /// <returns>true if successful, false otherwise.</returns>
            static bool GetInt(out int num, int min, int max, ref string str)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out num))
                {
                    if (num >= min && num <= max)
                    {
                        return true;
                    }
                    str = "Number outside range";
                }
                else
                {
                    str = "Not an acceptable number";
                }
                return false;
            }
            /// <summary>
            /// Gets a double from the command line within the range [min, max]. 
            /// If the provided num is not acceptable, str will contain an error message.
            /// </summary>
            /// <param name="num">Number received from the user and returned through the out argument.</param>
            /// <param name="min">Min acceptable range for num.</param>
            /// <param name="max">Max acceptable range for num.</param>
            /// <param name="str">Contains an error message if not successful.</param>
            /// <returns>true if successful, false otherwise.</returns>
            static bool GetDouble(out double num, double min, double max, ref string str)
            {
                if (double.TryParse(Console.ReadLine().Trim(), out num))
                {
                    if (num >= min && num <= max)
                    {
                        return true;
                    }
                    str = "Number outside range";
                }
                else
                {
                    str = "Not an acceptable number";
                }
                return false;
            }


        }  

    }
