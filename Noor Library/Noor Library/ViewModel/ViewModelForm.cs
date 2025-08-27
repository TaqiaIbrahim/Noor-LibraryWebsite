using Noor_Library.Models;

namespace Noor_Library.ViewModel
{
    public class ViewModelForm
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Author> authors { get; set; }
        public IEnumerable<Book> books{ get; set; }
    }
}
