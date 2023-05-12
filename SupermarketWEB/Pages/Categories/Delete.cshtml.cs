using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;        
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {   
                return NotFound();
            }

			var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

			if (Category == null)
			{
				return NotFound();
            }
            else
            {
                Category = Category;
            }
            return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var category = await _context.Categories.FindAsync(id);

			if (Category == null)
			{
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
			}
			return RedirectToPage("/.index");
		}

	}
}
