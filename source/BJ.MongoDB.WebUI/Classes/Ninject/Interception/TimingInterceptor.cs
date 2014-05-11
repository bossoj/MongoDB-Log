using System.Diagnostics;
using System.Reflection;

using log4net;
using Ninject.Extensions.Interception;

namespace BJ.MongoDB.WebUI.Ninject
{
    /// <summary>
    /// Перехватчик для вычисления времени выполнения методов
    /// </summary>
    public class TimingInterceptor : SimpleInterceptor
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private readonly Stopwatch _stopwatch = new Stopwatch();

        protected override void BeforeInvoke(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            _stopwatch.Stop();

            string message = string.Format("{0}.{1}(), время выполнения = {2}", 
                invocation.Request.Target, 
                invocation.Request.Method.Name, 
                _stopwatch.Elapsed );

            Trace.WriteLine(message);
            
            if (_log.IsDebugEnabled) 
                _log.Debug(message);

            _stopwatch.Reset();
        }
    }
}