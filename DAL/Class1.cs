using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }


    public class TestDBEntities : DbContext
    {
        public TestDBEntities(DbContextOptions<TestDBEntities> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
