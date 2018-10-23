using ColorPicker.Models;

namespace ColorPicker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ColorPicker.Models.ColorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ColorPicker.Models.ColorDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Colors.AddOrUpdate(new RGBCode(177, 161, 96) { Id = 1 });
            context.Colors.AddOrUpdate(new RGBCode(159, 87, 108) { Id = 2 });
            context.Colors.AddOrUpdate(new RGBCode(71, 131, 89) { Id = 3 });
            context.Colors.AddOrUpdate(new RGBCode(82, 73, 122) { Id = 4 });
        }
    }
}
