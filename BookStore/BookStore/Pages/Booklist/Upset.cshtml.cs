using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.Booklist
{
    public class UpsetModel : PageModel
    {
        private ApplicationDbConnect _db;

        public UpsetModel(ApplicationDbConnect db)
        {
            _db = db;
        }
        [BindProperty]

        public Book Book { get; set; }



        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                //create
                return Page();
            }
            //update
            Book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page(); 
        
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {

                if (Book.Id == 0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}

