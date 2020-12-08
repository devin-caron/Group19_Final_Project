/* FILE           : MainWindow.xaml.cs
 * PROJECT        : ML04 - Final Project
 * PROGRAMMER     : Group 19:
 *                  Devin Caron, Kevin Downer, Cole Spehar & Dusan Sasic
 * FIRST VERSION  : 2020-11-25
 * DESCRIPTION    : This program 
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ML04_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            userLogIn.myConnectionString = "server=localhost;uid=SQUser;pwd=SQUser;database=mssqdatabase";
        }

        ///
        /// \brief <i>Class</i> <b>userLogIn</b>
        /// \details <b>Stores userID and connection string</b>
        ///
        /// Stores login information used throughout the system
        /// 
        /// This class stores userID and connection string to be used later
        /// 
        public static class userLogIn
        {
            public static string userID { get; set; }

            public static string myConnectionString { get; set; }
        }

        ///
        /// \brief <b>logIn_Click</b> function for <b>MainWindow</b>
        /// \details <b>logs the user in</b>
        ///
        /// Verify log in and send the user to their correct role page. 
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            // verify password and username arent left blank
            if (pass.Password != "" && user.Text != "")
            {
                // store username and password
                string userName = user.Text;
                string password = pass.Password;
                string userRole;

                // start connection to mysql
                MySqlConnection conn;
                string myConnectionString = userLogIn.myConnectionString;

                // try catch
                try
                {
                    // open connection
                    conn = new MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    // verify user name and password in database
                    string sql = "select userRole from userroles where uName='" + userName + "' AND passwords='" + password + "';";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    // incorect log in
                    if (rdr.HasRows == false)
                    {
                        errorLbl.Text = "incorrect login";
                    }
                    else // good log in
                    {
                        // store username in the class
                        userLogIn.userID = userName;

                        // erase errors
                        errorLbl.Text = "";

                        rdr.Close();

                        // determine which role the user is through the database
                        sql = "select userID from userroles where uName ='" + userName + "' AND userRole='planner';";
                        cmd = new MySqlCommand(sql, conn);
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows == true)
                        {
                            userRole = "planner";

                            // open planner page
                            PlannerPage plannerPage = new PlannerPage();
                            plannerPage.Show();
                        }
                        else
                        {
                            rdr.Close();
                            sql = "select userID from userroles where uName ='" + userName + "' AND userRole='buyer';";
                            cmd = new MySqlCommand(sql, conn);
                            rdr = cmd.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                userRole = "buyer";

                                // open buyer page
                                BuyerPage buyerPage = new BuyerPage();
                                buyerPage.Show();
                            }
                            else
                            {
                                rdr.Close();
                                sql = "select userID from userroles where uName ='" + userName + "' AND userRole='admin';";
                                cmd = new MySqlCommand(sql, conn);

                                rdr = cmd.ExecuteReader();
                                if (rdr.HasRows == true)
                                {
                                    userRole = "admin";

                                    // open admin page
                                    AdminPage adminPage = new AdminPage();
                                    adminPage.Show();
                                }

                                // close connections
                                rdr.Close();
                                conn.Close();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    
                }

                // clear text fields
                user.Text = "";
                pass.Password = "";
            }
            else
            {
                // display error
                errorLbl.Text = "incorrect login";
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
            // display email page
            Email emailPage = new Email();
            emailPage.Show();
        }
    }
}
