using IdentityService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Data
{
    public class UserDetailsDBContext : DbContext
    {
        public UserDetailsDBContext(DbContextOptions<UserDetailsDBContext> options) : base(options)
        {
            
        }
        public DbSet<UserDetails>? userDetails { get; set; }
    }
}
