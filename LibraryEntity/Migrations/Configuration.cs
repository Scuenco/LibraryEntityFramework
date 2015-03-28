namespace LibraryEntity.Migrations
{
    using LibraryEntity.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryEntity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryEntity.Models.ApplicationDbContext context)
        {
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
            context.Books.AddOrUpdate(
                b => b.Title,
                new Book() {Title = "The Princess and the Pea", Author="Ms. Author", Genre= "Children", IsDeleted=false },
                new Book() {Title = "Eloquent JavaScript", Author="Mr. Java", Genre= "Computers", IsDeleted = false },
                new Book() {Title = "HTML", Author="Mr. HTML", Genre= "Computers", IsDeleted = false },
                new Book() {Title = "ASP.Net", Author="Microsoft", Genre= "Computers", IsDeleted = false }
                );
        }
    }
}
