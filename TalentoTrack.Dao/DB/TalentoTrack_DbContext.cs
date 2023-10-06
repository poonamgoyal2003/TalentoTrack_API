using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Entities;

namespace TalentoTrack.Dao.DB
{
    public class TalentoTrack_DbContext : DbContext
    {
        public DbSet<User> tbl_user { get; set; }
        public DbSet<LoginDetails> tbl_login_details { get; set; }
        public DbSet<Course> tbl_Course_details { get; set; }
        public DbSet<Batch> tbl_Batch_details { get; set; }

        public TalentoTrack_DbContext(DbContextOptions<TalentoTrack_DbContext> options)
            : base(options) { }
    }
}
