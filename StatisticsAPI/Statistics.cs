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
        public static Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]> k_means(Tuple<decimal,decimal>[] coordinates, int k)
        {
            Tuple<decimal, decimal>[] centroids_new = new Tuple<decimal, decimal>[k];
            Tuple<decimal, decimal>[] centroids_old = new Tuple<decimal, decimal>[k];
            ArrayList[] clusters = new ArrayList[k];
         
            
            //load up centroids with first k elements of coodinates and makes k containers
            
            for (int i = 0; i < k; i++)
            {
                centroids_new[i] = coordinates[i];

            }
            //sort tuples into the k containers based on distance from centroids. suggests that the k arrays need to be lists.
            while (!centroids_new.Equals(centroids_old))
            {
                //make sure clusters is cleared
                clusters = new ArrayList[k];
                //cluster points based on current centroids
                foreach (Tuple<decimal, decimal> point in coordinates)
                {
                    decimal[] dis_to_centroids = new decimal[k];
                    for (int j = 0; j < k; j++)
                    {
                        dis_to_centroids[j] = distance(point, centroids_new[j]);
                    }
                    int index = minValue(dis_to_centroids);
                    clusters[index].Add(point);
                }
                
                //store current centroid values into centroids_old
                centroids_old = centroids_new;

                //update centroids based on clusters
                int count = 0;
                foreach (ArrayList cluster in clusters)
                {
                    Tuple<decimal, decimal>[] clust = new Tuple<decimal, decimal>[cluster.Count];
                    cluster.CopyTo(clust);
                    centroids_new[count] = compute_centroid(clust);
                    count += 1;
                }
                
            }

            //when we are done clustering, convert everything to a dictionary
            

            Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]> result = new Dictionary<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]>(k);

            for (int i = 0; i < k; i++)
            {
                Tuple<decimal, decimal>[] value = new Tuple<decimal, decimal>[clusters[m].Count];
                clusters[i].CopyTo(value);
                result[centroids_new[i]] = value;
            }
            
            return result;
           
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
        private static Tuple<decimal,decimal> compute_centroid(Tuple<decimal,decimal>[] coordinates)
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
            double squared_distance_d = (double)squared_distance;
            double distance_d = Math.Sqrt(squared_distance_d);
            decimal distance = Convert.ToDecimal(distance_d);
            return distance;
        }

        //returns the index of minium value in array of decimals
        private static int minValue(decimal[] numbers)
        {
            int count = 0;
            int index = 0;
            decimal minv = 0;

            foreach (decimal value in numbers)
            {
                if (value < minv)
                {
                    minv = value;
                    index = count;
                }
                count += 1;

            }

            return index;
        }


    }
}
