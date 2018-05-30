using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamecrud.DB;
using gamecrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gamecrud.Pages
{
    public class NewGameModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public NewGameModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            dbContext.Add(Game);

            await dbContext.SaveChangesAsync();

            return RedirectToPage("/index");
        }
    }
}