using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneContact.API.Filters;
using PhoneContact.API.ResponseModels;
using PhoneContact.Services.Contracts;
using PhoneContact.Services.Requests;
using PhoneContact.Services.Responses.Contact;

namespace PhoneContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JsonException]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _contactService.GetContactsAsync();

            var totalBooks = result.ToList().Count;

            var itemsOnPage = result
                .OrderBy(c => new { c.LastName, c.MiddleName, c.FirstName })
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedContactsResponseModel<ContactResponse>(
                pageIndex, pageSize, totalBooks, itemsOnPage);

            return Ok(model);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _contactService.GetContactAsync(new GetContactRequest { Id = id });
            return Ok(result);
        }

    }
}