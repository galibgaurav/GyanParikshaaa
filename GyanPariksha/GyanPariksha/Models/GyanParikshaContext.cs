using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GyanPariksha.Models
{
    public class GyanParikshaContext :DbContext
    {
        private IConfigurationRoot _config;
        public GyanParikshaContext(IConfigurationRoot config)
        {
            _config = config;
        }
        public DbSet<Organization> Organizations{ get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config[""]);
        }
    }
}
