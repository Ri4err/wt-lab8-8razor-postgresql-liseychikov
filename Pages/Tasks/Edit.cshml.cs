using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_liseychikov.Data;
using wt_lab8_8razor_postgresql_liseychikov.Models;

namespace wt_lab8_8razor_postgresql_liseychikov.Pages.Tasks;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskModel Task { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var taskItem = await _context.Tasks.FindAsync(id);
        if (taskItem == null)
        {
            return NotFound();
        }

        Task = taskItem;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Tasks.AnyAsync(e => e.Id == Task.Id);
            if (!exists)
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToPage("./Index");
    }
}