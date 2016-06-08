namespace CouncilServices.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CouncilServices.Models.CustomersDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CouncilServices.Models.CustomersDb";
        }

        protected override void Seed(CouncilServices.Models.CustomersDb context)
        {

            context.Customers.AddOrUpdate(
                x => x.Id,
                
                new Models.Customer() {
                    QueuedAt = new DateTime(2016, 5, 20),
                    Service = Service.MissedBin,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Pertwee",
                    FirstName = "John",
                    Title = Title.Mr
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 5, 16),
                    Service = Service.CouncilTax,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Smith",
                    FirstName = "Sarah",
                    Title = Title.Ms
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 5, 13),
                    Service = Service.FlyTipping,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Grant",
                    FirstName = "Jo",
                    Title = Title.Ms
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 3, 28),
                    Service = Service.Housing,
                    CustomerType = CustomerType.Organization,
                    Organisation = "AC12"
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 12, 28),
                    Service = Service.MissedBin,
                    CustomerType = CustomerType.Anonymous,
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 6, 1),
                    Service = Service.FlyTipping,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Oswald",
                    FirstName = "Clara",
                    Title = Title.Ms
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 3, 28),
                    Service = Service.MissedBin,
                    CustomerType = CustomerType.Anonymous,
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 3, 28),
                    Service = Service.MissedBin,
                    CustomerType = CustomerType.Organization,
                    Organisation = "Fawlty Towers"
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 3, 28),
                    Service = Service.Benefits,
                    CustomerType = CustomerType.Organization,
                    Organisation = "Google"
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2014, 6, 1),
                    Service = Service.Benefits,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Baker",
                    FirstName = "Tom",
                    Title = Title.Mr
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 6, 3),
                    Service = Service.FlyTipping,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Lethbridge-Stewart",
                    FirstName = "Alistair",
                    Title = Title.Mr
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 2, 10),
                    Service = Service.Housing,
                    CustomerType = CustomerType.Anonymous,
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 3, 28),
                    Service = Service.Housing,
                    CustomerType = CustomerType.Organization,
                    Organisation = "Microsoft"
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2015, 11, 24),
                    Service = Service.FlyTipping,
                    CustomerType = CustomerType.Organization,
                    Organisation = "Apple"
                },

                new Models.Customer()
                {
                    QueuedAt = new DateTime(2016, 2, 10),
                    Service = Service.Housing,
                    CustomerType = CustomerType.Citizen,
                    LastName = "Smith",
                    FirstName = "Matt",
                    Title = Title.Mr
                }

                );
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
