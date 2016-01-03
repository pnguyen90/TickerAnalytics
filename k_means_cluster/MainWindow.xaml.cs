using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DatabaseAPI;
using StatisticsAPI;


namespace k_means_cluster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private static string[] tickers;
        private static string userfilepath;

        public MainWindow()
        {
            InitializeComponent();
        }

        //upload file button will load csv into tickers and change button text to "Received"
        private void handleFileInput(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "CSV Files(*.csv)|*.csv|All files (*.*)|*.*";

            DialogResult result = dlg.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dlg.FileName;
                filepath.Text = filename;
                userfilepath = filename;
                var reader = new StreamReader(File.OpenRead(@userfilepath));
                var line = reader.ReadLine();
                tickers = line.Split(',');
            }

        }


       
        //getClusters button will create clusters in excel 
        private void getClusters(object sender, RoutedEventArgs e)
        {

            DateTime d1 = date1.DisplayDate;
            DateTime d2 = date2.DisplayDate;
            string x_ticker = xcoor.Text;
            string y_ticker = ycoor.Text;
            decimal[] x_vector = DBobject.getPriceArray(x_ticker, d1,d2);
            decimal[] y_vector = DBobject.getPriceArray(y_ticker, d1,d2);
            int k = int.Parse(k_param.Text);

            //generate numerical points from ticker symbols. Encode points to tickers so we can translate back.
            Dictionary<Tuple<decimal, decimal>, string> tuple_ticker = new Dictionary<Tuple<decimal, decimal>, string>(tickers.Length);
            Tuple<decimal,decimal>[] ticker_coords = new Tuple<decimal,decimal>[tickers.Length];

            int count = 0;
            foreach (string symbol in tickers)
            {
                decimal[] price_vector = DBobject.getPriceArray(symbol, d1, d2);
                decimal x = Statistics.correlation(x_vector, price_vector);
                decimal y = Statistics.correlation(y_vector, price_vector);
                Tuple<decimal,decimal> point = new Tuple<decimal, decimal>(x,y);
                ticker_coords[count] = point;
                tuple_ticker[point] = symbol;
                count += 1;
            }
            // cluster the data
            Dictionary<Tuple<decimal, decimal>, Tuple<decimal, decimal>[]> result = Statistics.k_means(ticker_coords, k);

            //re_translate the numerical data back to ticker symbols. 
            //format our data object to be ready for excel
            //each cluster will fill a column. first two rows of each 
            // column will be x and y coordinate of cluster centroid
            var data = new object[tickers.Length + 2, k];

            int i = 2;
            int j = 0;
            foreach(KeyValuePair<Tuple<decimal,decimal>, Tuple<decimal,decimal>[]> entry in result)
            {
                data[0, j] = entry.Key.Item1;
                data[1, j] = entry.Key.Item2;
                
                foreach (Tuple<decimal,decimal> p in entry.Value)
                {
                    data[i, j] = tuple_ticker[p];
                    i += 1;
                }
                j += 1;
                i = 2;
            }

            // Handles creation of excel workbook and loads the data all at once
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            var startCell = ws.Cells[1, 1];
            var endCell = ws.Cells[tickers.Length + 2, k];
            var writeRange = ws.Range[startCell, endCell];

            writeRange.Value2 = data;
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;


        }

        

       

    }
}
