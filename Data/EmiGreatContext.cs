using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmiGreat.Data.Models.Authentication;

namespace EmiGreat.Data
{
    public class EmiGreatContext : IdentityDbContext<User, Role, Guid>
    {
        public EmiGreatContext(DbContextOptions<EmiGreatContext> options) : base(options) { }
        //public DbSet<User> Users { get; set; } = null!;

    }
}