using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
                
        }
    }
}
