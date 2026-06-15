using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SubscribedEventVM
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public bool IsAttended { get; set; }
    }
}
