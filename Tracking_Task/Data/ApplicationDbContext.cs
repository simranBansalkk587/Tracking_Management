using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Models;

namespace Tracking_Task.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet <User>Users { get; set; }
        public DbSet <InivitedTable>InivitedTables { get; set; }
        public DbSet <TrackDetail>TrackDetails { get; set; }
    }
}
