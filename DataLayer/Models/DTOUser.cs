using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class DTOUser
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FK_Login")]
        [Column(TypeName = "varchar(50)")]
        public string Login { get; set; }
        [Required]
        public Guid Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }
    }
}
