/* FILE           : BuyerPage.xaml.cs
 * PROJECT        : ML04 - Final Project
 * PROGRAMMER     : Group 19:
 *                  Devin Caron, Kevin Downer, Cole Spehar & Dusan Sasic
 * FIRST VERSION  : 2020-11-25
 * DESCRIPTION    : This page is used by the admin and allows him to do many admin taks.
 *                  Tasks include altering tables, backing up the database and displaying carrier information.
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
using Microsoft.Win32;

namespace ML04_WPF
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();

            // set name
            string userName = MainWindow.userLogIn.userID;

            userLbl.Content = userName;
        }

        ///
        /// \brief <b>backup_click</b> function for <b>AdminPage</b>
        /// \details <b>backs up the database</b>
        ///
        /// Gets the database and creates a backup for possible restoration.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void backup_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog logFile = new SaveFileDialog();
            logFile.Filter = "SQL file(*.sql)|*.sql|All Files (*.*)";
            logFile.Title = "Dump the database (.sql)";

            if (logFile.ShowDialog() == true)
            {
                string FilePath = logFile.FileName;

                string conStr = "server=localhost;uid=root;pwd=qazwsx8;database=mssqdatabase";
                using (MySqlConnection connection = new MySqlConnection(conStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {
                                cmd.Connection = connection;
                                connection.Open();
                                mb.ExportToFile(FilePath);
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
            }

        }

        ///
        /// \brief <b>route_checked</b> function for <b>AdminPage</b>
        /// \details <b>displays route database</b>
        ///
        /// When checked the datatable displays the route database.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void route_Checked(object sender, RoutedEventArgs e)
        {
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM transportationcorridor";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            contractDataTbl.ItemsSource = dt.DefaultView;

            rate.IsChecked = false;
            carrier.IsChecked = false;
        }

        ///
        /// \brief <b>carrier_checked</b> function for <b>AdminPage</b>
        /// \details <b>displays carrier database</b>
        ///
        /// When checked the datatable displays the carrier database.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void carrier_Checked(object sender, RoutedEventArgs e)
        {
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT cName, dCity, FTLA, LTLA FROM carriers";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            contractDataTbl.ItemsSource = dt.DefaultView;

            rate.IsChecked = false;
            route.IsChecked = false;
        }

        ///
        /// \brief <b>rate_checked</b> function for <b>AdminPage</b>
        /// \details <b>displays rate database</b>
        ///
        /// When checked the datatable displays the rate database.
        ///
        /// \param None  - <b>object: sender, RoutedEventArgs e</b>
        ///
        /// \return  None - <b>void</b>
        ///
        private void rate_Checked(object sender, RoutedEventArgs e)
        {
            string myConnectionString = MainWindow.userLogIn.myConnectionString;

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string query = "SELECT FTLRate, LTLRate, reefCharge FROM carriers";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            contractDataTbl.ItemsSource = dt.DefaultView;

            route.IsChecked = false;
            carrier.IsChecked = false;
        }
    }
}
