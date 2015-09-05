﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Managers;
using DAL.Factory;
using DAL.Interfaces;
using DAL.Repository;
using DAL.UnitOfWork;
using Logging;
using Logging.Interfaces;
using Logic.News.Interfaces;
using Logic.News.Services;
using Logic.NewsCategory.Interfaces;
using Logic.NewsCategory.Services;
using Logic.User.Interfaces;
using Logic.User.Services;
using Modules.Cryptography;
using Modules.Cryptography.Interfaces;

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
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<PasswordManager>().As<IPasswordManager>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<SessionManager>().As<ISessionManager>();
        }

        private static void RegisterLogic(ContainerBuilder builder)
        {
            builder.RegisterType<NewsService>().As<INewsService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<NewsCategoryService>().As<INewsCategoryService>();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordManager>().As<IPasswordManager>();
            builder.RegisterType<HashComputer>().As<IHashComputer>();
        }
        private static void RegisterJobs(ContainerBuilder builder)
        {

        }
    }
}
