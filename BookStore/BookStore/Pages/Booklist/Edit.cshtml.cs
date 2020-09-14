using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Booklist
{
    public class EditModel : PageModel
    {
        private ApplicationDbConnect _db;

        public EditModel(ApplicationDbConnect db)
        {
            _db = db;
        }
        [BindProperty]

        public Book Book { get; set; }
        

        
        public async Task OnGet( int id)
        {
            Book = await _db.Book.FindAsync(id); 
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var BookfromDb = await _db.Book.FindAsync(Book.Id);
                BookfromDb.Name = Book.Name;
                BookfromDb.Author = Book.Author;
                BookfromDb.ISBN = Book.ISBN;
               

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            
        }
        return RedirectToPage();
    }
}
}