using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noor_Library.Data;
using Noor_Library.Models;

namespace Noor_Library.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController( ApplicationDbContext context)
        {
                 _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new Author());
            }
            else
                return View(_context.Authors.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Author model,List<IFormFile> ImageFile)
        {
       
            foreach (var file in ImageFile)
            {
                if(file.Length > 0)
                {
                    var ext=Path.GetExtension(file.FileName);
                    var Image = Guid.NewGuid().ToString() + ext;
                    var pathFile=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/uploads/Images",Image);
                    using (var stream= System.IO.File.Create(pathFile))
                    {
                       file.CopyTo(stream);
                    }
                    model.Image= Image;
                }
            }
           

            if (model.Id == 0)
                _context.Authors.Add(model);
            else
                _context.Authors.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public async Task<IActionResult>Delete(int id)
        {
            var author= _context.Authors.Find(id);
             _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
