namespace Broker.Api.Models;

public class BrokerModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    public BrokerModel(string id, string name, int value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}