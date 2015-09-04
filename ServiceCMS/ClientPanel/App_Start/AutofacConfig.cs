﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ClientPanel.App_Start
{
    public class AutofacConfig
    {
        public Autofac.IContainer myContainer { get; private set; }

        public void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            OnConfigure(builder);

            if (this.myContainer == null)
            {
                this.myContainer = builder.Build();
            }
            else
            {
                builder.Update(this.myContainer);
            }

            //This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.myContainer));
        }


        protected virtual void OnConfigure(ContainerBuilder builder)
        {
            //This is where you register all dependencies

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            DIRegister.DIRegister.Register(builder);
        }
    }
}