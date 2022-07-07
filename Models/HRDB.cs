using Microsoft.EntityFrameworkCore;
using todoList.Models;

namespace todoList.Models
{
    public class HRDB : DbContext // inhert
    {
        public DbSet<List> Lists { get; set; } // any instances from Lists and data type is Dbset 

        // will overrad fun. from DbContext 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection
            optionsBuilder.UseSqlServer(@"data source=razan\sqlexpress01; initial catalog=List ; integrated security=SSPI;");
        }

    }
}
