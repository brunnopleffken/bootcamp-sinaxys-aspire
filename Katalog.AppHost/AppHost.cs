var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Katalog_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Katalog_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
