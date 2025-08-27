using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;
using Noor_Library.ViewModel;
using System.CodeDom;

namespace Noor_Library.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public IActionResult Index() {

            var ViewModel = new ViewModelForm
            {
                authors = _context.Authors.ToList(),
                books = _context.books.ToList(),
                categories = _context.Categories.ToList(),

            };


            return View(ViewModel);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
