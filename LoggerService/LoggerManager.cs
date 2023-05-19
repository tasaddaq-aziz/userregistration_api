using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(Exception message)
        {
            _logger.Debug(message);
        }

        public void LogError(Exception message)
        {
            _logger.Error(message);
        }

        public void LogInfo(Exception message)
        {
            _logger.Info(message);
        }

        public void LogWarning(Exception message)
        {
            _logger.Warn(message);
        }
    }
}
