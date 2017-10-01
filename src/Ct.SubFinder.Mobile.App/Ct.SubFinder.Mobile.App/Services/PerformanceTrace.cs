using Ct.App.Infrastructure.Interfaces;
using System;

namespace Ct.SubFinder.Mobile.App.Services
{
    public class PerformanceTrace : IPerformanceTrace
    {        
        public void CreateLog(Marker marker, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            //_logger.LogInformation($"time={DateTime.UtcNow.ToString("o")}, marker={marker}, member-name={memberName}, source-file-path={sourceFilePath}, source-line-number={sourceLineNumber}");
        }
    }
}
