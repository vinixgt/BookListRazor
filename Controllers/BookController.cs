// shaaron.flores@banrural.com.gt
/*
    diferimiento de plazo. 264 cuotas. 
    diferimiento de pago.
    a banrural.f

    6
    con relacion tramite de seguimiento de pago. debido a la situacion de correspondeinte por covid 19
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BookListRazor.Model;

namespace BookListRazor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookfromDb = await _db.Book.FirstOrDefaultAsync(u => u.id == id);
            if(bookfromDb == null) {
                return Json(new { success = false, message = "Error while Deleting"});
            }
            _db.Book.Remove(bookfromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}