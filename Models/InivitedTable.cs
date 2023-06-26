using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking_Task.Models
{
    public class InivitedTable
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }
        public TrackStatus Status { get; set; }
        public List<InivitedPerson> InvitedPeople { get; set; }
    }
}


