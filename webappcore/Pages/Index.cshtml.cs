using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace webappcore.Pages {
    public class IndexModel : PageModel {

        private readonly AppDbContext db;

        public IndexModel(AppDbContext db) {
            this.db = db;
        }

        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync() {
            Customers = await this.db.Customers.AsNoTracking().ToListAsync(); 
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id) {
            var customer = await this.db.Customers.FindAsync(id);

            if(customer != null) {
                this.db.Customers.Remove(customer);
                await this.db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
