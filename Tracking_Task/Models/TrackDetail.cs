using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking_Task.Models
{

    public class TrackDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int InivitedTableId { get; set; }
        public InivitedTable InivitedTable { get; set; }
        public int BookId { get; set; }
        public Books Books { get; set; }
        public string Perviouschange { get; set; }
        public DateTime Trackingdate { get; set; }

    }
}
