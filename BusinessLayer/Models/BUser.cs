using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    /// <summary>
    /// The object for using user's data from the data layer in the business layer
    /// </summary>
    public class BUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public Guid Password { get; set; }
        public string Name { get; set; }
    }
}
