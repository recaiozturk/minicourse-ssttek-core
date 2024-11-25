namespace MiniCourse.Service.Shared
{
    public class CustomException : Exception
    {
        public string CustomSource { get; }
        public string CustomStackTrace { get; }

        public CustomException(string message, string customSource, string customStackTrace)
            : base(message)
        {
            CustomSource = customSource;
            CustomStackTrace = customStackTrace;
        }

        public override string StackTrace => CustomStackTrace;
    }
}
