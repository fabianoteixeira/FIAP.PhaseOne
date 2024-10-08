using FIAP.PhaseOne.Application.Dto;
using FIAP.PhaseOne.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.PhaseOne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactRequestDto contactDto)
        {
            await _contactService.AddContact(contactDto);
            return CreatedAtAction(nameof(GetContactById), new {id = contactDto.Id }, contactDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(Guid id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(Guid id, [FromBody] ContactRequestDto contactDto)
        {
            if (id != contactDto.Id)
            {
                return BadRequest();
            }

            _contactService.UpdateContact(contactDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(Guid id)
        {
            _contactService.RemoveContact(id);
            return NoContent();
        }
    }
}
