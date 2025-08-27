using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;

namespace Noor_Library.Controllers
{
    public class SliderController : Controller
    {
        private readonly  ApplicationDbContext _context;
        public SliderController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult AddOrEdit()
        {
            return View(_context.Sliders.ToList());
        }
    }
}
