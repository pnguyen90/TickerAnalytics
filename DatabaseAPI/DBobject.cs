using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DatabaseAPI
{
    //a DBobject provides the minimum API needed to run the two WPF applications. 
    public class DBobject
    {
       
        //no constructor
        
        //method to retrieve an array of price (decimal) values given ticker and time range (inclusive)
        public static ArrayList getPriceArray(String ticker, DateTime start, DateTime end)
        {
            using (StocksEntities context = new StocksEntities())
            {
                //sql script to extract price
                var query = from record in context.TickerDatas
                            where
                                record.Ticker == ticker &&
                                record.Date >= start &&
                                record.Date <= end
              
                            select record.Price;

                Array priceArray = query.ToArray();
                ArrayList result = new ArrayList(priceArray);
                return result;
            }
        }

    }
}
