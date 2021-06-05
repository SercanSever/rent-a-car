using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        public override void Intercept(IInvocation invocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}");
            }
            _stopWatch.Reset();
        }
    }
}
