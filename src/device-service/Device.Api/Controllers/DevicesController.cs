namespace Device.Api.Controller;

[Route("dev/[controller]")]
[ApiController]
public class DevicesController : ControllerBase
{
    private readonly DeviceService _service;

    public DevicesController(DeviceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetDevices()
    {
        var response = await _service.GetDevicesAsync();
        return Ok(response);
    }
}