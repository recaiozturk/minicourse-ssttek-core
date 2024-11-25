namespace MiniCourse.Service.Nlogs.DTOs
{
    public record ExceptionRequest
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
