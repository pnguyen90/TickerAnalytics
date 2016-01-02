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
        private static Tuple<decimal,decimal> centroid(Tuple<decimal,decimal> coordinates)
        {
            Tuple<decimal,decimal> sample = new Tuple<decimal,decimal>(5,5);
            return sample;

        }

        //returns the distance between two coordinates. For internal use.
        private static decimal distance(Tuple<decimal,decimal> point1, Tuple<decimal,decimal> point2)
        {
            decimal sample = 5;
            return sample;
        }

    }
}
