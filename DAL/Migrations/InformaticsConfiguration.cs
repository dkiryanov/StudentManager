namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class InformaticsConfiguration : DbMigrationsConfiguration<DAL.Entities.Informatics.InformaticsContext>
    {
        public InformaticsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Entities.Informatics.InformaticsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
