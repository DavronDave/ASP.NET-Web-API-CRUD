using Microsoft.EntityFrameworkCore;
using ThirdWebAPI.Models;

namespace ThirdWebAPI.Data
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

    }
}
