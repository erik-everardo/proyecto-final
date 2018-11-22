using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.Models
{
    public class Song
    {
        public long Id {get;set;}
        public string Name {get;set;}
        public long AlbumId {get;set;}
        public string linkYT {get;set;}
        public string genero {get;set;}


        public Album Album{get;set;}
        public long ComentarioId {get;set;}
    }
}
