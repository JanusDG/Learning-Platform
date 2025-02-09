using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearningPlatform.Data;
using LearningPlatform.Models;

namespace LearningPlatform.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly LearningPlatform.Data.LearningPlatformDbContext _context;

        public DetailsModel(LearningPlatform.Data.LearningPlatformDbContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (user is not null)
            {
                User = user;

                return Page();
            }

            return NotFound();
        }
    }
}
