﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MiniCourse.WebUI.Users.Validators;
using System.Reflection;


namespace MiniCourse.WebUI.Extensions.Extensions
{
    public static class FluentExtension
    {
        public static IServiceCollection AddFluentExt(this IServiceCollection services, IConfiguration configuration)
        {
      
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssemblyContaining<UserCreateViewModelValidator>();


            return services;
        }
    }
}
