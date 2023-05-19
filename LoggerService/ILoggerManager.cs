using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public interface ILoggerManager
    {
        void LogError(Exception message);
        void LogWarning(Exception message);
        void LogDebug(Exception message);
        void LogInfo(Exception message);
    }
}
