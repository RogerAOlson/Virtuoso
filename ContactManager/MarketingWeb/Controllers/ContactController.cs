using MarketingWeb.ViewModelProviders;
using MarketingWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketingWeb.Controllers
{
    public partial class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IResult> Index( 
            int id,
            [FromServices] IContactSelectViewModelProvider provider)
        {
            return await provider.ExecuteAsync(id, _logger);
        }

        [HttpPut]
        public async Task<IResult> Update(
            ContactUpdateViewModel updateContact,
            [FromServices] IContactUpdateViewModelProvider provider)
        {
            return await provider.ExecuteAsync(updateContact, _logger);
        }

        [HttpPost]
        public async Task<IResult> Add(
            ContactAddViewModel addContact,
            [FromServices] IContactAddViewModelProvider provider)
        {
            return await provider.ExecuteAsync(addContact, _logger);
        }

        [HttpDelete]
        public async Task<IResult> Delete(
            int id,
            [FromServices] IContactDeleteViewModelProvider provider)
        {
            return await provider.ExecuteAsync(id, _logger);
        }
    }
}
