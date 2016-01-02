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
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace k_means_cluster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> tickers;
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
                string[] lines;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Array value = line.Split(',');
                    ArrayList temp = new ArrayList(value);
                    
                }
            }

        }

        

        //get clusters button will create clusters in excel 

    }
}
