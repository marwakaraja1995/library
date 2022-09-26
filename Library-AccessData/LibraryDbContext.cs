using Library_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.IO;

namespace Library_AccessData
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB ; Initial Catalog= LibraryDatabase")
                .LogTo(log => Log.WriteLog(log),
                            new[] { DbLoggerCategory.Database.Command.Name },
                           Microsoft.Extensions.Logging.LogLevel.Information)
                           .EnableSensitiveDataLogging();

        }
       
        
        
        

    }
    
    
}

    


    
