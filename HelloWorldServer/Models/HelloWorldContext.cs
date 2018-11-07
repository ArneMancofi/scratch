using Microsoft.EntityFrameworkCore;

namespace HelloWorldServer.Models
{
  public class HelloWorldContext : DbContext
  {
    public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options) { }

    public DbSet<PensionCompany> PensionCompanies { get; set; }
  }
}