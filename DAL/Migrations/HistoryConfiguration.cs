using DAL.Entities;

namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal class HistoryConfiguration : DbMigrationsConfiguration<HistoryContext>
    {
        public HistoryConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HistoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
