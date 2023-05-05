using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Context:DbContext
    {
        public DbSet<Team> Teams {get; set;}

        public DbSet<Player> Players {get; set;} 

        public DbSet<State> States {get; set;}

        public DbSet<City> Cities {get; set;}
               
        public Context(DbContextOptions options) : base(options){}
    }
}