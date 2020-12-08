/* FILE           : PlannerPage.xaml.cs
 * PROJECT        : ML04 - Final Project
 * PROGRAMMER     : Group 19:
 *                  Devin Caron, Kevin Downer, Cole Spehar & Dusan Sasic
 * FIRST VERSION  : 2020-11-25
 * DESCRIPTION    : This page is used by the planner and allows him to do many planner taks.
 *                  Tasks include sets up carriers, reviews completed orders and create all time invoices.
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
    /// Interaction logic for PlannerPage.xaml
    /// </summary>
    public partial class PlannerPage : Window
    {
        // constants
        private static string sPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private const int loadTime = 4;
        private const double OSHTCost = 1.08;

        public PlannerPage()
        {
            InitializeComponent();

            string userName = MainWindow.userLogIn.userID;

            userLbl.Content = userName;

            SendOrder.IsEnabled = false;
        }

        ///
        /// \brief <b>SendOrder_Click</b> function for <b>PlanerPage</b>
        /// \details <b>sends the order to carrier</b>
        ///
        /// Verifies the carriers requested then calculates the time and cost
        /// required for the delivery and displays it for the planner and updates the
        /// database.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void SendOrder_Click(object sender, RoutedEventArgs e)
        {
            int tripCount = 0;

            // get trip count
            if (planetExpress.IsChecked == true)
            {
                tripCount++;
            }
            if (schooners.IsChecked == true)
            {
                tripCount++;
            }
            if (tillmanTransport.IsChecked == true)
            {
                tripCount++;
            }
            if (weHaul.IsChecked == true)
            {
                tripCount++;
            }

            // connect to mysql
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            // verify number isn't empty
            if (orderNum.Text != "")
            {
                try
                {
                    // update the order's trip count
                    int order = Int32.Parse(orderNum.Text);
                    string sql = "update orders set trip = '" + tripCount + "' where orderID = '" + order + "' and completed = false;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                }
                catch (MySqlException ex)
                {

                }
                conn.Close();


                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                // get the orders starting location
                string sql2 = "select startLoc from orders where orderID = " + Int32.Parse(orderNum.Text) + ";";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();

                string startLocation = "";
                string endLocation = "";
                string east = "";
                int kms = 0;
                double time = 0;

                while (rdr2.Read())
                {
                    var startLoc = rdr2["startLoc"];
                    startLocation = startLoc.ToString();
                }
                rdr2.Close();

                // get the orders ending location
                sql2 = "select endLoc from orders where orderID = " + Int32.Parse(orderNum.Text) + ";";
                cmd2 = new MySqlCommand(sql2, conn);
                rdr2 = cmd2.ExecuteReader();

                while (rdr2.Read())
                {
                    var endLoc = rdr2["endLoc"];
                    endLocation = endLoc.ToString();
                }
                rdr2.Close();


                //-------------------------------------------------------//
                int stops = 0;
                string location = "";

                // get the east location
                east = findEast(startLocation, conn);

                // get the kms to travel to the east
                kms = findKMS(startLocation, conn);

                // get the time to travel to the east
                time = findTime(startLocation, conn);

                // if that is not the destination continue the process
                while (east != endLocation)
                {
                    stops++;

                    east = findEast(east, conn);

                    location = findStart(east, conn);

                    kms += findKMS(location, conn);

                    time += findTime(location, conn);
                }

                // increase time for loading time
                time += loadTime;

                // get customer name
                string sql3 = "select customer from orders where orderID = '" + Int32.Parse(orderNum.Text) + "';";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataReader rdr3 = cmd3.ExecuteReader();

                string customer = "";
                while (rdr3.Read())
                {
                    var customerName = rdr3["customer"];
                    customer = customerName.ToString();
                }
                rdr3.Close();

                // get the cost of the rate from the carrier
                sql3 = "select FTLRate from carriers where dCity = '" + startLocation + "';";
                cmd3 = new MySqlCommand(sql3, conn);
                rdr3 = cmd3.ExecuteReader();

                double FTLRate = 0;
                while (rdr3.Read())
                {
                    var FTL = rdr3["FTLRate"];
                    FTLRate = Convert.ToInt32(FTL);
                }
                rdr3.Close();

                // calculate cost
                double cost = (kms * FTLRate) * OSHTCost;

                // display trip details in message box
                MessageBox.Show($"Trip from {startLocation} to {endLocation} will be {kms}km and take {time + (stops * 2)} hours(loads included) with {stops} stops.\nTotal Cost: ${cost}");


                // update the order with cost and kms
                sql3 = "update orders set cost = " + cost + ", kms = " + kms + " where orderID = " + Int32.Parse(orderNum.Text) + ";";
                cmd3 = new MySqlCommand(sql3, conn);
                rdr3 = cmd3.ExecuteReader();
                rdr3.Close();

                // refresh display
                completedBtn_Click(sender, e);

                lblUpdate.Content = "";
                sendUpdate.Content = "Trip Updated";
            }
        }


        ///
        /// \brief <b>findEast</b> function for <b>PlanerPage</b>
        /// \details <b>gets the east location</b>
        ///
        /// Gets the location to the east of the destination displayed and returns
        /// the east destination string.
        ///
        /// \param None  - <b>string: destination, MySqlConnection: conn</b>
        ///
        /// \return  string - <b>east</b>
        ///
        private string findEast(string destination, MySqlConnection conn)
        {
            string east = "";

            string sql = "select east from transportationcorridor where destination = '" + destination + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var easter = rdr["east"];
                east = easter.ToString();
            }
            rdr.Close();

            return east;
        }

        ///
        /// \brief <b>findStart</b> function for <b>PlanerPage</b>
        /// \details <b>gets the new start location</b>
        ///
        /// Gets the location to the destination of the east displayed and returns
        /// the destination string.
        ///
        /// \param None  - <b>string: east, MySqlConnection: conn</b>
        ///
        /// \return  string - <b>destination</b>
        ///
        private string findStart(string east, MySqlConnection conn)
        {
            string destination = "";

            string sql = "select destination from transportationcorridor where east = '" + east + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var dest = rdr["destination"];
                destination = dest.ToString();
            }
            rdr.Close();

            return destination;
        }

        ///
        /// \brief <b>findKMS</b> function for <b>PlanerPage</b>
        /// \details <b>gets the kms</b>
        ///
        /// Gets the location to the destination and how long it will take to travel
        ///
        /// \param None  - <b>string: destination, MySqlConnection: conn</b>
        ///
        /// \return  int - <b>kms</b>
        ///
        private int findKMS(string destination, MySqlConnection conn)
        {
            int kms = 0;

            string sql = "select kms from transportationcorridor where destination = '" + destination + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var kmss = rdr["kms"];
                kms = Convert.ToInt32(kmss);
            }
            rdr.Close();

            return kms;
        }

        ///
        /// \brief <b>findTime</b> function for <b>PlanerPage</b>
        /// \details <b>gets the travel time</b>
        ///
        /// Gets the location to the destination and how long it will take to travel
        ///
        /// \param None  - <b>string: destination, MySqlConnection: conn</b>
        ///
        /// \return  double - <b>time</b>
        ///
        private double findTime(string destination, MySqlConnection conn)
        {
            double time = 0;

            string sql = "select times from transportationcorridor where destination = '" + destination + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var times = rdr["times"];
                time = Convert.ToDouble(times);
            }
            rdr.Close();

            return time;
        }

        ///
        /// \brief <b>Invoice_Click</b> function for <b>PlanerPage</b>
        /// \details <b>Creates the all time order invoice</b>
        ///
        /// Gets the completed orders and writes it too a text file with seperators
        ///
        /// \param None  - <b>object sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(sPath + "/AllTimeInvoice.txt", "");

            StreamWriter swExtLogFile = new StreamWriter(sPath + "/AllTimeInvoice.txt", true);
            DataTable dt2 = new DataTable();

            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            // get datatable
            dt2 = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM orders where completed = true;";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt2);
            }

            // print datatable to text
            swExtLogFile.Write("Omnicorp TMS Invoice Report:\n");
            swExtLogFile.Write("All Time Invoice\n");
            swExtLogFile.Write("ID | Customer | Start | End | Trip | Km | Cost($) | Completed\n");
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
            // add time
            swExtLogFile.Write(DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
            lblUpdate.Content = "Invoice File Created";
            sendUpdate.Content = "";
        }

        ///
        /// \brief <b>completedBtn_Click</b> function for <b>PlanerPage</b>
        /// \details <b>Displays completed orders</b>
        ///
        /// Gets the completed orders and displays it in the datatable
        ///
        /// \param None  - <b>object sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void completedBtn_Click(object sender, RoutedEventArgs e)
        {
            string myConnectionString;
            myConnectionString = MainWindow.userLogIn.myConnectionString;

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

        ///
        /// \brief <b>passTime_Click</b> function for <b>PlanerPage</b>
        /// \details <b>Passes time and completes all orders/trips</b>
        ///
        /// Passes time so drivers can complete their trips and sets orders to completed
        ///
        /// \param None  - <b>object sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void passTime_Click(object sender, RoutedEventArgs e)
        {
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            string sql = "update orders set completed = true where trip > 0;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            conn.Close();
            completedBtn_Click(sender, e);
            lblUpdate.Content = "Time has been passed.";
            sendUpdate.Content = "";
        }

        ///
        /// \brief <b>Box_Checked</b> function for <b>PlanerPage</b>
        /// \details <b>Checks if a box is checked and enables send button</b>
        ///
        /// Checks if a box is checked and enables send button
        ///
        /// \param None  - <b>object sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void Box_Checked(object sender, RoutedEventArgs e)
        {
            if (planetExpress.IsChecked == true || schooners.IsChecked == true || tillmanTransport.IsChecked == true || weHaul.IsChecked == false)
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
        /// \details <b>Details</b>
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
    }
}
