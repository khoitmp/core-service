namespace Broker.Api.Controller;

[Route("dev/[controller]")]
[ApiController]
public class BrokersController : ControllerBase
{
    private readonly BrokerService _service;

    public BrokersController(BrokerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetBrokers()
    {
        var response = await _service.GetBrokersAsync();
        return Ok(response);
    }
}