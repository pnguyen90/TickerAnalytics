using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticsAPI;

namespace UnitTestProject
{
    [TestClass]
    public class StatisticsUnitTest
    {
        [TestMethod]
        public void k_meansTest()
        {
            Tuple<decimal, decimal> point1 = new Tuple<decimal,decimal>(10,10);
            Tuple<decimal, decimal> point2 = new Tuple<decimal,decimal>(-10,10);
            Tuple<decimal, decimal> point3 = new Tuple<decimal,decimal>(-10,-10);

            Tuple<decimal, decimal> point4 = new Tuple<decimal,decimal>(9,10);
            Tuple<decimal, decimal> point5 = new Tuple<decimal,decimal>(-9,10);
            Tuple<decimal, decimal> point6 = new Tuple<decimal,decimal>(-9,-10);

            Tuple<decimal, decimal> point7 = new Tuple<decimal,decimal>(10,9);
            Tuple<decimal, decimal> point8 = new Tuple<decimal,decimal>(-10,9);
            Tuple<decimal, decimal> point9 = new Tuple<decimal,decimal>(-10,-9);

            Tuple<decimal, decimal> point10 = new Tuple<decimal,decimal>(8,9);
            Tuple<decimal, decimal> point11 = new Tuple<decimal,decimal>(-8,9);
            Tuple<decimal, decimal> point12 = new Tuple<decimal,decimal>(-8,-9);
            Tuple<decimal, decimal>[] coords = {point1, point2, point3, point12, point9, point6, point11, point8, point5, point4, point7,point10};

            Tuple<decimal, decimal> centroid1 = new Tuple<decimal, decimal>(Convert.ToDecimal(9.25), Convert.ToDecimal(9.5));
            var results = Statistics.k_means(coords,3);
            int cluster_length = results.Count;

            Assert.AreEqual(cluster_length, 3, 0.001, "Dictionary length incorrect.");
            Assert.AreEqual(results[centroid1].Length, 4, "Cluster length incorrect.");
        }

        [TestMethod]
        public void correlationTest()
        {
            decimal[] vector1 = { 1, 2, 3, 4, 5, 6 };
            decimal[] vector2 = { 5, Convert.ToDecimal(1) / Convert.ToDecimal(3), 6, 7, 8, 9 };
            decimal[] vector_inverse1 = { 1, 2, 3, -4, 5, 6 };
            decimal[] vector_inverse2 = { -1, -2, -3, 4, -5, -6 };
            double result1 = (double)Statistics.correlation(vector1, vector1);
            double result2 = (double)Statistics.correlation(vector1, vector2);
            double negative = (double)Statistics.correlation(vector_inverse1, vector_inverse2);
            Assert.AreEqual(1, result1, .001, "correlation of array with itself should be 1");
            Assert.AreEqual(.956, result2, 0.001, "Correlation is not accurate within tolerance of .01");
            Assert.AreEqual(-1, negative, .001, "Correlation should be -1");

        }

        //tested all the private methods on CoderPad

    }
}
