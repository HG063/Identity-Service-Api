using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Models
{
    public class UserDetails
    {

        [Key]
        //[System.Text.Json.Serialization.JsonIgnore]
        public int Id{ get; set;}
        public string UserName { get; set; } = string.Empty;
        public string UserGuid { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string RoleName { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string AplId { get; set; } = string.Empty;
        public bool HasActiveRole { get; set; }
    }
}
