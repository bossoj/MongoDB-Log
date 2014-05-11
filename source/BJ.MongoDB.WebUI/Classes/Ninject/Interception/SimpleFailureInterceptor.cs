using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject.Extensions.Interception;

namespace BJ.MongoDB.WebUI.Ninject
{
    /// <summary>
    /// Абстрактный класс перехватчика для логирования выполнения методов (с поддержкой логирования ошибок)
    /// </summary>
    public abstract class SimpleFailureInterceptor : IInterceptor
    {
        #region IInterceptor Members

        public virtual void Intercept(IInvocation invocation)
        {
            try
            {
                BeforeInvoke(invocation);
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                OnError(invocation, ex);
            }
            finally
            {
                AfterInvoke(invocation);
            }
        }

        #endregion

        protected virtual void BeforeInvoke(IInvocation invocation)
        {
        }

        protected virtual void AfterInvoke(IInvocation invocation)
        {
        }

        protected virtual void OnError(IInvocation invocation, Exception exception)
        {
            throw exception;
        }
    }
}