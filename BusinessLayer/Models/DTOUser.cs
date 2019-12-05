using System;

namespace BusinessLayer.Models
{
    /// <summary>
    /// Object for user's data transfer
    /// </summary>
    public class DTOUser
    {
        /// <summary>
        /// User's index
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User's password in md5
        /// </summary>
        public Guid Password { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string Name { get; set; }
    }
}
