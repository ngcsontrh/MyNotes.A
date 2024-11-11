var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MyNotes_API>("mynotes-api");

builder.Build().Run();
