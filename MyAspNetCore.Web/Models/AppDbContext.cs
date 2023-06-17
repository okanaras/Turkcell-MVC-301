using Microsoft.EntityFrameworkCore;

namespace MyAspNetCore.Web.Models
{
	public class AppDbContext : DbContext //1. hemen : DbContext ten miras al ve altenter la
	{
		// 2. ctor ile contructor olusturup parametreye (Dbcontextoptiosn<classAdi> options) : base(options) ile bitiyor
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; } // 3. dbSet ile Product sinifini ekle ve VT deki tablo adini yaz 
	}
	// 4. program.cs ye git app builder in hemen ustune ilgili kodu yaz
}
