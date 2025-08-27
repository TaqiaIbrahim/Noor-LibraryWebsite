using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noor_Library.Data;
using Noor_Library.ViewModel;

namespace Noor_Library.Controllers
{
    public class AuthorController:Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ViewModel = new ViewModelForm
            {
                authors = _context.Authors.ToList(),
                books = _context.books.ToList(),
                categories = _context.Categories.ToList(),

            };


            return View(ViewModel);
        }
        public IActionResult Details(int?id)
        {
            if (id == null)
                return BadRequest();
            var author = _context.Authors.Include(e=>e.Books).SingleOrDefault(m => m.Id == id);
            if (author == null)
                return NotFound();

            return View(author);
        }
    }
}
