namespace Tests.Units;

public class DeviceTests
{
    [Fact]
    public void CalculationHasCorrectValue()
    {
        var configuration = new Mock<IConfiguration>();

        configuration.Setup(config => config["Value"]).Returns("100");

        var deviceService = new DeviceService(configuration.Object);

        var value = deviceService.CalculateValue(2);

        Console.WriteLine(value);

        Assert.Equal(150, value);
        // Assert.Equal(200, value);
    }
}