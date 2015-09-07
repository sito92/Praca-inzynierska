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
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using Logging;
using Logging.Interfaces;
using Logic.ContactForm.Interfaces;
using Logic.ContactForm.Services;
using Logic.Inset.Interfaces;
using Logic.Inset.Services;
using Logic.News.Interfaces;
using Logic.News.Services;
using Logic.NewsCategory.Interfaces;
using Logic.NewsCategory.Services;
using Logic.Newsletter.Interfaces;
using Logic.Newsletter.Services;
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
            builder.RegisterType<ContactFormService>().As<IContactFormService>();
            builder.RegisterType<NewsletterReceiverService>().As<INewsletterReceiverService>();

            builder.RegisterType<ParsersFactory>().As<IParsersFactory>();
            builder.RegisterType<InsetRecognizer>().As<IInsetRecognizer>();
            builder.RegisterType<InsetParser>().As<IInsetParser>();
            builder.RegisterType<ArgumentValidator>().As<IArgumentValidator>();
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
