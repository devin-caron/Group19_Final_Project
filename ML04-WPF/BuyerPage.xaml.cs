/* FILE           : BuyerPage.xaml.cs
 * PROJECT        : ML04 - Final Project
 * PROGRAMMER     : Group 19:
 *                  Devin Caron, Kevin Downer, Cole Spehar & Dusan Sasic
 * FIRST VERSION  : 2020-11-25
 * DESCRIPTION    : This page is used by the buyer and allows him to do many buyer taks.
 *                  Tasks include sets up orders, reviews customers and gets contracts from cmp database.
 */


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

        ///
        /// \brief <i>Class</i> <b>cmpLogIn</b>
        /// \details <b>Stores cmpID and cmpPassword</b>
        ///
        /// Stores cmpLogin information used throughout the system
        /// 
        /// Stores cmpLogin information used throughout the system and allows the
        /// buyer to access cmp contract database
        ///
        public static class cmpLogInInfo
        {
            public static string cmpID { get; set; }
            public static string cmpPassword { get; set; }
        }

        public BuyerPage()
        {
            InitializeComponent();

            // display required label
            invoiceLbl.Content = "Completed\nOrderID\nRequired";

            // display name
            string userName = MainWindow.userLogIn.userID;

            userLbl.Content = userName;

            // disable buttons
            contractBtn.IsEnabled = false;
            SendOrder.IsEnabled = false;

            // log in:
            // DevOSHT
            // Snodgr4ss!
        }

        ///
        /// \brief <b>contractBtn_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Displays contract information from cmp database</b>
        ///
        /// Displays contract information from cmp database
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void contractBtn_Click(object sender, RoutedEventArgs e)
        {
            // display database too datatable
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

            // reset errors
            invoiceLbl.Content = "";
            sendOrderLbl.Text = "";
        }

        ///
        /// \brief <b>compltedBtn_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Displays completed orders from database</b>
        ///
        /// Displays completed orders from database
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void completedBtn_Click(object sender, RoutedEventArgs e)
        {
            // display database too datatable
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

            // reset errors
            invoiceLbl.Content = "";
            sendOrderLbl.Text = "";
        }

        ///
        /// \brief <b>cmpLogInBtn_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Allows buyer to log into cmp database</b>
        ///
        /// Brings up a new window to sign into the cmp database and enables the button to display contract database
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void cmpLogInBtn_Click(object sender, RoutedEventArgs e)
        {
            cmpLogInInfo.cmpID = null;
            cmpLogInInfo.cmpPassword = null;
            cmpLogIn contractLog = new cmpLogIn();
            contractLog.Show();

            // place holder solution
            contractBtn.IsEnabled = true;
        }

        ///
        /// \brief <b>SendOrder_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Allows buyer to send orders to planner</b>
        ///
        /// Verifies text fields and then submits the information to orders table
        /// in the database to allow the planner to complete them
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
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


                    conn = new MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    string sql2 = "insert into customers (CustomerName) values('" + customer.Text + "');";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    conn.Close();
                    rdr2.Close();

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

        ///
        /// \brief <b>TextChanged</b> function for <b>BuyerPage</b>
        /// \details <b>checks when text is changed in order fields</b>
        ///
        /// When text is changed in the order text fields it verifies the 
        /// fields and enables the button to submit
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
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

        ///
        /// \brief <b>supportBtn_Click</b> function for to display email support
        /// \details <b>brings up email wpf page</b>
        ///
        /// Displays support email wpf page 
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void supportBtn_Click(object sender, RoutedEventArgs e)
        {
            Email emailPage = new Email();
            emailPage.Show();
        }

        ///
        /// \brief <b>invoiceBtn_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Verifies orderID then prints invoice</b>
        ///
        /// When pressed the invoice is printed to a text file if
        /// the orderID is from a completed order.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void invoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            // verify orderID is a number
            if ((orderID.Text != "" && IsTextAllowed(orderID.Text) == true))
            {
                // connect to database
                MySqlConnection conn;

                string myConnectionString = MainWindow.userLogIn.myConnectionString;

                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                // verify order is completed
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

                // if it is completed
                if (completed == true)
                {
                    string customer = "";
                    string startLoc = "";
                    string endLoc = "";
                    int trip = 0;
                    int kms = 0;
                    double cost = 0;

                    // get the values of the order
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


                    // print order invoice to text file in bin
                    string newPath = sPath + "/" + orderID.Text + "_" + customer + "_Invoice.txt";

                    DateTime time = DateTime.Now;
                    File.AppendAllText(newPath, "---Omnicorp TMS Invoice---\nOrder Time: " + time + "\nOrder ID: " + orderID.Text + "\nCustomer: " + customer + "\nStarting Location: " + startLoc + "\nEnding Location: " + endLoc + "\nKm: " + kms + "\nCost: $" + cost + "\n---Invoice Complete---");
                    invoiceLbl.Content = "Invoice\nPrinted";
                }
                else
                {
                    // error message
                    invoiceLbl.Content = "Completed\nOrderID\nRequired";
                    sendOrderLbl.Text = "";
                }
            }
            else
            {
                // error message
                invoiceLbl.Content = "Completed\nOrderID\nRequired";
                sendOrderLbl.Text = "";
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); // regex that matches disallowed text

        ///
        /// \brief <b>IsTextAllowed</b> function for <b>BuyerPage</b>
        /// \details <b>Verifies that text is only numbers</b>
        ///
        /// Takes input string and checks to see if it has anything but int numbers
        ///
        /// \param None  - <b>string: text</b>
        ///
        /// \return  private static - <b>bool/b>
        ///
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        ///
        /// \brief <b>ReviewCustomers_Click</b> function for <b>BuyerPage</b>
        /// \details <b>Displays customer database</b>
        ///
        /// When pressed the gets the customer database and displays it in a datatable
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void ReviewCustomers_Click(object sender, RoutedEventArgs e)
        {
            // get connection
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            // display data in datatable
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM customers";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            contractDataTbl.ItemsSource = dt.DefaultView;

            // clear errors
            invoiceLbl.Content = "";
            sendOrderLbl.Text = "";
        }
    }
}