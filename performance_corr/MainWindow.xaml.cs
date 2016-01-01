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
using Microsoft.Office.Interop.Excel;
using System.Collections;
using DatabaseAPI;
using StatisticsAPI;


namespace performance_corr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Generates stock correlation matrix from user input params: tickers and daterange
        private void GenerateExcelFile(object sender, RoutedEventArgs e)
        {
            //parsing and loading user input data for further processing
            string ticker = Tickers.Text;
            char[] delimit = {','};

            string[] tickerArray = ticker.Split(delimit);
            DateTime start = Date1.DisplayDate;
            DateTime end = Date2.DisplayDate;
            
         

            //creating the correlation matrix and storing it in var data
            int rows = tickerArray.Length + 1;
            int columns = rows;
            var data = new object[rows, columns]; 
            //matrix is filled in row by row
            for (var row = 1; row <= rows; row++)
            {
                //first row is all ticker headers
                if (row == 1)
                {
                    for (var column = 1; column <= columns; column++)
                    {
                        if (column > 1)
                        {
                            data[row - 1, column - 1] = tickerArray[column - 2];
                        }
                    }
                }
                else
                //all other rows contain correlation coefficents
                {
                    for (var column = 1; column <= columns; column++)
                    {
                        if (column == 1)
                        {
                            data[row - 1, column - 1] = tickerArray[row - 2];
                        }
                            //makes gets price data through DbAPI
                            //Then uses statsAPI to get coefficent
                        else if (column >= row)
                        {
                            
                            ArrayList stock1 = DBobject.getPriceArray(tickerArray[row - 2], start, end);
                            ArrayList stock2 = DBobject.getPriceArray(tickerArray[column - 2], start, end);
                            decimal coefficient = Statistics.correlation(stock1, stock2);
                             
                            data[row - 1, column - 1] = coefficient;
                        }
                    }
                }
            }

            // Handles creation of excel workbook and loads the data all at once
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            var startCell = ws.Cells[1, 1];
            var endCell = ws.Cells[rows, columns];
            var writeRange = ws.Range[startCell, endCell];

            writeRange.Value2 = data;
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;
            wb.SaveAs(@"C:\Experiment\practice.xlsx");
        }

    }
}
