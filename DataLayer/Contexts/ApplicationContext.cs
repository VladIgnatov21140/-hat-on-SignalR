using DataLayer.Extensions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Contexts
{
    /// <summary>
    /// Class for database context
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Creating context for using by app and add-migration
        /// </summary>
        public ApplicationContext()
        {

        }

        /// <summary>
        /// Data set for table Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Seting connection string for connection to database
        /// </summary>
        /// <param name="optionsBuilder">Object for set connection parameters</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new string("").GetConnectionString());
            }
        }
    }
}
