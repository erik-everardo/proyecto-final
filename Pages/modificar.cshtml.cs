using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinalPrograWeb.Data;
using ProyectoFinalPrograWeb.Models;
using System.Linq;
using System;

namespace ProyectoFinalPrograWeb.Pages
{
    public class ModificarModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        public Song cancionAModificar;
        public Album nuevoAlbum;
        public ComentarioCancion nuevoComentario;
        public ModificarModel(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public IActionResult OnGet(long _id, string nombre,string artista, string album,string genero, string comentario)
        {
            nuevoAlbum = new Album();
            nuevoAlbum.Name = album;
            nuevoAlbum.Artist = artista;
            _dbContext.Albums.Add(nuevoAlbum);
            _dbContext.SaveChanges();

            nuevoComentario = new ComentarioCancion();
            nuevoComentario.Comentario = comentario;
            _dbContext.Comentarios.Add(nuevoComentario);
            _dbContext.SaveChanges();

            cancionAModificar = _dbContext.Songs.Find(_id);
            cancionAModificar.Name = nombre;
            cancionAModificar.AlbumId = nuevoAlbum.Id;
            cancionAModificar.ComentarioId = nuevoComentario.Id;
            _dbContext.Songs.Update(cancionAModificar);
            _dbContext.SaveChanges();
            
            return RedirectToPage("/Musica");
        }
    }
}
