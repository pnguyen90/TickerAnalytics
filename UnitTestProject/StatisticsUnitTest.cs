﻿using System;
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

            var results = Statistics.k_means(coords,3);
            int cluster_length = results.Count;


            Assert.AreEqual(cluster_length, 3, 0.001, "cluster length incorrect");
        }

        [TestMethod]
        public void correlationTest()
        {
            decimal[] vector1 = { 1, 2, 3, 4, 5, 6 };
            decimal[] vector2 = { 5, 1 / 3, 6, 7, 8, 9 };
            var result1 = (double)Statistics.correlation(vector1, vector1);
            var result2 = (double)Statistics.correlation(vector1, vector2);
            Assert.AreEqual(result1, 1, 0.001, "correlation of array with itself should be 1");

        }
    }
}