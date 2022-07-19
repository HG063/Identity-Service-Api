using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityService.Api.Controllers
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string UserGuid { get; set; } = "";
        public string RoleName { get; set; } = "";
        public int RoleId { get; set; }
        public string AplId { get; set; } = "";
        public bool HasActiveRole { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class Users1Controller : ControllerBase
    {
        static List<Users> users = new List<Users>
        {
            new Users{Id = 1,UserName = "Ankit", UserGuid = "04A95C41-E98C-1910-E9B0-E7F9F2B609CD", RoleName = "Agent", RoleId = 1, AplId = "UR1234", HasActiveRole = true},
            new Users{Id = 2,UserName = "Rohan", UserGuid = "23N234D1-H8F8-8329-J4I2-J23NKI2B46J2", RoleName = "Client", RoleId = 2, AplId = "UR7328", HasActiveRole = true},
            new Users{Id = 3,UserName = "Ram", UserGuid = "32BBI23I-H4V2-5425-S4K2-H32KNK2G2OM2", RoleName = "Agent", RoleId = 1, AplId = "UR9832", HasActiveRole = false},
            new Users{Id = 4,UserName = "Priya", UserGuid = "5M4GH3KH-F4H5-6242-V8K2-H4V3IN2O4NO4", RoleName = "Client", RoleId = 2, AplId = "UR4324", HasActiveRole = true},
            new Users{Id = 5,UserName = "Mohan", UserGuid = "4NI3G3IN-4N5U-5629-H2N2-G4U3NK3N2KN4", RoleName = "Agent", RoleId = 1, AplId = "UR5234", HasActiveRole = false},
        };
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET api/<UsersController>/AplID
        [HttpGet("{AplId}")]
        public Users Get(String AplId)
        {
            return users.Single(x => x.AplId.Equals(AplId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] Users u)
        {
            users.Add(u);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{AplId}")]
        public void Put([FromBody] Users u)
        {
            int index = users.FindIndex(x => x.AplId.Equals(u.AplId));
            users[index] = u;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{AplId}")]
        public void Delete(String AplId)
        {
            int index = users.FindIndex(x => x.AplId.Equals(AplId));
            users.RemoveAt(index);
        }
    }
}
