using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webappcore.Pages {
    public class CreateModel : PageModel {

        private readonly AppDbContext db;

        public CreateModel(AppDbContext db) {
            this.db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            this.db.Customers.Add(Customer);
            await this.db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}