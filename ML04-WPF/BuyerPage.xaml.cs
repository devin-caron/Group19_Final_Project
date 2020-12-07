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
    /// Interaction logic for BuyerPage.xaml
    /// </summary>
    /// 
    public partial class BuyerPage : Window
    {
        private static string sPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public static class cmpLogInInfo
        {
            public static string cmpID { get; set; }
            public static string cmpPassword { get; set; }
        }

        public BuyerPage()
        {
            InitializeComponent();

            string userName = MainWindow.userLogIn.userID;

            userLbl.Content = userName;

            contractBtn.IsEnabled = false;
            SendOrder.IsEnabled = false;
            // log in:
            // DevOSHT
            // Snodgr4ss!
        }

        private void contractBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cmpLogInInfo.cmpID != null || cmpLogInInfo.cmpPassword != null)
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection("server=localhost;uid=" + cmpLogInInfo.cmpID + ";pwd=" + cmpLogInInfo.cmpPassword + ";database=cmp"))
                {
                    conn.Open();
                    string query = "SELECT * FROM contract";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                        da.Fill(dt);
                }
                contractDataTbl.ItemsSource = dt.DefaultView;
            }
        }

        private void completedBtn_Click(object sender, RoutedEventArgs e)
        {
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            DataTable dt2 = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM orders where completed = true";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt2);
            }
            contractDataTbl.ItemsSource = dt2.DefaultView;
        }
        private void cmpLogInBtn_Click(object sender, RoutedEventArgs e)
        {
            cmpLogInInfo.cmpID = null;
            cmpLogInInfo.cmpPassword = null;
            cmpLogIn contractLog = new cmpLogIn();
            contractLog.Show();

            // place holder solution
            contractBtn.IsEnabled = true;
        }

        private void SendOrder_Click(object sender, RoutedEventArgs e)
        {
            if ((orderID.Text != "" && IsTextAllowed(orderID.Text) == true) && customer.Text != "" && startLoc.Text != "" && endLoc.Text != "")
            {
                MySqlConnection conn;

                string myConnectionString = MainWindow.userLogIn.myConnectionString;

                try
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    string sql = "insert into orders (OrderID, Customer, StartLoc, EndLoc, trip, km, cost, completed) values(" + Int32.Parse(orderID.Text) + ", '" + customer.Text + "', '" + startLoc.Text + "', '" + endLoc.Text + "', null, null, 0, false);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    conn.Close();
                    rdr.Close();

                    string newPath = sPath + "/" + orderID.Text + "_" + customer.Text + "_Invoice.txt";

                    DateTime time = DateTime.Now;
                    File.AppendAllText(newPath, "Order Time: " + time + "\nOrder ID: " + orderID.Text + "\nCustomer: " + customer.Text + "\nStarting Location: " + startLoc.Text + "\nEnding Location: " + endLoc.Text);

                    invoiceLbl.Text = "Invoice Started";

                    orderID.Text = "";
                    customer.Text = "";
                    startLoc.Text = "";
                    endLoc.Text = "";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((orderID.Text != "" && IsTextAllowed(orderID.Text) == true) && customer.Text != "" && startLoc.Text != "" && endLoc.Text != "")
            {
                SendOrder.IsEnabled = true;
            }
            else
            {
                SendOrder.IsEnabled = false;
            }
        }

        private void supportBtn_Click(object sender, RoutedEventArgs e)
        {
            Email emailPage = new Email();
            emailPage.Show();
        }
    }
}