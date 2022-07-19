using IdentityService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<UserDetails> GetUserByAplId(string AplId);
        List<UserDetails> GetUser();
        UserDetails CreateUser(UserDetails userDetails);
        UserDetails EditUser(UserDetails userDetails);
        UserDetails DeleteUser(string AplId);

    }
}
