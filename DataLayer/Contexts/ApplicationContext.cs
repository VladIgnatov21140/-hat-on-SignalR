using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    /// <summary>
    /// Class for database context
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// String for connection to database
        /// </summary>
        private string ConnectionString {get; set;}

        /// <summary>
        /// Create context for add-migration
        /// </summary>
        public ApplicationContext()
        {
            ConnectionString = "Server=DESKTOP-COESAPT\\SQLEXPRESS;Database=ChatDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        /// <summary>
        /// Create context for use by app
        /// </summary>
        /// <param name="connectionString">String for connection to database</param>
        public ApplicationContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Data set for table Users
        /// </summary>
        public DbSet<DTOUser> Users { get; set; }

        /// <summary>
        /// Set connection string for connection to database
        /// </summary>
        /// <param name="optionsBuilder">Object for set connection parameters</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
