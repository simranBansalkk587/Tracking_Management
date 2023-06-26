using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking_Task.Models
{
    public class TrackData
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public Books Books { get; set; }
        //public int InivitedTableId { get; set; }
        //public InivitedTable InivitedTables { get; set; }
        public string Change { get; set; }
        public DateTime Trackingdate { get; set; }
    }
}
