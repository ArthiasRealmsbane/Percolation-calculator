using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    [TestClass()]


    public class MonteCarloSimulationTests
    {
        [TestMethod()]
        public void Estimate_PerfectGrid_ReturnsOne()
        {
            // Arrange
            int dimension = 5;
            double probability = 1.0;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.AreEqual(1.0, result, 0.01, "For a perfect grid, percolation probability should be 1.0");
        }

        [TestMethod()]
        public void Estimate_EmptyGrid_ReturnsZero()
        {
            // Arrange
            int dimension = 10;
            double probability = 0.0;
            int numOfTrials = 200;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.AreEqual(0.0, result, 0.01, "For an empty grid, percolation probability should be 0.0");
        }

        [TestMethod()]
        public void Estimate_InvalidDimension_ThrowsArgumentException()
        {
            // Arrange
            int dimension = -5; // Invalid dimension

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => MonteCarloSimulation.Estimate(dimension, 0.5, 100));
        }
        [TestMethod()]
        public void Estimate_EmptyGrid_ReturnsZero2()
        {
            // Arrange
            int dimension = 10;
            double probability = 0.0;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.AreEqual(0.0, result, 0.01, "For an empty grid, percolation probability should be 0.0");
        }
        [TestMethod()]
        public void Estimateo()
        {
            // Arrange
            int dimension = 10;
            double probability = 0.2;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.IsTrue(result >= 0 && result <= 0.5);
        }
        [TestMethod()]
        public void Estimateo3()
        {
            // Arrange
            int dimension = 10;
            double probability = 0.9;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.IsTrue(result >= 0.5 && result <= 1.0);
        }
        [TestMethod()]
        public void Estimateo2()
        {
            // Arrange
            int dimension = 10;
            double probability = 0.9;
            int numOfTrials = 1;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.IsTrue(result >= 0.6 && result <= 1.0);
        }
        [TestMethod()]
        public void Estimateo4()
        {
            // Arrange
            int dimension = 100;
            double probability = 0.9;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.IsTrue(result >= 0.8 && result <= 1.0);
        }

        [TestMethod()]
        public void Estimateo6()
        {
            // Arrange
            int dimension = 1;
            double probability = 0.9;
            int numOfTrials = 100;

            // Act
            double result = MonteCarloSimulation.Estimate(dimension, probability, numOfTrials);

            // Assert
            Assert.IsTrue(result >= 0.8 && result <= 1.0);
        }

    }
}
