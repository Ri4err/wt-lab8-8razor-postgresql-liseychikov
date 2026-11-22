using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_liseychikov.Data;
using wt_lab8_8razor_postgresql_liseychikov.Models;

namespace wt_lab8_8razor_postgresql_liseychikov.Pages.Tasks;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskModel Task { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Tasks.Add(Task);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}