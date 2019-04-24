using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Models
{
    public class CarDetailContext:DbContext
    {
        public CarDetailContext(DbContextOptions<CarDetailContext> options) : base(options)
        {

        }

        public DbSet<CarDetails> CarDetails { get; set; }
    }
}
