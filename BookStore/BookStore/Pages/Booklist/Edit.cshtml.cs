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
    }
}
