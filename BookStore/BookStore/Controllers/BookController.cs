using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/Book")]

    [ApiController]
    public class BookController : Controller
    {

        public readonly ApplicationDbConnect _db;


        public BookController(ApplicationDbConnect db)
        {
            _db = db;
        }
        

        [HttpGet]
        public  IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var bookfromDb =await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookfromDb == null)
            {
                return Json(new { success = false, message = "Erroe while Deleting" });
                
            }
            _db.Book.Remove(bookfromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successfull" });

        }
        
    }
}
