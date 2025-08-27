using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;
using Noor_Library.Models;

namespace Noor_Library.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Contact contact )
        {
            if (contact.Id == 0)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
    }
}
