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

namespace ML04_WPF
{
    /// <summary>
    /// Interaction logic for BuyerPage.xaml
    /// </summary>
    /// 
    public partial class BuyerPage : Window
    {
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

            // log in:
            // DevOSHT
            // Snodgr4ss!
        }

        private void contractBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cmpLogInInfo.cmpID == null || cmpLogInInfo.cmpPassword == null)
            {
                
            }
            else
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
        private void cmpLogInBtn_Click(object sender, RoutedEventArgs e)
        {
            cmpLogInInfo.cmpID = null;
            cmpLogInInfo.cmpPassword = null;
            cmpLogIn contractLog = new cmpLogIn();
            contractLog.Show();
        }

    }
}
