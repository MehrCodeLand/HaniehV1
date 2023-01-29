using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MyDbFile
{
    public class MyDb : DbContext
    {
        public MyDb(DbContextOptions<MyDb> options ) : base( options )
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Paint> Paints { get; set; }
    }
}
