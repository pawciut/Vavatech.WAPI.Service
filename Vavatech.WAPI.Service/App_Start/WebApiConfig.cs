﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Service.Formatters;
using Vavatech.WAPI.Service.Handlers;
using Vavatech.WAPI.Service.Resolvers;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Konfiguracja i usługi składnika Web API

            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Extension",
                routeTemplate: "api/{controller}/{id}.{ext}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.MessageHandlers.Add(new TraceMessageHandler());
            //config.MessageHandlers.Add(new SecretKeyHandler());
            config.MessageHandlers.Add(new FormatMessageHandler());
            config.MessageHandlers.Add(new ExtensionMessageHandler());

            config.Formatters.Add(new QrCodeFormatter());

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUsersService, MockUsersService>();
            container.RegisterType<IStationsService, MockStationsService>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
