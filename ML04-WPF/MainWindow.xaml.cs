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

        public static class userLogIn
        {
            public static string userID { get; set; }

            public static string myConnectionString { get; set; }
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Password != "" && user.Text != "")
            {
                string userName = user.Text;
                string password = pass.Password;
                string userRole;

                MySqlConnection conn;

                string myConnectionString = userLogIn.myConnectionString;

                try
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    string sql = "select userRole from userroles where uName='" + userName + "' AND passwords='" + password + "';";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows == false)
                    {
                        errorLbl.Text = "incorrect login";
                    }
                    else
                    {
                        userLogIn.userID = userName;

                        errorLbl.Text = "";
                        rdr.Close();
                        sql = "select userID from userroles where uName ='" + userName + "' AND userRole='planner';";
                        cmd = new MySqlCommand(sql, conn);
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows == true)
                        {
                            Console.WriteLine("You are a planner");
                            userRole = "planner";

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
                                    Console.WriteLine("You are an admin");
                                    userRole = "admin";

                                    AdminPage adminPage = new AdminPage();
                                    adminPage.Show();
                                }

                                rdr.Close();
                                conn.Close();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    
                }

                user.Text = "";
                pass.Password = "";
            }
            else
            {
                errorLbl.Text = "incorrect login";
            }
        }

        private void supportBtn_Click(object sender, RoutedEventArgs e)
        {
            Email emailPage = new Email();
            emailPage.Show();
        }
    }
}
