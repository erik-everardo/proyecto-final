using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoFinalPrograWeb.Pages
{
    public class nuevoModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public nuevoModel(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(string name,string album, string artista, string linkYT,string Comentario,string genero)
        {
            if(_dbContext.Albums.Where(Album => Album.Name.Contains(album)).Any() == true)
            {
                var comentario = new ComentarioCancion();
                comentario.Comentario = Comentario;
                _dbContext.Comentarios.Add(comentario);
                _dbContext.SaveChanges();

                var albumExistente = _dbContext.Albums.Where(Album => Album.Name.Contains(album)).ToList();
                _dbContext.Songs.Add(new Song{
                    Name = name,
                    AlbumId = albumExistente[0].Id,
                    linkYT = linkYT,
                    ComentarioId = comentario.Id,
                    genero = genero
                });
                _dbContext.SaveChanges();
            }
            else
            {
                var comentario = new ComentarioCancion();
                comentario.Comentario = Comentario;
                _dbContext.Comentarios.Add(comentario);
                _dbContext.SaveChanges();

                var nuevoAlbum = new Album(){
                    Name = album,
                    Artist = artista
                };
                _dbContext.Albums.Add(nuevoAlbum);
                _dbContext.SaveChanges();

                _dbContext.Songs.Add(new Song{
                    Name = name,
                    AlbumId = nuevoAlbum.Id,
                    linkYT = linkYT,
                    ComentarioId = comentario.Id,
                    genero = genero
                });
                _dbContext.SaveChanges();
            }

            return RedirectToPage("/Musica");
        }
    }
}