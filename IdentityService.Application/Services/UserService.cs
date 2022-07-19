using IdentityService.Application.Interfaces.Repository;
using IdentityService.Application.Interfaces.Services;
using IdentityService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<UserDetails>> GetUser()
        {
            try
            {
                var user =  _userRepository.GetUser();
                return Task.FromResult(user);
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public Task<List<UserDetails>> GetUserByAplId(string AplId)
        {
            try
            {
                var user = _userRepository.GetUserByAplId(AplId);
                return Task.FromResult(user);
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public Task<UserDetails> CreateUser(UserDetails userDetails)
        {
            try
            {
                _userRepository.CreateUser(userDetails);
                return Task.FromResult(userDetails);
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public Task<UserDetails> EditUser(UserDetails userDetails)
        {
            try
            {
                _userRepository.EditUser(userDetails);
                return Task.FromResult(userDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<UserDetails> DeleteUser(string AplId)
        {
            try
            {
                var user = _userRepository.DeleteUser(AplId);
                return Task.FromResult(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
