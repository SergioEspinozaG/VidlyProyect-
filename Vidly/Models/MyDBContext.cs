﻿
using System.Data.Entity;

namespace Vidly.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<MembershipType> MembershipTypes { get; set; }// My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models
        public DbSet<MoviesGenres> MoviesGenres { get; set; }// My domain models
        public DbSet<MovieData> MovieData { get; set; }// My domain models
    }
}