using System.ComponentModel.DataAnnotations;

namespace ProjeKamp.Models
{
    public class Role
    {
        [Display(Name = "Rol ID")]
        public int RoleId { get; set; }

        [Display(Name = "Rol Detay")]
        public string RoleDetail { get; set; }
    }
}
