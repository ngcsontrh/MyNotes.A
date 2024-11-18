var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);
var sql = builder.AddSqlServer("sql", password: sqlPassword)
    .WithDataVolume()
    .AddDatabase("MyNotes");
var cache = builder.AddRedis("cache")
    .WithDataVolume();
var apiService = builder.AddProject<Projects.MyNotes_API>("mynotes-api")
    .WithReference(sql)
    .WithReference(cache);


builder.Build().Run();
