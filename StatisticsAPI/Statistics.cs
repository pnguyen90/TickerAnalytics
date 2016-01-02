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
        //computes the normalized correlation of two arrays of numbers.
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

        private static decimal dotProduct(decimal[] a, decimal[] b)
        {
            decimal scalar = 0;

            for (int i = 0; i < a.Length ; i+= 1)
            {
                scalar  += a[i] * b[i];
            }
            return scalar;
        }
    }
}
