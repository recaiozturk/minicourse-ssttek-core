namespace MiniCourse.WebUI.NLogs.DTOs
{
    public record LogViewModel
    {
        public int Id { get; set; }
        public string? MachineName { get; set; }
        public DateTime Logged { get; set; }
        public string? Level { get; set; }
        public string? Message { get; set; }
        public string? Logger { get; set; }
        public string? Exception { get; set; }
    }
}
