using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Halastoan_Luca_l2.Data;
using Halastoan_Luca_l2.Models;

namespace Halastoan_Luca_l2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context _context;

        public CreateModel(Halastoan_Luca_l2.Data.Halastoan_Luca_l2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            var Book = new Book();
            Book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, Book);
            return Page();
        }

        [BindProperty]
        public Book book { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            book.BookCategories = newBook.BookCategories;
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
