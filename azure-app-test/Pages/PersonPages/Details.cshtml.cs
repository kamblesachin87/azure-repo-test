using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_test.Data;

namespace azure_app_test.Pages.PersonPages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

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
}
