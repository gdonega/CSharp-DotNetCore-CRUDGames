using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamecrud.DB;
using gamecrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace gamecrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext appDbContext;
        public IndexModel(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IList<Game> Games { get; private set; }

        public async void OnGet()
        {
            Games = await appDbContext.Games.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var game = await appDbContext.Games.FindAsync(id);
            if (game != null) {

                appDbContext.Games.Remove(game);

                await appDbContext.SaveChangesAsync();

            }
            return RedirectToPage("/index");
        }
    }
}
