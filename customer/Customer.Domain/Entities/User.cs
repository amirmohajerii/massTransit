using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<BaseCustomer> BaseCustomer { get; set; } = new List<BaseCustomer>(); // Initialize collection
        public ICollection<UserRole> UserRole { get; set; } = new List<UserRole>(); // Initialize collection
    }
}
