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

                    string sql = "insert into orders (OrderID, Customer, StartLoc, EndLoc, trip, kms, cost, completed) values(" + Int32.Parse(orderID.Text) + ", '" + customer.Text + "', '" + startLoc.Text + "', '" + endLoc.Text + "', 0, 0, 0.0, false);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    conn.Close();
                    rdr.Close();

                    orderID.Text = "";
                    customer.Text = "";
                    startLoc.Text = "";
                    endLoc.Text = "";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                invoiceLbl.Content = "";
                sendOrderLbl.Text = "Order sent to planner.";
            }
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

        private void invoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((orderID.Text != "" && IsTextAllowed(orderID.Text) == true))
            {
                MySqlConnection conn;

                string myConnectionString = MainWindow.userLogIn.myConnectionString;

                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string sql = "select completed from orders where orderID = " + Int32.Parse(orderID.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                bool completed = false;
                while (rdr.Read())
                {
                    var comp = rdr["completed"];
                    completed = Convert.ToBoolean(comp);
                }
                rdr.Close();

                if(completed == true)
                {
                    string customer = "";
                    string startLoc = "";
                    string endLoc = "";
                    int trip = 0;
                    int kms = 0;
                    double cost = 0;

                    sql = "select customer, startLoc, endLoc, trip, kms, cost from orders where orderID = " + Int32.Parse(orderID.Text) + ";";
                    cmd = new MySqlCommand(sql, conn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var cust = rdr["customer"];
                        customer = cust.ToString();
                        var startLocation = rdr["startLoc"];
                        startLoc = startLocation.ToString();
                        var endLocation = rdr["endLoc"];
                        endLoc = endLocation.ToString();
                        var tr = rdr["trip"];
                        trip = Convert.ToInt32(tr);
                        var km = rdr["kms"];
                        kms = Convert.ToInt32(km);
                        var cos = rdr["cost"];
                        cost = Convert.ToDouble(cos);
                    }
                    rdr.Close();


                    string newPath = sPath + "/" + orderID.Text + "_" + customer + "_Invoice.txt";

                    DateTime time = DateTime.Now;
                    File.AppendAllText(newPath, "---Omnicorp TMS Invoice---\nOrder Time: " + time + "\nOrder ID: " + orderID.Text + "\nCustomer: " + customer + "\nStarting Location: " + startLoc + "\nEnding Location: " + endLoc + "\nKm: " + kms + "\nCost: $" + cost + "\n---Invoice Complete---");
                    invoiceLbl.Content = "Invoice\nPrinted";
                }
                else
                {
                    invoiceLbl.Content = "Completed\nOrderID\nRequired";
                    sendOrderLbl.Text = "";
                }
            }
            else
            {
                invoiceLbl.Content = "Completed\nOrderID\nRequired";
                sendOrderLbl.Text = "";
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); // regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}