using MiniCourse.Repository.Logs;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.NLogs
{
    public class NLogrepository(AppDbContext context) : GenericRepository<Log>(context), INLogrepository
    {
    }
}
