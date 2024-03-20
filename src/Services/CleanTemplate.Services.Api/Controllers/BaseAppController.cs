using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.Services.Api;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseAppController : ControllerBase
{

}
