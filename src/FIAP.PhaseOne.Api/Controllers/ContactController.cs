using AutoMapper;
using FIAP.PhaseOne.Api.Dto;
using FIAP.PhaseOne.Application.Handlers.Commands.AddContact;
using FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact.Dto;
using FIAP.PhaseOne.Application.Handlers.Queries.GetAllContacts;
using FIAP.PhaseOne.Application.Handlers.Queries.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.PhaseOne.Api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto contactDto, CancellationToken ct)
        {
            var request = _mapper.Map<Application.Dto.ContactDto>(contactDto);

            var response = await _mediator.Send(new AddContactRequest { Contact = request }, ct);

            return CreatedAtAction(nameof(GetContactById), new { id = response.Id }, response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetContactByIdRequestDto { Id = id }, ct);

            if (response is null) return NotFound();

            var contact = _mapper.Map<ContactDto>(response.Contact);

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(
            Guid id,
            [FromBody] ContactDto contactDto,
            CancellationToken ct)
        {
            var contact = _mapper.Map<ContactForUpdateDto>(contactDto);

            var response = await _mediator.Send(
                new UpdateContactRequest
                {
                    Id = id,
                    Contact = contact
                }, ct);

            //TODO: criar validação do response

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteContactRequest { Id = id}, ct);

            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContacts(CancellationToken ct, int page = 0, int limit = 10)
        {
            var response = await _mediator.Send(new GetAllContactsRequestDto { Page = page, Limit = limit }, ct);

            return Ok(response.Contacts);
        }
    }
}
