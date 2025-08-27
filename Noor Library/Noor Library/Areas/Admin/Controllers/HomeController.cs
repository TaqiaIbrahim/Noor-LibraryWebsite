using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;
using Noor_Library.ViewModel;

namespace Noor_Library.Areas.Admin.Controllers
{
    [Authorize (Roles ="Admin")]
   
    [Area("Admin")]
    public class HomeController: Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            int bookCount=_context.books.Count ();
            int categoryCount = _context.Categories.Count();
            int authorCount = _context.Authors.Count();
            int contactCount=_context.Contacts.Count();
            ViewBag.BookCount = bookCount;
            ViewBag.CategoryCount = categoryCount;  
            ViewBag.AuthorCount = authorCount;
            ViewBag.ContactCount = contactCount;

            var viewModel = new ViewModelForm
            {
                books = _context.books.ToList().Take(4),
                categories = _context.Categories.ToList(),
                authors = _context.Authors.ToList().Take(5)

            };
            return View(viewModel);
        }
    }
}
