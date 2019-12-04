using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataLayer.ContextsInitialization
{
    /// <summary>
    /// To initialize the database and database tables 
    /// </summary>
    public class ApplicationContextInitializer
    {
        /// <summary>
        /// Migrate database and initialize database tables
        /// </summary>
        /// <param name="ConnectionString">String for connection database</param>
        public void InitializeApplicationContext(string ConnectionString)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
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
                    new DTOUser[] {
                    new DTOUser { Login = "TestUser1", Password = new Guid(MD5Cryptography("TestPassword1")), Name = "TestName1" },
                    new DTOUser { Login = "TestUser2", Password = new Guid(MD5Cryptography("TestPassword2")), Name = "TestName2" },
                    new DTOUser { Login = "TestUser3", Password = new Guid(MD5Cryptography("TestPassword3")), Name = "TestName3" },
                    new DTOUser { Login = "TestUser4", Password = new Guid(MD5Cryptography("TestPassword4")), Name = "TestName4" }
                    });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Encryption input string by MD5 method
        /// </summary>
        /// <param name="inputstr">String for encryption</param>
        /// <returns>Encrypted input string by MD5 method</returns>
        public string MD5Cryptography(string inputstr)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(inputstr));
            StringBuilder resultstring = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                resultstring.Append(data[i].ToString("x2"));
            }
            return resultstring.ToString();
        }
    }
}
