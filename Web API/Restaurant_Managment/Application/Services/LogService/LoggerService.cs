using Serilog;

namespace Application.Services.LogService;

public class LoggerService : ILoggerService
{
    public void LogError(string message, Exception exception) =>
        Log.Error(message, exception);

    public void LogInfo(string message) =>
        Log.Information(message);

    public void LogWarning(string message) =>
        Log.Warning(message);
}