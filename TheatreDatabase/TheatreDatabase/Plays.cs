using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace TheatreDatabase
{
    public class Plays
    {
        public int PlaysId { get; set; }
        public string  Title { get; set; }
        public string  Playwright { get; set; }

        public decimal TicketPrice { get; set; }

        public int AuditoriumsId { get; set; }
        public virtual Auditoriums Auditorium { get; set; }
        public virtual ICollection<Actors> Actors { get; set; }

        public IPlayState State { get; set; } = new Empty();

        public void ChangeState()
        {
            State.ChangeState(this);
        }
        public void DisplayState()
        {
            State.DisplayState();
        }
    }

    public interface IPlayState
    {
        void ChangeState(Plays play);
        void DisplayState();
    }

    public class SoldOut : IPlayState
    {
        public void ChangeState(Plays play)
        {
            BoxOffice b = App.Current.Windows.OfType<BoxOffice>().SingleOrDefault(w=>w.IsActive);
            b.RadioBtn1.IsEnabled = false;
            b.RadioBtn2.IsEnabled = false;
            b.SelectBtn.IsEnabled = false;
           
        }

        public void DisplayState()
        {
            MessageBox.Show("This play is sold out!");
        }
    }

    public class Empty : IPlayState
    {
        public void ChangeState(Plays play)
        {
            if ((play.Auditorium.NumberOfAvailableSeats != 0) && 
                (play.Auditorium.NumberOfAvailableSeats!=play.Auditorium.NumberOfSeats))
            {
                play.State = new PartiallySoldOut();
            }

            if (play.Auditorium.NumberOfAvailableSeats == 0)
            {
                play.State = new SoldOut();
                play.State.ChangeState(play);
            }
        }

        public void DisplayState()
        {
            MessageBox.Show("Tickets for this play are still available!");
        }
    }

    public class PartiallySoldOut : IPlayState
    {
        public void ChangeState(Plays play)
        {
            if (play.Auditorium.NumberOfAvailableSeats == 0)
            {
                play.State = new SoldOut();
            }
        }

        public void DisplayState()
        {
            MessageBox.Show("Tickets for this play are still available!");
        }
    }
}
