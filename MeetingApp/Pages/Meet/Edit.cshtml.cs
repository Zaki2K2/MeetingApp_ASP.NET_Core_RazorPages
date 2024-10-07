using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingApp.Data;
using MeetingApp.Models;

namespace MeetingApp.Pages.Meet
{
    public class EditModel : PageModel
    {
        private readonly MeetingApp.Data.MeetMeDbContext _context;

        public EditModel(MeetingApp.Data.MeetMeDbContext context)
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

            var information =  await _context.Informations.FirstOrDefaultAsync(m => m.Info_id == id);
            if (information == null)
            {
                return NotFound();
            }
            Information = information;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(Information.Info_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        // Add this method to your EditModel class
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var information = await _context.Informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            // Mark as deleted
            information.Deleted = true;

            _context.Informations.Update(information);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool InformationExists(Guid id)
        {
            return _context.Informations.Any(e => e.Info_id == id);
        }
    }
}
