using Microsoft.EntityFrameworkCore;
using ProyectoFinalPrograWeb.Models;
namespace ProyectoFinalPrograWeb.Data
{
    public class AppDbContext : DbContext
    {
        //Extend the constructor
        public AppDbContext(DbContextOptions options) :
        base(options) { }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<ComentarioCancion> Comentarios{get;set;}
    }
}