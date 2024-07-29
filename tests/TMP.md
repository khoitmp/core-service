```C#
// <class_name> : IAsyncLifetime

private readonly IContainer _container;

var image = new ImageFromDockerfileBuilder()
    .WithDockerfileDirectory(CommonDirectoryPath.GetSolutionDirectory(), string.Empty)
    .WithDockerfile("Dockerfile")
    .WithName("khoitmp/core-service:latest")
    .Build();

image.CreateAsync().ConfigureAwait(false);

var environments = new Dictionary<string, string>()
{
    ["ASPNETCORE_ENVIRONMENT"] = "Development",
    ["Logging__LogLevel__Default"] = "Trace",
    ["Logging__LogLevel__Microsoft"] = "Warning",
    ["Logging__LogLevel__System"] = "Warning",
    ["Logging__LogLevel__Microsoft.Hosting.Lifetime"] = "Information",
    ["Logging__LogLevel__Microsoft.EntityFrameworkCore"] = "Information",
    ["Value"] = "10"
};

_container = new ContainerBuilder()
    .WithImage(image)
    .WithEnvironment(environments)
    .WithPortBinding(11000, 80)
    .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(80))
    .Build();

public async Task InitializeAsync()
{
    await _container.StartAsync();
}

public async Task DisposeAsync()
{
    await _container.StopAsync();
}
```