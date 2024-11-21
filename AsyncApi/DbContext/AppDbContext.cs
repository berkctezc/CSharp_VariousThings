namespace AsyncApi.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<ListingRequest> ListingRequests { get; set; }
}