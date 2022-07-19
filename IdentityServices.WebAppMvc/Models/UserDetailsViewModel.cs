using System.ComponentModel.DataAnnotations; 
namespace IdentityService.WebAppMvc.Models
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="its needed")]
        public string UserName { get; set; } = string.Empty;
        public string UserGuid { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string AplId { get; set; } = string.Empty;
        public bool HasActiveRole { get; set; }
    }
}
