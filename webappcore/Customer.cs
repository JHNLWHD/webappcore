using System.ComponentModel.DataAnnotations;

namespace webappcore {
    public class Customer {
        public int Id { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }

    }
}