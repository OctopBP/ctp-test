namespace RedPanda.Project.Services.Interfaces
{
    public enum LogType
    {
        Normal,
        Error
    }
    
    public interface ILogService
    {
        void Log(object message, LogType logType = LogType.Normal);
    }
}