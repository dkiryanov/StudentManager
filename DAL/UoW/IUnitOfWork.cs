namespace DAL.UoW
{
    public interface IUnitOfWork
    {
        ICourseInfoUnitOfWork History { get; }

        ICourseInfoUnitOfWork Informatics { get; }

        ICourseInfoUnitOfWork Maths { get; }

        IStudentsUnitOfWork Students { get; }
    }
}