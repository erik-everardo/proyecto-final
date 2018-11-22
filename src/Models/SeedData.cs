using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ProyectoFinalPrograWeb.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPrograWeb.Models;

namespace ProyectoFinalPrograWeb.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
                {
                    context.Database.EnsureCreated();
                    if(context.Songs.Any())
                    {
                        return;
                    }

                    Album EndlessFormsMostBeautiful = new Album();
                    EndlessFormsMostBeautiful.Name = "Endless Forms Most Beautiful";
                    EndlessFormsMostBeautiful.Artist = "Nightwish";
                    context.Add(EndlessFormsMostBeautiful);
                    context.SaveChanges();

                    ComentarioCancion ComentarioInicial = new ComentarioCancion();
                    ComentarioInicial.Comentario = "Esto es un comentario";
                    context.Comentarios.Add(ComentarioInicial);
                    context.SaveChanges();

                    context.Add(new Song(){
                        Name = "Endless Forms Most Beautiful",
                        AlbumId = EndlessFormsMostBeautiful.Id,
                        linkYT = "https://www.youtube.com/watch?v=VUb1p8fm7Ag",
                        ComentarioId = ComentarioInicial.Id,
                        genero = "Metal sinfónico"
                    });
                    context.SaveChanges();
                }
        }
    }
}