using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_liseychikov.Data;
using wt_lab8_8razor_postgresql_liseychikov.Models;

namespace wt_lab8_8razor_postgresql_liseychikov.Pages.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public List<TaskModel> Tasks { get; set; } = new();

    public async Task OnGetAsync()
    {
        var query = _context.Tasks.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(t => t.Name.Contains(Search));
        }

        Tasks = await query
            .OrderBy(t => t.Id)
            .ToListAsync();
    }
}