using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OechsleTest.WebApi.Models;

namespace OechsleTest.WebApi.Data
{
    public class DataApiContext : DbContext
    {
        public DataApiContext (DbContextOptions<DataApiContext> options)
            : base(options)
        {
        }

        public DbSet<OechsleTest.WebApi.Models.Employee> Employee { get; set; } = default!;
    }
}
