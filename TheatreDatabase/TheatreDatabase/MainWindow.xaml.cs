using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace TheatreDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickLoginBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new BoxOffice();
                window.Show();
                this.Close();

                string username;
                int pass;

                username = TextBox.Text;
                pass = Convert.ToInt16(PassBox.Text);

                using (var context = new TheatreContext("Name=TheatreDatabase"))
                {
                    var user = (from c in context.Users
                                where ((c.username == username) && (c.password == pass))
                                select c).Include(x => x.Account).FirstOrDefault();
                    window.UserDisplay.AppendText(user.username.ToString());
                    var balance = user.Account.Balance;
                    window.BalanceDisplay.AppendText(balance.ToString());
                }
            }
            catch
            {
                MessageBox.Show("The information you typed does not match any user from the databse. Please try again.");
                var win = new MainWindow();
                win.Show();
            }
        }
    }
}
