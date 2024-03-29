﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public DetailsModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public Scripture Scripture { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var scripture = await _context.Scripture
                .Include(s => s.Book)
                .FirstOrDefaultAsync(m => m.ScriptureId == id);
            if (scripture == null)
            {
                return NotFound();
            }
            else 
            {
                Scripture = scripture;
            }
            return Page();


        }
    }
}
