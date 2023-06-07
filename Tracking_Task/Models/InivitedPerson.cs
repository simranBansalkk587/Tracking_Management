using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking_Task.Models
{
    public class InivitedPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InivitedTableId { get; set; }
        public InivitedTable InivitedTable { get; set; }
      

    }
}
