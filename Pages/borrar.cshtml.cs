using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinalPrograWeb.Data;

namespace ProyectoFinalPrograWeb.Pages
{

    public class borrarModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        public borrarModel(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public IActionResult OnGet([FromQuery] long _id)
        {
            var CancionAEliminar = _dbContext.Songs.Find(_id);
            if(CancionAEliminar != null)
            {
                _dbContext.Remove(CancionAEliminar);
            }
            _dbContext.SaveChanges();
            return RedirectToPage("Musica/");
        }
    }
}
