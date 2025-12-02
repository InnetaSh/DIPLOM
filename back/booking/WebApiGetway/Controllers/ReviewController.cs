[ApiController]
[Route("review")]
public class ReviewController : ControllerBase
{
    private readonly IGatewayService _gateway;
    public ReviewController(IGatewayService gateway) => _gateway = gateway;

    [HttpGet("get-all")]
    public Task<IActionResult> GetAll() =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", "/api/review/get-all", HttpMethod.Get, null);

    [HttpGet("get/{id}")]
    public Task<IActionResult> GetById(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/get/{id}", HttpMethod.Get, null);

    [HttpGet("get-by-offerId/{id}")]
    public Task<IActionResult> GetByOfferId(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/get-by-offerId/{id}", HttpMethod.Get, null);

    [HttpGet("get-by-userId/{id}")]
    public Task<IActionResult> GetByUserId(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/get-by-userId/{id}", HttpMethod.Get, null);

    [HttpPost("create")]
    public Task<IActionResult> Create([FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", "/api/review/create", HttpMethod.Post, request);

    [HttpPut("update/{id}")]
    public Task<IActionResult> Update(int id, [FromBody] object request) =>
        _gateway.ForwardRequestAsync("OfferApiService", $"/api/review/update/{id}", HttpMethod.Put, request);

    [HttpDelete("del/{id}")]
    public Task<IActionResult> Delete(int id) =>
        _gateway.ForwardRequestAsync<object>("OfferApiService", $"/api/review/del/{id}", HttpMethod.Delete, null);
}
