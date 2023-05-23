using Microsoft.EntityFrameworkCore;
using TMS.Models;

namespace TMS.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
            
        }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

      public  DbSet<User> Users { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TMS.Models.BatchViewModel>? BatchViewModel { get; set; }
        //public DbSet<Request> Requests { get; set; }

    }
}
