
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class PercolationTests
    {

        [TestMethod()]

        public void InfiltrateTest1()
        {
            // Arrange
            int rows = 3;
            int cols = 3;
            bool[,] newEmptyGrid = new bool[rows, cols];

            // Act
            bool[,] infiltratedGrid = Percolation.Infiltrate(newEmptyGrid);

            // Assert
            // Checks if the infiltrated grid has the same dimensions as the original grid
            Assert.AreEqual(newEmptyGrid.GetLength(0), infiltratedGrid.GetLength(0));
            Assert.AreEqual(newEmptyGrid.GetLength(1), infiltratedGrid.GetLength(1));

            // Checks that for each element in newEmptyGrid, the infiltrated Grid should return false.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (newEmptyGrid[i, j])
                    {
                        Assert.IsFalse(infiltratedGrid[i, j]);
                    }
                }
            }
        }

        [TestMethod()]

        public void InfiltrateTest2()
        {
            //Arrange
            int rows = 3;
            int cols = 3;

            bool[,] newGrid = new bool[,]
            {
                {true, true, true },
                {true, true, true },
                {true, true, true }
            };

            //Act
            bool[,] check = Percolation.Infiltrate(newGrid);

            //Assert
            //Checks if the newly infiltrated grid has the same NxN dimensions as the original grid

            Assert.AreEqual(newGrid.GetLength(0), check.GetLength(0));
            Assert.AreEqual(newGrid.GetLength(1), check.GetLength((1)));

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {

                    //Checks that for each element in newEmptyGrid, the infiltrated Grid should return true 

                    if (newGrid[i, j])
                    {
                        Assert.IsTrue(check[i, j]);
                    }
                }
            }

        }

        [TestMethod()]

        public void InfiltrateTest3()
        {
            //Arrange
            int rows = 4;
            int cols = 4;

            bool[,] newGrid = new bool[,]
            {
                {true, false, true, false },
                {false, true, true, false },
                {true, true , false, true },
                {true, false, false, true }
            };


            //Act
            bool[,] check = Percolation.Infiltrate(newGrid);

            //Assert
            //Checks if the newly infiltrated grid has the same NxN dimensions as the original grid

            Assert.AreEqual(newGrid.GetLength(0), check.GetLength(0));
            Assert.AreEqual(newGrid.GetLength(1), check.GetLength((1)));

            bool[,] TestPositions = new bool[,]
             {
                 {true, false, true, false },
                 {false, true, true, false },
                 {true, true, false, false },
                 {true, false, false, false }
             };

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    // Checks if true filled cells identified by infiltrated Grid indeed match the expected outcome
                    Assert.AreEqual(TestPositions[i, j], check[i, j], "If the infiltrated position does not match the expected position");

                }

            }



        }

        [TestMethod()]

        public void InfiltrateTest4()
        {
            //Arrange
            int rows = 4;
            int cols = 4;

            bool[,] newGrid = new bool[,]
            {
                {true, false, true, false },
                {false, true, false, true },
                {true, false , true, false },
                {false, true, false, true }
            };

            //Act
            bool[,] check = Percolation.Infiltrate(newGrid);


            //Assert
            //Assert.AreEqual(check, newGrid, "Tests a grid where cells that are open are not connected to one another and are isolated. None of them should be filled ");

            //Checks if the newly infiltrated grid has the same NxN dimensions as the original grid

            //Assert.AreEqual(newGrid.GetLength(0), check.GetLength(0));
            //Assert.AreEqual(newGrid.GetLength(1), check.GetLength((1)));

            //TestPositions Grid made. True values in new Grid are Isolated hence none should be filled and expected outcomes should all be false. 


            bool[,] TestPositions = new bool[,]
             {
                {true, false, true, false },
                {false, false, false, false },
                {false, false, false, false },
                {false, false, false, false },
             };

            /* for (int i = 0; i < rows; i++)
             {

                 for (int j = 0; j < cols; j++)
                 {
                     // Checks if true filled cells identified by infiltrated Grid indeed match the expected outcome
                     Assert.AreNotEqual(TestPositions[i, j], check[i, j], "the infiltrated position does not match the expected position");

                 }          

             } */

            CollectionAssert.AreEqual(TestPositions, check, "the infiltrated position does not match the expected position");

        }

        [TestMethod()]
        public void IsPercolatingTest()
        {

            //Checks one top to bottom possible percolation path
            bool[,] TestGrid = new bool[,]
            {
                {false, true, false, false  },
                {false, true, false, false  },
                {false, true, false, false  },
                {false, true, false, false  }
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);
            Assert.IsTrue(perculatesOrNot == true);
        }

        [TestMethod()]

        public void IsPercolatingTest2()
        {
            //Checks when there are no possible paths
            bool[,] TestGrid = new bool[,]
            {
                {false, false, false, false  },
                {false, false, false, false  },
                {false, false, false, false  },
                {false, false, false, false  }
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);


            Assert.IsTrue(perculatesOrNot == false);
        }

        [TestMethod()]

        public void IsPercolatingTest3()
        {
            //Checks when all possible paths exists
            bool[,] TestGrid = new bool[,]
            {
                {true, true, true, true  },
                {true, true, true, true  },
                {true, true, true, true  },
                {true, true, true, true  }
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);

            Assert.IsTrue(perculatesOrNot == true);
        }

        [TestMethod()]

        public void IsPercolatingTest4()
        {
            //Checks grid with open cells but no possible paths 
            bool[,] TestGrid = new bool[,]
            {
                {true, true, true },
                {false, false, false },
                {false, false, false },
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);
            Assert.IsTrue(perculatesOrNot == false);
        }


        [TestMethod()]

        //Checks case with diagonals (Cutting corners not allowed in scope of project so checks for this)
        public void IsPercolatingTest5()
        {
            bool[,] TestGrid = new bool[,]
            {
                {true, false, false },
                {false, true, false },
                {false, false, true },
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);
            Assert.IsTrue(perculatesOrNot == false);
        }
        [TestMethod()]

        //Checks case with staircase 
        public void IsPercolatingTest6()
        {
            bool[,] TestGrid = new bool[,]
            {
                {true, false, false },
                {true, true, false },
                {false, true, false },
            };

            bool perculatesOrNot = Percolation.IsPercolating(TestGrid);
            Console.WriteLine("The outcome is" + perculatesOrNot);
            Assert.IsTrue(perculatesOrNot == true);
        }


    }
}