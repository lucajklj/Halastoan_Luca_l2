
using Halastoan_Luca_l2.Models;
namespace Halastoan_Luca_l2.Models.ViewModels;

public class CategoryIndexData
{
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Book> Books { get; set; }

}
