using System;

namespace Sportpad.Models
{
    public class EventUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}
