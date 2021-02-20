﻿namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class MathsConfiguration : DbMigrationsConfiguration<Entities.Maths.MathsContext>
    {
        public MathsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.Maths.MathsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}