using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> optionsBuilder) : base(optionsBuilder)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            //                              Initial Catalog=BeautyExamenDB;
            //                              Integrated Security=true;
            //                              MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); //activer lazy loading
        }
    }
}
