using backend.Model.StaffDB;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class StaffDBContext:DbContext
    {
        public DbSet<MsStaff> MsStaff { get; set; }
        public StaffDBContext(DbContextOptions<StaffDBContext> options) : base(options){ 
        }
    }
}
