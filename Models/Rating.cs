using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public string Name { get; set; }
        public Guid User { get; set; }
    }
}
