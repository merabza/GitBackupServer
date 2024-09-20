//Created by ApiProgramClassCreator at 9/20/2024 10:06:19 PM

using ConfigurationEncrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SignalRMessages.Installers;
using SwaggerTools;
using System;
using System.Collections.Generic;
using WebInstallers;
using Microsoft.Extensions.Hosting;

try
{
    var parameters = new Dictionary<string, string>
    {
        { SignalRMessagesInstaller.SignalRReCounterKey, string.Empty }, //Allow SignalRReCounterKey
        { ConfigurationEncryptInstaller.AppKeyKey, "3f5e5566e1714250bdd5d2a59ed08bbe" },
        { SwaggerInstaller.AppNameKey, "Git Backup Server" },
        { SwaggerInstaller.VersionCountKey, 1.ToString() },
        { SwaggerInstaller.UseSwaggerWithJwtBearerKey, string.Empty } //Allow Swagger
    };

    var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        { ContentRootPath = AppContext.BaseDirectory, Args = args });

    var debugMode = builder.Environment.IsDevelopment();

    if (!builder.InstallServices(debugMode, args, parameters,

//WebSystemTools
            ApiExceptionHandler.AssemblyReference.Assembly,
            ConfigurationEncrypt.AssemblyReference.Assembly,
            SerilogLogger.AssemblyReference.Assembly,
            StaticFilesTools.AssemblyReference.Assembly,
            SwaggerTools.AssemblyReference.Assembly,
            TestToolsApi.AssemblyReference.Assembly,
            WindowsServiceTools.AssemblyReference.Assembly
        ))
    {
        return 2;
    }


    //ReSharper disable once using

    using var app = builder.Build();

    if (!app.UseServices(debugMode))
    {
        return 1;
    }

    app.Run();
    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}