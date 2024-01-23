using Car.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data
{

        public class CarContext : DbContext
        {
            public CarContext
                (
                    DbContextOptions<CarContext> options
                ) : base(options) { }

            public DbSet<Cars> CarShop { get; set; }

        }
    }


