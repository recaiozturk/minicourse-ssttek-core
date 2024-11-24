namespace MiniCourse.WebUI.NLogs.ViewModels
{
    public class ErrorLogDto
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}
