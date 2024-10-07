using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetingApp.Data;
using MeetingApp.Models;

namespace MeetingApp.Pages.Meet
{
    public class CreateModel : PageModel
    {
        private readonly MeetingApp.Data.MeetMeDbContext _context;

        public CreateModel(MeetingApp.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Information Information { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Automattically selects the time when meeting is Created
            Information.EntryRecord = DateTime.Now;

            _context.Informations.Add(Information);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
