using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MaximumNumber { get; set; }

        public Location Location { get; set; }
        public Sport Sport { get; set; }


    }
}
