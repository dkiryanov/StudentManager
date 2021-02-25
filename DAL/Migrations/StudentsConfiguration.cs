namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class StudentsConfiguration : DbMigrationsConfiguration<Entities.Students.StudentManagerContext>
    {
        public StudentsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Entities.Students.StudentManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
