using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MobyIpsumAPI.Data
{
    public class MobyContext : DbContext
    {
        public DbSet<Novel> Novels { get; set; }
        public string DbPath { get; }

        public MobyContext()
        {
            var path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, @"/db/data.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    [Table("NOVELS")]
    public class Novel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Opening { get; set; }
    }
}
