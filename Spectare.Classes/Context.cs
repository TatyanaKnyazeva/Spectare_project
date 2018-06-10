using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectare.Classes
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public Context() : base("SpectareDb")
        {

        }
    }
}
