using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    // Context:  Db tabloları ile proje classlarını bağlamaya yarar.
    public class NortwindContext : DbContext
    {
        // öncelikle benim veritabanım tam olarak şurada diye göstermeliyiz


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // bu metot, projemizin hangi veritabanı ile ilişkili olduğunu belirteceğimiz yerdir.


            // connection string

            optionsBuilder.UseSqlServer(@"Server = abdulkadirf17; Database=Northwind; Trusted_Connection = true");


        }
            //      classım  | tablo karşılığı
        public DbSet<Product> Products { get; set; }      // benim hangi nesnem, veritabanında hangi tabloya karşılık gelecek, onu bildirdiğimiz kısım.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
