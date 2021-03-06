using NLog;
using NLog.Config;
using NLog.Targets;

namespace EndlessEngine.Core
{
    public static class Log
    {
        static Log()
        {
            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new FileTarget("logfile") {FileName = "log.txt"};
            var logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            Instance = LogManager.GetCurrentClassLogger();
        }

        public static Logger Instance { get; }
    }
}