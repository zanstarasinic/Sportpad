using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MaximumNumber { get; set; }

        public Guid LocationId { get; set; }
        public Guid SportId { get; set; }

    }
}
