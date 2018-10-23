using System.Data.Entity;

namespace ColorPicker.Models
{
    public class ColorDbContext : DbContext
    {
        public DbSet<RGBCode> Colors { get; set; }
    }
}