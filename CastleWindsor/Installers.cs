using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor
{
    public class Installers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IStringReverser>()
                    .ImplementedBy<StringReverser>()
                    .LifestyleTransient());

            container.Register(
                Component
                    .For<LogInterceptor>()
                    .LifestyleTransient());

        }
    }
}
