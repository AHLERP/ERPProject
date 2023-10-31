using Castle.DynamicProxy; // AOP altyapısını sağlayacak , autofac den geliyor.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple =true,Inherited =true)] //burda validation u attribute yapmak için interceptor yazıyoruz.
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
