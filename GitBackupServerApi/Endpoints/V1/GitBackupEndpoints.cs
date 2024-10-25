using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using WebInstallers;

namespace GitBackupServerApi.Endpoints.V1;

// ReSharper disable once UnusedType.Global
public sealed class GitBackupEndpoints : IInstaller

{
    public int InstallPriority => 50;
    public int ServiceUsePriority => 50;

    public bool InstallServices(WebApplicationBuilder builder, bool debugMode, string[] args,
        Dictionary<string, string> parameters)
    {
        return true;
    }

    public bool UseServices(WebApplication app, bool debugMode)
    {
        if (debugMode)
            Console.WriteLine($"{GetType().Name}.{nameof(UseServices)} Started");

        //var group = app.MapGroup(DatabaseApiRoutes.ApiBase + DatabaseApiRoutes.Database.DatabaseBase)
        //    .RequireAuthorization();

        //group.MapPost(DatabaseApiRoutes.Database.CheckRepairDatabase, CheckRepairDatabase);
        //group.MapPost(DatabaseApiRoutes.Database.CreateBackup, CreateBackup);
        //group.MapPost(DatabaseApiRoutes.Database.ExecuteCommand, ExecuteCommand);
        //group.MapGet(DatabaseApiRoutes.Database.GetDatabaseNames, GetDatabaseNames);
        //group.MapGet(DatabaseApiRoutes.Database.IsDatabaseExists, IsDatabaseExists);
        //group.MapPut(DatabaseApiRoutes.Database.RestoreBackup, RestoreBackup);
        //group.MapPost(DatabaseApiRoutes.Database.RecompileProcedures, RecompileProcedures);
        //group.MapGet(DatabaseApiRoutes.Database.TestConnection, TestConnection);
        //group.MapPost(DatabaseApiRoutes.Database.UpdateStatistics, UpdateStatistics);

        if (debugMode)
            Console.WriteLine($"{GetType().Name}.{nameof(UseServices)} Finished");

        return true;
    }
}