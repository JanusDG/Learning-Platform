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
    public class IndexModel : PageModel
    {
        private readonly LearningPlatform.Data.LearningPlatformDbContext _context;

        public IndexModel(LearningPlatform.Data.LearningPlatformDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
