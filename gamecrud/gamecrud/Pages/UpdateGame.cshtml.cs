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
    public class UpdateGameModel : PageModel
    {
        private readonly AppDbContext dbContext;
        public UpdateGameModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Game Game { set; get; }

        public async Task<IActionResult> OnGetAsync(int id) {
            Game = await dbContext.Games.FindAsync(id);
            if (Game == null)
            {
                return RedirectToPage("/index");
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dbContext.Attach(Game).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Game {Game.Id} not found!", e);
            }

            return RedirectToPage("/index");
        }
    }
}