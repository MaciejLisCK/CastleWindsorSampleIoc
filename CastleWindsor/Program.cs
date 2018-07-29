using Castle.Core;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor
{
    class Program
    {
        static IWindsorContainer _container = new WindsorContainer();

        static void Main(string[] args)
        {
            _container.Install(FromAssembly.This());

            var stringReverser = _container.Resolve<IStringReverser>();
            var reversedString = stringReverser.Reverse("dupa");

            Console.WriteLine(reversedString);
            Console.ReadKey();
        }
    }

    [Interceptor(typeof(LogInterceptor))]
    public class StringReverser : IStringReverser
    {
        public string Reverse(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }

    public interface IStringReverser
    {
        string Reverse(string text);
    }

    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Start method: ${invocation.Method}.");
            invocation.Proceed();
            Console.WriteLine($"Stop  method: ${invocation.Method}.");
        }
    }
}
