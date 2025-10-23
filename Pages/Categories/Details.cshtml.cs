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
    public class DetailsModel : PageModel
    {
        private readonly Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context _context;

        public DetailsModel(Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
