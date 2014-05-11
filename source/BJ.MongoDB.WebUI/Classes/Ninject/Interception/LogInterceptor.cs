using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using Ninject.Extensions.Interception;

namespace BJ.MongoDB.WebUI.Ninject
{
    /// <summary>
    /// Перехватчик для логирования выполнения методов (с поддержкой логирования ошибок)
    /// </summary>
    public class LogInterceptor : SimpleFailureInterceptor
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool _hasError = false;

        /// <summary>
        /// Признак отображения аргументов метода
        /// </summary>
        private bool _showArguments;

        /// <summary>
        /// Список методов, которые не отображаются
        /// </summary>
        private List<string> _hideMethodList = new List<string>();

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="showArguments">Признак отображения аргументов метода</param>
        public LogInterceptor(bool showArguments = true)
        {
            _showArguments = showArguments;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="showArguments">Признак отображения аргументов метода</param>
        /// <param name="hideMethod">Список методов, аргументы которых не отображаются</param>
        public LogInterceptor(bool showArguments, params string[] hideMethod)
        {
            _showArguments = showArguments;
            _hideMethodList = hideMethod.ToList();
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="showArguments">Признак отображения аргументов метода</param>
        /// <param name="hideMethod">Список методов, аргументы которых не отображаются</param>
        public LogInterceptor(bool showArguments, IEnumerable<string> hideMethod)
        {
            _showArguments = showArguments;
            if (hideMethod != null) _hideMethodList = hideMethod.ToList();
        }

        /// <summary>
        /// Метод выповняется до вызова целевого метода
        /// </summary>
        /// <param name="invocation">Экземпляр вызова</param>
        protected override void BeforeInvoke(IInvocation invocation)
        {
            string strArguments = String.Empty;
            if (_showArguments 
                && invocation.Request.Arguments.Length > 0 
                && !_hideMethodList.Contains(MethodNameFor(invocation)))
                strArguments = ArgumentsFor(invocation);

            _log.DebugFormat("{0}.{1}({2}), Start", ClassNameFor(invocation), MethodNameFor(invocation), strArguments);
        }

        /// <summary>
        /// Метод выповняется в случае ошибке
        /// </summary>
        /// <param name="invocation">Экземпляр вызова</param>
        /// <param name="exception">Ошибка</param>
        protected override void OnError(IInvocation invocation, Exception exception)
        {
            _log.Error(String.Format("{0}.{1}(), Error", ClassNameFor(invocation), MethodNameFor(invocation)), exception);
            _hasError = true;

            base.OnError(invocation, exception);
        }
        
        /// <summary>
        /// Метод выповняется до после целевого метода
        /// </summary>
        /// <param name="invocation">Экземпляр вызова</param>
        protected override void AfterInvoke(IInvocation invocation)
        {
            _log.DebugFormat("{0}.{1}(), End {2}", ClassNameFor(invocation), MethodNameFor(invocation), (_hasError ? "with an error state" : "successfully"));
        }

        private static string MethodNameFor(IInvocation invocation)
        {
            return invocation.Request.Method.Name;
        }

        private static string ClassNameFor(IInvocation invocation)
        {
            return invocation.Request.Target.ToString();
        }

        private static string ArgumentsFor(IInvocation invocation)
        {
            var arguments = new StringBuilder();

            for (int i = 0; i < invocation.Request.Arguments.Length; i++)
            {
                string name = invocation.Request.Method.GetParameters()[i].Name;                    
                object value = invocation.Request.Arguments[i];

                arguments.AppendFormat("{0}={1}, ", name, value);
            }

            arguments.Remove(arguments.Length-2, 2); // удалим запятую

            return arguments.ToString();
        }

    }
}