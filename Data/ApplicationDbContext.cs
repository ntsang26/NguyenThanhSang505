using NguyenThanhSang505.Models;
using Microsoft.EntityFrameworkCore;

namespace NguyenThanhSang505.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CompanyNTS505> CompanyNTS505s { get; set; }
  }
}