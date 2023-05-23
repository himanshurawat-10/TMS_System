using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role RoleName { get; set; }
        
        public int ? ManagerId { get; set; }
        public virtual User ? Manager { get; set; }

        

        public bool IsActive { get; set; } = true;
    }

    public enum Role
    {
      
        Employee,
        Manager
      
    }
}
