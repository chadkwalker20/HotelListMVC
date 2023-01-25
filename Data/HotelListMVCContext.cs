using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelListMVC.Models;

namespace HotelListMVC.Data
{
    public class HotelListMVCContext : DbContext
    {
        public HotelListMVCContext (DbContextOptions<HotelListMVCContext> options)
            : base(options)
        {
        }

        public DbSet<HotelListMVC.Models.Guest> Guest { get; set; } = default!;
    }
}
