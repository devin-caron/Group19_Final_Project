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

namespace ML04_WPF
{
    /// <summary>
    /// Interaction logic for cmpLogIn.xaml
    /// </summary>
    public partial class cmpLogIn : Window
    {
        public cmpLogIn()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmpUser.Text == "DevOSHT" && cmpPass.Password == "Snodgr4ss!")
            {
                BuyerPage.cmpLogInInfo.cmpID = cmpUser.Text;
                BuyerPage.cmpLogInInfo.cmpPassword = cmpPass.Password;
                this.Close();
            }
            else
            {
                errorLbl.Content = "bad log in";
                BuyerPage.cmpLogInInfo.cmpID = null;
                BuyerPage.cmpLogInInfo.cmpPassword = null;
            }
        }
    }
}
