using Serilog;
using Serilog.Events;

namespace Estel.Services.Api.Extension.Exception
{
    /// <summary>
    /// Extensions for logging errors.
    /// </summary>
    public static class ErrorLoggingExtensions
    {
        /// <summary>
        /// Log an <see cref="ApiError" /> using Serilog.
        /// </summary>
        public static void ApiError(this ILogger logger, ApiError error, LogEventLevel level = LogEventLevel.Warning)
        {
            var errorLogger = logger.ForContext("ErrorId", error.Id);
            errorLogger.Write(level, error.GetException(), error.Description);
        }
    }
}