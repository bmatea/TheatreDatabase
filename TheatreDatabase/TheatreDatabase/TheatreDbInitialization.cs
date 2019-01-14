using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TheatreDatabase
{
    public class TheatreDbInitialization : DropCreateDatabaseIfModelChanges<TheatreContext>
    {
        static Actors actor1, actor2, actor3, actor4;
        static Users user1, user2, user3;
        static Accounts account1, account2, account3;
        static Plays play1, play2, play3;
        static Auditoriums audit1, audit2, audit3;
        protected override void Seed(TheatreContext context)
        {
            CreateObjects();
            PopulateDatabase();
        }

        static void CreateObjects()
        {
            actor1 = new Actors { firstName = "Alan", lastName = "Rickman" };
            actor2 = new Actors { firstName = "Jean", lastName = "Simmons" };
            actor3 = new Actors { firstName = "Jeremy", lastName = "Irons" };
            actor4 = new Actors { firstName = "Laurence", lastName = "Olivier" };

            user1 = new Users { username = "username1", password = 1234 };
            user2 = new Users { username = "username2", password = 5555 };
            user3 = new Users { username = "username3", password = 6676 };

            account1 = new Accounts { Balance = 250m };
            account2 = new Accounts { Balance = 35m };
            account3 = new Accounts { Balance = 0 };

            play1 = new Plays { Title = "Hamlet", Playwright = "William Shakespeare", TicketPrice = 80m };
            play2 = new Plays { Title = "John Gabriel Borkman", Playwright = "Henrik Ibsen", TicketPrice = 60m };
            play3 = new Plays { Title = "Glorija", Playwright = "Ranko Marinković", TicketPrice = 65m };

            audit1 = new Auditoriums { name = "Auditorium1", NumberOfSeats = 1, NumberOfAvailableSeats = 1 };
            audit2 = new Auditoriums { name = "Auditorium2", NumberOfSeats = 50, NumberOfAvailableSeats = 50 };
            audit3 = new Auditoriums { name = "Auditorium3", NumberOfSeats = 150, NumberOfAvailableSeats = 150 };

            user1.Account = account1;
            user2.Account = account2;
            user3.Account = account3;

            play1.Auditorium = audit1;
            play2.Auditorium = audit2;
            play3.Auditorium = audit3;

            actor1.Plays = new List<Plays> { play1, play3 };
            actor2.Plays = new List<Plays> { play2, play3 };
            actor3.Plays = new List<Plays> { play1 };
            actor4.Plays = new List<Plays> { play1 };

            play1.Actors = new List<Actors> { actor1, actor3, actor4 };
            play2.Actors = new List<Actors> { actor2 };
            play3.Actors = new List<Actors> { actor1, actor2 };


        }

        static void PopulateDatabase()
        {
            using (TheatreContext context = new TheatreContext("Name=TheatreDatabase"))
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TheatreContext>());

                actor1.Plays.Add(play1);
                actor1.Plays.Add(play3);
                actor2.Plays.Add(play2);
                actor2.Plays.Add(play3);
                actor3.Plays.Add(play1);
                actor4.Plays.Add(play1);

                play1.Actors.Add(actor1);
                play1.Actors.Add(actor3);
                play1.Actors.Add(actor4);
                play2.Actors.Add(actor2);
                play3.Actors.Add(actor1);
                play3.Actors.Add(actor2);

                context.Accounts.Add(account1);
                context.Accounts.Add(account2);
                context.Accounts.Add(account3);
                context.Actors.Add(actor1);
                context.Actors.Add(actor2);
                context.Actors.Add(actor3);
                context.Actors.Add(actor4);
                context.Auditoriums.Add(audit1);
                context.Auditoriums.Add(audit2);
                context.Auditoriums.Add(audit3);
                context.Plays.Add(play1);
                context.Plays.Add(play2);
                context.Plays.Add(play3);
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();
            }
        }
    }
}

