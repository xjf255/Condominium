namespace condominium.Controllers;
{
  [ApiController]
  [Route("api/[controller]")]
  public class PropiedadController : ControllerBase
  {
    private readonly CondoContext _db;

    // [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
      var query = _d
    }
  }
}