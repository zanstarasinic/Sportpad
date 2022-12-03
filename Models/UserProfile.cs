using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Rating[] Ratings { get; set; }
        public Sport[] Sports { get; set; }
    }
}
