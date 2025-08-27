using Microsoft.AspNetCore.Mvc;
using Noor_Library.Data;
using Noor_Library.Models;

namespace Noor_Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        
            private readonly ApplicationDbContext _context;
            public SliderController(ApplicationDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View(_context.Sliders.ToList());
            }
            public IActionResult AddOrEdit(int id)
            {
            if(id==0)
            return View(new Slider());
            else
                return View(_context.Sliders.Find(id));
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Slider slider,List<IFormFile> ImageFile)
        {
            foreach (var file in ImageFile)
            {
                if(file.Length>0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var Image =Guid.NewGuid().ToString()+ext;
                    var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Images", Image);
                   
                    using (var stream = System.IO.File.Create(pathFile))
                    {
                        file.CopyTo(stream);
                    }
                    slider.Image= Image;

                }
            }
            if(slider.Id==0) 
                _context.Sliders.Add(slider);
            else
                _context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction( nameof(Index));


        }
    }
   
    }
 

