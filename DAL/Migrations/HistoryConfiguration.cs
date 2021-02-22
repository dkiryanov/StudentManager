namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class HistoryConfiguration : DbMigrationsConfiguration<Entities.History.HistoryContext>
    {
        public HistoryConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.History.HistoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
