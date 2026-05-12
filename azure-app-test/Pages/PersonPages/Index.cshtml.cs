using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_test.Data;

namespace azure_app_test.Pages.PersonPages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Person> Person { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Person = await _context.Persons.ToListAsync();
    }
}
