using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Booklist
{
    public class CreateModel : PageModel
    {
     
        private readonly ApplicationDbConnect _db;

        public CreateModel(ApplicationDbConnect db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage(PageName);

            }
            else
            {
                return Page();
            }
        }


    }  
}
