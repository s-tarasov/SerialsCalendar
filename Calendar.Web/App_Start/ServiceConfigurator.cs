﻿using Microsoft.Framework.DependencyInjection;

namespace Calendar.Web.App_Start
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}