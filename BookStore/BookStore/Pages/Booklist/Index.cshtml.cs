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
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbConnect _db;

        public IndexModel(ApplicationDbConnect db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books{get; set;}

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
