using System;
using Microsoft.EntityFrameworkCore;
using QuotesApplication.Models;

namespace QuotesApplication.Data
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base(options)
        {
        }

        // Define your DbSets (tables)

        public DbSet<QuotesModel> quotesModel { get; set; }
        public DbSet<StaffsModels> staffmodel { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Quoteitem> quoteitems { get; set; }



    }
}

