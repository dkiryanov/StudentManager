using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Entities
{
    public class MathsContext : DbContext
    {
        public MathsContext() : base("MathsContext")
        { }

        public DbSet<CourseInfo> CourseInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // To remove the requests to the Migration History table
            Database.SetInitializer<MathsContext>(null);
            // To remove the plural names   
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}