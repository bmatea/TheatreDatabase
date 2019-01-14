using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
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

namespace TheatreDatabase
{
    /// <summary>
    /// Interaction logic for BoxOffice.xaml
    /// </summary>
    public partial class BoxOffice : Window
    {
        public BoxOffice()
        {
            InitializeComponent();
            ListBox.Items.Add("Hamlet");
            ListBox.Items.Add("John Gabriel Borkman");
            ListBox.Items.Add("Glorija");
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal bal = Convert.ToDecimal(BalanceDisplay.Text);
                string username = UserDisplay.Text;
                var selected = ListBox.SelectedItem.ToString();
                
                using (var cntxt = new TheatreContext("Name=TheatreDatabase"))
                {
                    var user = (from c in cntxt.Users
                            where (c.username == username)
                            select c).FirstOrDefault();

                    var play = (from p in cntxt.Plays
                                where (p.Title == selected)
                                select p).FirstOrDefault();

                    if (RadioBtn1.IsChecked == true)
                    {
                        Actions purchase;

                        purchase = new Purchase { date = DateTime.Now, Accounts = user.Account, Play = play };

                        purchase.PerformAction(play.TicketPrice,user.Account.AccountsId, play.Auditorium.AuditoriumsId);
                        user.Account.Actions.Add(purchase);
                        BalanceDisplay.Clear();                     
                        BalanceDisplay.AppendText((user.Account.Balance - play.TicketPrice).ToString());
                        AvailableSeatsDisplay.Clear();
                        AvailableSeatsDisplay.AppendText((play.Auditorium.NumberOfAvailableSeats - 1).ToString());
                        TransactionNumDisplay.AppendText((user.Account.Actions.Count() - 1).ToString());
                       


                    }

                    else if (RadioBtn2.IsChecked == true)
                    {
                        Actions reservation;

                        reservation = new Reservation { date = DateTime.Now, Accounts = user.Account, Play = play};

                        reservation.PerformAction(play.TicketPrice, user.Account.AccountsId, play.Auditorium.AuditoriumsId);
                        user.Account.Actions.Add(reservation);
                        AvailableSeatsDisplay.Clear();
                        AvailableSeatsDisplay.AppendText((play.Auditorium.NumberOfAvailableSeats - 1).ToString());
                        TransactionNumDisplay.AppendText((user.Account.Actions.Count() - 1).ToString());

                    }
                    play.State.ChangeState(play);

                    cntxt.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if((RadioBtn1.IsEnabled==false) && (RadioBtn2.IsEnabled==false) && (SelectBtn.IsEnabled==false))
                {
                    RadioBtn1.IsEnabled = true;
                    RadioBtn2.IsEnabled = true;
                    SelectBtn.IsEnabled = true;
                }
                decimal bal;
                var Play = new Plays();
                using (var cntxt = new TheatreContext("Name=TheatreDatabase"))
                {
                    var s = ListBox.SelectedItem.ToString();

                    Play = (from c in cntxt.Plays
                                where (c.Title == s)
                                select c).FirstOrDefault();

                    PriceDisplay.Clear();
                    PriceDisplay.AppendText(Play.TicketPrice.ToString());
                    AvailableSeatsDisplay.Clear();
                    AvailableSeatsDisplay.AppendText(Play.Auditorium.NumberOfAvailableSeats.ToString());
                    Play.State.ChangeState(Play);
                    Play.DisplayState();

                                            
                    
                    bal = Convert.ToDecimal(BalanceDisplay.Text);
                    if(bal<Play.TicketPrice)
                    {
                        RadioBtn1.IsEnabled = false;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow b = new MainWindow();
            b.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
