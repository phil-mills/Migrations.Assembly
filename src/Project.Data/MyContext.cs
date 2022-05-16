namespace Project.Data
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class MyContext : DbContext
    {
        public MyContext() : base() 
        { }

        public MyContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
    }
}