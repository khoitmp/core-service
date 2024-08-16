namespace Broker.Api.Services;

public class BrokerService
{
    private readonly IConfiguration _configuration;
    private readonly int _value;

    public BrokerService(IConfiguration configuration)
    {
        _configuration = configuration;
        _value = Convert.ToInt32(_configuration["Value"] ?? "0");
    }

    public Task<List<BrokerModel>> GetBrokersAsync()
    {
        var brokers = new List<BrokerModel>()
        {
            new BrokerModel("broker1", "Broker 1", CalculateValue(1)),
            new BrokerModel("broker2", "Broker 2", CalculateValue(2)),
            new BrokerModel("broker3", "Broker 3", CalculateValue(3))
        };
        return Task.FromResult(brokers);
    }

    public int CalculateValue(int value)
    {
        return value * _value;
    }
}