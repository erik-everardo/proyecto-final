using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinalPrograWeb.Data;
using ProyectoFinalPrograWeb.Models;

namespace ProyectoFinalPrograWeb.Pages
{
    public class CancionModel : PageModel
    {
        public Song cancion{get;set;}
        public Album album{get;set;}
        public ComentarioCancion comentario{get;set;}
        private readonly AppDbContext _dbContext;
        public CancionModel(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public IActionResult OnGet([FromQuery]long _id)
        {
            cancion = _dbContext.Songs.Where(Song => Song.Id == _id).Single();
            album = _dbContext.Albums.Where(album => album.Id == cancion.AlbumId).Single();
            comentario = _dbContext.Comentarios.Where(comentario => comentario.Id == cancion.ComentarioId).Single();
            return Page();
        }
    }
}
