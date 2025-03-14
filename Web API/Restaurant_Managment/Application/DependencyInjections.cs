﻿using Application.AutoMapper;
using Application.Patterns;
using Application.PipelineBehaviors;
using Application.Services.BackgroundServices;
using Application.Services.LogService;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region AutoMapper
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        #endregion

        #region Logger

        Log.Logger = new LoggerConfiguration()
           .WriteTo.File($"Log/log-app.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
        services.AddScoped<ILoggerService, LoggerService>();

        #endregion

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddHostedService<DeleteUserBackgroundService>();
        services.AddScoped<ICarStrategyPattern, CarStrategyPattern>();
        services.AddScoped<ICarStrategy, CarStrategy>();

        return services;
    }
}