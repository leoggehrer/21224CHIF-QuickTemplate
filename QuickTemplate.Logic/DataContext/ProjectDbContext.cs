using Microsoft.EntityFrameworkCore;
using QuickTemplate.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.DataContext
{
    internal partial class ProjectDbContext : DbContext
    {
        private static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=MusicStoreDb;Integrated Security=True";
        public DbSet<Artist> ArtistSet { get; set; }
        public DbSet<Album> AlbumSet { get; set; }
        public virtual DbSet<E> GetDbSet<E>() where E : IdentityObject
        {
            DbSet<E> result = null;

            if (typeof(E) == typeof(Artist))
            {
                result = ArtistSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Album))
            {
                result = AlbumSet as DbSet<E>;
            }
            else
            {
                result = Set<E>();
            }
            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
