using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    /// <summary>
    /// The entity for using the user's data
    /// </summary>
    public class User
    {
        /// <summary>
        /// The primary key for a user with autoincrement
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User's unique login
        /// </summary>
        [ForeignKey("FK_Login")]
        [Column(TypeName = "varchar(50)")]
        public string Login { get; set; }

        /// <summary>
        /// User's password in md5
        /// </summary>
        [Required]
        public Guid Password { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }
    }
}
