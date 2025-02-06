using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Customer.Domain.Entities
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }

}
