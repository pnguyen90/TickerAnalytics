using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatisticsAPI
{
    public class Statistics
    {
        //returns the normalized correlation of two arrays of decimals.
        public static decimal correlation(decimal[] a, decimal[] b)
        {
            //compute dot product of a and b  ----> a.b
            decimal adotb = dotProduct(a, b);
            

            //compute the dot product of a with itself ---> a.a
            decimal adota = dotProduct(a, a);

            //compute the dot produc of b with itself ----> b.b
            decimal bdotb = dotProduct(b, b);

            // compute the squareroot of (a.a)*(b.b) ----> denom
            decimal denom = adota * bdotb;
            double denomd = (double)denom;
            double c = Math.Sqrt(denomd);
            denom = Convert.ToDecimal(c);

            // return (a.b)/denom
            return adotb / denom;
        }

        //first map array of tickers to an array of tuples.
            //create dictionary { tuple:TICKER }
            //create array of tuples
        //apply standard k-means clustering algorithm to tuples.
        //map the tuples back to tickers preserving clusters.
        public static Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]> k_means(Tuple<decimal,decimal>[] coordinates)
        {
            Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]> sample = new Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]>();
            Tuple<decimal,decimal> point = new Tuple<decimal,decimal>(5,5);
            Tuple<decimal,decimal>[] list = new Tuple<decimal,decimal>[1];
            list[0] = point;
            Tuple<decimal,decimal> centroid = new Tuple<decimal,decimal> (6,6);
            sample[centroid] = list;


            return sample;

           
        }

        //returns the dot product of two arrays of decimals. For internal use.
        private static decimal dotProduct(decimal[] a, decimal[] b)
        {
            decimal scalar = 0;

            for (int i = 0; i < a.Length ; i+= 1)
            {
                scalar  += a[i] * b[i];
            }
            return scalar;
        }

        //returns the centroid of an array of (x,y) coordinates. For internal use.
        private static Tuple<decimal,decimal> centroid(Tuple<decimal,decimal>[] coordinates)
        {
            decimal average_x;
            decimal average_y;
            decimal sum_x = 0;
            decimal sum_y = 0;
            decimal length = Convert.ToDecimal(coordinates.Length);
            for (int i = 0; i < coordinates.Length; i++)
            {
                sum_x += coordinates[i].Item1;
                sum_y += coordinates[i].Item2;
            }
            average_x = sum_x / length;
            average_y = sum_y / length;
            Tuple<decimal,decimal> result = new Tuple<decimal,decimal>(average_x,average_y);
            return result;

            

        }

        //returns the distance between two coordinates. For internal use.
        private static decimal distance(Tuple<decimal,decimal> point1, Tuple<decimal,decimal> point2)
        {
            decimal x_diff = point2.Item1 - point1.Item1;
            decimal y_diff = point2.Item2 - point1.Item1;
            decimal squared_distance = x_diff * x_diff + y_diff * y_diff;
            double squared_distance_d = double(squared_distance);
            double distance_d = Math.Sqrt(squared_distance_d);
            decimal distance = Convert.ToDecimal(distance_d);
            return distance;
        }

    }
}
