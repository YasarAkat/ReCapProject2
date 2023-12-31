﻿using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceColletion, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceColletion);
            }
            return ServiceTool.Create(serviceColletion);
        }
    }
}
