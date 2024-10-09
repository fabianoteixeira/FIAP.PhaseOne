using AutoMapper;
using FIAP.PhaseOne.Api.Dto;
using FIAP.PhaseOne.Application.Commands.AddContact;
using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Application.Queries.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.PhaseOne.Api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMediator mediator, IMapper mapper)
        {
            _contactService = contactService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto contactDto, CancellationToken ct)
        {
            var request = _mapper.Map<AddContactRequest>(contactDto);

            var response = await _mediator.Send(request, ct);

            return CreatedAtAction(nameof(GetContactById), new { id = response.Id }, response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetContactByIdRequestDto { Id = id }, ct);

            return Ok(response);
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
            //TODO: adicionar paginação no response
            var contacts = await _contactService.GetAllContacts(page, limit, ct);
            
            return Ok(contacts);
        }
    }
}
