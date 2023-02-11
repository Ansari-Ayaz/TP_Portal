using Microsoft.EntityFrameworkCore;
using TP_API.Models.DBModels;

namespace TP_API.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<User> TP_User { get; set; }
        public DbSet<CandidateDetail> TP_CandidateDetail { get; set; }
        public DbSet<Option> TP_Options { get; set; }
        public DbSet<Question> TP_Question { get; set; }
        public DbSet<TestDetail> TP_TestDetail { get; set; }
        public DbSet<Results> TP_Results { get; set; }
        public DbSet<Schedule> TP_Schedule { get; set; }
        public DbSet<FResult> TP_FResults { get; set; }


    }
    
}
