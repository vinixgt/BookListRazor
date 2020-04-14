using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BookListRazor.Model;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var BookFromDb = await _db.Book.FindAsync(Book.id);
            BookFromDb.Name = Book.Name;
            BookFromDb.Author = Book.Author;
            BookFromDb.ISBN = Book.ISBN;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
