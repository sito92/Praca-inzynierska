using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Managers;

namespace DIRegister
{
    public class DIRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCore(builder);
            RegisterLogic(builder);
            RegisterModules(builder);
            RegisterJobs(builder);
        }

        private static void RegisterCore(ContainerBuilder builder)
        {
            builder.RegisterType<SessionManager>().As<ISessionManager>();
        }

        private static void RegisterLogic(ContainerBuilder builder)
        {

        }

        private static void RegisterModules(ContainerBuilder builder)
        {

        }
        private static void RegisterJobs(ContainerBuilder builder)
        {

        }
    }
}
