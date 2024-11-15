namespace MiniCourse.Repository.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
