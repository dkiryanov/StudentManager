namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class StudentsConfiguration : DbMigrationsConfiguration<Entities.Students.StudentsContext>
    {
        public StudentsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.Students.StudentsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
