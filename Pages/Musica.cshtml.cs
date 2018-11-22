using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.Data;

namespace ProyectoFinalPrograWeb.Pages
{
    public class MusicaModel : PageModel
    {
        public List<Song> SongsList;

        public List<Album> albumes;
        public Song Song{get;set;}
        public Album Album{get;set;}
        private readonly AppDbContext _dbContext;
        public string Mensaje;

        public MusicaModel(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }


        public IActionResult OnGet([FromQuery] string busqueda)
        {
            if(string.IsNullOrWhiteSpace(busqueda))
            {
                Mensaje = "Publicaciones";
                SongsList = _dbContext.Songs.ToList();
            }
            else
            {
                Mensaje = "Resultados de búsqueda";
                SongsList = _dbContext.Songs.Where(Song => Song.Name.Contains(busqueda) || Song.genero.Contains(busqueda) || _dbContext.Albums.Where(Album => Album.Name.Contains(busqueda) || Album.Artist.Contains(busqueda)).Any()).ToList();
            }
            foreach (var song in SongsList)
            {
                song.Album = _dbContext.Albums.Find(song.AlbumId);
            }
            return Page();
        }
    }
}