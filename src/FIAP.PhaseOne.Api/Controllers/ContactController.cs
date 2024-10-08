using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.PhaseOne.Api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto contactDto, CancellationToken ct)
        {
            await _contactService.AddContact(contactDto, ct);
            return CreatedAtAction(nameof(GetContactById), new {id = contactDto.Id }, contactDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id, CancellationToken ct)
        {
            var contact = await _contactService.GetContactById(id, ct);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(
            Guid id, 
            [FromBody] ContactDto contactDto, 
            CancellationToken ct)
        {
            if (id != contactDto.Id)
            {
                return BadRequest();
            }

            await _contactService.UpdateContact(contactDto, ct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id, CancellationToken ct)
        {
            await _contactService.RemoveContact(id, ct);
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContacts(CancellationToken ct, int page = 0, int limit = 10)
        {
            var contacts = await _contactService.GetAllContacts(page, limit, ct);
            
            return Ok(contacts);
        }
    }
}
