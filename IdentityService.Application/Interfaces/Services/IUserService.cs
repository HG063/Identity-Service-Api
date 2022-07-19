using IdentityService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task <List<UserDetails>> GetUserByAplId(string AplId);
        Task <List<UserDetails>> GetUser();
        Task <UserDetails> CreateUser(UserDetails userDetails);
        Task <UserDetails> EditUser(UserDetails userDetails);
        Task <UserDetails> DeleteUser(string AplId);


    }
}
