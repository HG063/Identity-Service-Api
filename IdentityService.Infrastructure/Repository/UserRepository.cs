using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Models;
using IdentityService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDetailsDBContext _userDetailsDBContext;

        public UserRepository(UserDetailsDBContext userDetailsDBContext)
        {
            _userDetailsDBContext = userDetailsDBContext;
        }

        public List<UserDetails> GetUser()
        {
            try
            {
                return _userDetailsDBContext.userDetails.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserDetails> GetUserByAplId(String AplId)
        {
            try
            {
                return _userDetailsDBContext.userDetails.Where(x => x.AplId == AplId).ToList();
            }
            catch (Exception)
            { 
                throw;
            }

        }

        public UserDetails CreateUser(UserDetails userDetails)
        {
            try
            {
                var user = new UserDetails()
                {
                    Id = userDetails.Id,
                    AplId = userDetails.AplId,
                    UserName = userDetails.UserName,
                    RoleId = userDetails.RoleId,
                    RoleName = userDetails.RoleName,
                    HasActiveRole = userDetails.HasActiveRole
                };
                _userDetailsDBContext.userDetails.Add(user);
                _userDetailsDBContext.SaveChanges();
                return userDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserDetails EditUser(UserDetails userDetails)
        {
            try
            {
                UserDetails user = _userDetailsDBContext.userDetails.FirstOrDefault(x => x.AplId.Equals(userDetails.AplId));
                user.UserName = userDetails.UserName;
                user.RoleName = userDetails.RoleName;
                user.RoleId = userDetails.RoleId;
                user.HasActiveRole = userDetails.HasActiveRole;
                _userDetailsDBContext.SaveChanges();
                return userDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserDetails DeleteUser(string AplId)
        {
            try
            { 
                    UserDetails userDetails = _userDetailsDBContext.userDetails.FirstOrDefault(x => x.AplId.Equals(AplId));
                    _userDetailsDBContext.userDetails.Remove(userDetails);
                    _userDetailsDBContext.SaveChanges();
                    return userDetails;
            }
            catch (Exception)
            { 
                throw;
            }
            
        }
    }
}
