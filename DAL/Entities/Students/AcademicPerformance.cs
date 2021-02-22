namespace DAL.Entities.Students
{
    public class AcademicPerformance
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int Score { get; set; }
    }
}