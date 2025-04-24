var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireProjectUniversity_ApiService>("apiservice");

builder.AddProject<Projects.AspireProjectUniversity_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
