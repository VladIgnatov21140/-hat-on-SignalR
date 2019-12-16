using DataLayer.Contexts;
using DataLayer.Extensions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataLayer.ContextsInitialization
{
    /// <summary>
    /// To initialize the database and it tables 
    /// </summary>
    public class ApplicationContextInitializer
    {
        /// <summary>
        /// Migrate database and initialize database tables
        /// </summary>
        /// <param name="ConnectionString">String for connection to database</param>
        public void InitializeApplicationContext()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate();
                InitializeUsersTable(db);
            }
        }

        /// <summary>
        /// Initialize database tables
        /// </summary>
        /// <param name="db">Database context</param>
        private void InitializeUsersTable(ApplicationContext db)
        {
            if (db.Users.Count() == 0)
            {
                db.Users.AddRange(
                    new User[] {
                    new User { Login = "TestUser1", Password = new Guid(("TestPassword1").MD5Cryptography()), Name = "TestName1" },
                    new User { Login = "TestUser2", Password = new Guid(("TestPassword2").MD5Cryptography()), Name = "TestName2" },
                    new User { Login = "TestUser3", Password = new Guid(("TestPassword3").MD5Cryptography()), Name = "TestName3" },
                    new User { Login = "TestUser4", Password = new Guid(("TestPassword4").MD5Cryptography()), Name = "TestName4" }
                    });
                db.SaveChanges();
            }
        }
    }
}
