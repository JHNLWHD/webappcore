using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webappcore.Pages {
    public class EditModel : PageModel {
        private readonly AppDbContext db;

        public EditModel(AppDbContext db) {
            this.db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            Customer = await this.db.Customers.FindAsync(id);
            if(Customer == null) {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            db.Attach(Customer).State = EntityState.Modified;

            try {
                await this.db.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException ex) {
                throw new Exception($"Customer {Customer.Id} not found.", ex);
            }
            return RedirectToPage("Index");
        }
    }
}