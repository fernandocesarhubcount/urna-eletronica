using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrnaAPI.Models;

namespace UrnaAPI.Data
{
    public class UrnaAPIContext : DbContext
    {
        public UrnaAPIContext (DbContextOptions<UrnaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UrnaAPI.Models.Candidate> Candidate { get; set; }

        public DbSet<UrnaAPI.Models.Vote> Vote { get; set; }
    }
}