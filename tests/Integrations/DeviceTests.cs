namespace Tests.Integrations;

public class DeviceTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public DeviceTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Development");
            builder.ConfigureAppConfiguration((hostingContext, configBuilder) =>
            {
                var env = hostingContext.HostingEnvironment;
                configBuilder.AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                configBuilder.AddEnvironmentVariables();
            });
        });
    }

    [Fact]
    public async Task Http_Has3Devices()
    {
        var httpClient = _factory.CreateClient();
        var content = await httpClient.GetStringAsync($"http://localhost/dev/devices");
        var response = JsonConvert.DeserializeObject<List<Device>>(content);

        Assert.Equal(3, response.Count);
        Assert.Equal(10, response[0].Value);
        Assert.Equal(20, response[1].Value);
        Assert.Equal(30, response[2].Value);
    }
}