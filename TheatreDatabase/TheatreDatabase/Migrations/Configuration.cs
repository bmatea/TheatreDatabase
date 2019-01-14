namespace TheatreDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreDatabase.TheatreContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheatreDatabase.TheatreContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

    }

    public class AddConstraint : Migration
    {
        protected override void Up (MigrationBuilder builder)
        {
                builder.Sql(@"ALTER TABLE Auditoriums
                 ADD CONSTRAINT CK_NumOfSeats CHECK ((NumberOfAvailableSeats > 0) AND (NumberOfAvailableSeats < NumberOfSeats))");
        }
    }
}

