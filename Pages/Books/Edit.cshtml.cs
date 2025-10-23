using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Halastoan_Luca_l2.Data;
using Halastoan_Luca_l2.Models;

namespace Halastoan_Luca_l2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Halastoan_Luca_l2Context _context;

        public EditModel(Halastoan_Luca_l2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        // ===========================
        //         OnGetAsync
        // ===========================
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
                return NotFound();

            // Pregătește datele pentru checkbox-urile de categorii
            PopulateAssignedCategoryData(_context, Book);

            // Pregătește dropdown-ul cu autorii
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");

            // Pregătește dropdown-ul cu publisherii
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            return Page();
        }

        // ===========================
        //         OnPostAsync
        // ===========================
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
                return NotFound();

            var bookToUpdate = await _context.Book
                .Include(i => i.Publisher)
                .Include(i => i.BookCategories)
                    .ThenInclude(i => i.Category)
                .Include(i => i.Author)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate == null)
                return NotFound();

            // Actualizează valorile din formular
            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "Book",
                i => i.Title,
                i => i.AuthorID,        
                i => i.Price,
                i => i.PublishingDate,
                i => i.PublisherID))
            {
                // Actualizează categoriile
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Dacă validarea nu trece
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }
}
