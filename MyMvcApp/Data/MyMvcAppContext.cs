using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public class MyMvcAppContext : DbContext
    {

        public MyMvcAppContext (DbContextOptions<MyMvcAppContext> options)
            : base(options)
        {
        }

        public DbSet<Projets> Projets { get; set; } = default!;
        public DbSet<ConnectUser> ConnectUsers { get; set; }= default!;
    }
}
