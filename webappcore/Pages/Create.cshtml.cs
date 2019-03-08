using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webappcore.Pages {
    public class CreateModel : PageModel {

        private readonly AppDbContext db;

        private ILogger<CreateModel> log;

        public CreateModel(AppDbContext db, ILogger<CreateModel> log) {
            this.db = db;
            this.log = log;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            this.db.Customers.Add(Customer);
            await this.db.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} added!";
            Message = msg;
            log.LogInformation(msg);
            return RedirectToPage("Index");
        }
    }
}