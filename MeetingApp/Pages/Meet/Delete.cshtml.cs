using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingApp.Data;
using MeetingApp.Models;

namespace MeetingApp.Pages.Meet
{
    public class DeleteModel : PageModel
    {
        private readonly MeetingApp.Data.MeetMeDbContext _context;

        public DeleteModel(MeetingApp.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Information Information { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Informations.FirstOrDefaultAsync(m => m.Info_id == id);

            if (information == null)
            {
                return NotFound();
            }
            else
            {
                Information = information;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Informations.FindAsync(id);
            if (information != null)
            {
                Information = information;
                _context.Informations.Remove(Information);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
