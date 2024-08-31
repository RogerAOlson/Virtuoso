using MarketingWeb.ViewModelProviders;
using MarketingWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketingWeb.Controllers
{
    [Route("v1/[controller]")]
    public partial class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public Task<IResult> Index(
            int id,
            [FromServices] IContactSelectViewModelProvider provider)
        {
            return provider.ExecuteAsync(id, _logger);
        }

        [HttpPost]
        public Task<IResult> Add(
            [FromBody] ContactAddViewModel addContact,
            [FromServices] IContactAddViewModelProvider provider)
        {
            return provider.ExecuteAsync(addContact, _logger);
        }

        [HttpPut]
        public Task<IResult> Update(
            [FromBody] ContactUpdateViewModel updateContact,
            [FromServices] IContactUpdateViewModelProvider provider)
        {
            return provider.ExecuteAsync(updateContact, _logger);
        }

        [HttpDelete("{id:int}")]
        public Task<IResult> Delete(
            int id,
            [FromServices] IContactDeleteViewModelProvider provider)
        {
            return provider.ExecuteAsync(id, _logger);
        }
    }
}
