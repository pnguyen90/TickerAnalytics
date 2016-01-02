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

            //compute the dot product of a with itself ---> a.a

            //compute the dot produc of b with itself ----> b.b

            // compute the squareroot of (a.a)*(b.b) ---->c

            // return (a.b)/c
  

            decimal c = 0;
            return c;
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
