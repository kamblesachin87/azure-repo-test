using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_test.Data;

namespace azure_app_test.Pages.PersonPages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Person Person { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);
        if (person is null)
        {
            return NotFound();
        }
        else
        {
            Person = person;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FindAsync(id);
        if (person != null)
        {
            Person = person;
            _context.Persons.Remove(Person);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
