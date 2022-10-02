using FriendsDirectoryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsDirectoryWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FriendList> friendLists { get; set; }
    }
}
