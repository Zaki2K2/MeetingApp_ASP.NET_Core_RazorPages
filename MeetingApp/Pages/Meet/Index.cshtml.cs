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
    public class IndexModel : PageModel
    {
        private readonly MeetingApp.Data.MeetMeDbContext _context;

        public IndexModel(MeetingApp.Data.MeetMeDbContext context)
        {
            _context = context;
        }

        public IList<Information> Information { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Information = await _context.Informations.ToListAsync();

            // Fetch only the non-deleted items (where Deleted is false)
            Information = await _context.Informations
                .Where(i => !i.Deleted) // Only include items that are not deleted
                .ToListAsync();

        }
    }
}
