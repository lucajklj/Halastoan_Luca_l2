using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Halastoan_Luca_l2.Data;
using Halastoan_Luca_l2.Models;

namespace Halastoan_Luca_l2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context _context;

        public IndexModel(Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
