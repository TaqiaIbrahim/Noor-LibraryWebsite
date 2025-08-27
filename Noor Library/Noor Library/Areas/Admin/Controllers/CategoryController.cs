using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;
using Noor_Library.Models;

namespace Noor_Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Category());
            }
            else
                return View(_context.Categories.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Category categories)
        {

            
                if (categories.Id == 0)
                    _context.Categories.Add(categories);
                else
                    _context.Categories.Update(categories);
                await _context.SaveChangesAsync();
               
            return RedirectToAction(nameof(Index)) ;

        }
        public async Task<IActionResult> Delete(int id = 0)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
