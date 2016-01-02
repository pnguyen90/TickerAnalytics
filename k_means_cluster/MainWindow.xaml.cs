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

            var data = new Object[tickers.Length];
            for (int i = 0; i < tickers.Length; i++)
            {
                data[i] = tickers[i];
            }
            // Handles creation of excel workbook and loads the data all at once
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            var startCell = ws.Cells[1, 1];
            var endCell = ws.Cells[1, tickers.Length];
            var writeRange = ws.Range[startCell, endCell];

            writeRange.Value2 = data;
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;


        }

        

       

    }
}
