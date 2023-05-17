using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericRequestResponseController<TEntity, TEntityDTORequest, TEntityDTOResponse> 
        : ControllerBase where TEntity : class
                         where TEntityDTORequest : class 
                         where TEntityDTOResponse : class
    {
    }
}
