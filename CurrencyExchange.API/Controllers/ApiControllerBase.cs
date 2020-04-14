namespace CurrencyExchange.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    [ApiConventionType(typeof(ApiConventions))]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
