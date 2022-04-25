using CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Identity.Data
{
    public class IdentitySqlDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentitySqlDbContext(DbContextOptions<IdentitySqlDbContext> options) : base(options) 
        { }


        //JWT RefreshTokens
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
