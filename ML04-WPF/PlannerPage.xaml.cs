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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace ML04_WPF
{
    /// <summary>
    /// Interaction logic for PlannerPage.xaml
    /// </summary>
    public partial class PlannerPage : Window
    {
        private static string sPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public static class ContractInfo
        {
            public static string OrderID { get; set; }
            public static string Customer { get; set; }
            public static string StartLoc { get; set; }
            public static string EndLoc { get; set; }
        }

        public PlannerPage()
        {
            InitializeComponent();

            string userName = MainWindow.userLogIn.userID;

            userLbl.Content = userName;
        }

        private void SendOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter swExtLogFile = new StreamWriter(sPath + "/AllTimeInvoice.txt", true);
            DataTable dt2 = new DataTable();

            string myConnectionString;
            myConnectionString = "server=localhost;uid=SQUser;pwd=SQUser;database=mssqdatabase";

            dt2 = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM orders where completed = false";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt2);
            }

            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("\nAll Time Invoice\n");
            swExtLogFile.Write("Order ID | Customer | Start | End | Trip | Completed\n");
            int i;
            foreach (DataRow row in dt2.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " | ");
                }
                swExtLogFile.WriteLine(array[i].ToString());
            }
            swExtLogFile.Write(DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
        }

        private void completedBtn_Click(object sender, RoutedEventArgs e)
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=SQUser;pwd=SQUser;database=mssqdatabase";

            DataTable dt2 = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM orders where completed = false";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt2);
            }
            contractDataTbl.ItemsSource = dt2.DefaultView;
        }

        private void passTime_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
