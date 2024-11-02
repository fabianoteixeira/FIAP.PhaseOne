using AutoMapper;
using FIAP.PhaseOne.Api.Controllers.Shared;
using FIAP.PhaseOne.Api.Dto;
using FIAP.PhaseOne.Application.Handlers.Commands.AddContact;
using FIAP.PhaseOne.Application.Handlers.Commands.DeleteContact;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact;
using FIAP.PhaseOne.Application.Handlers.Commands.UpdateContact.Dto;
using FIAP.PhaseOne.Application.Handlers.Queries.GetAllContacts;
using FIAP.PhaseOne.Application.Handlers.Queries.GetContactById;
using FIAP.PhaseOne.Application.Handlers.Queries.SearchContactsByDDD;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.PhaseOne.Api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : BaseController
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
            var request = _mapper.Map<AddContactRequest>(contactDto);

            var response = await _mediator.Send(request, ct);

            if (response.IsError)
                return BadRequest(response.Errors);
            
            return ResponseOk(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id, CancellationToken ct)
        {
            var response = await _mediator.Send(new GetContactByIdRequestDto { Id = id }, ct);

            if (response is null) return NotFound();

            var contact = _mapper.Map<ContactDto>(response.Contact);

            return ResponseOk(contact);
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

            if (response.IsError)
                return BadRequest(response.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteContactRequest { Id = id}, ct);

            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllContacts(CancellationToken ct, int page = 1, int limit = 10)
        {
            var response = await _mediator.Send(new GetAllContactsRequestDto { Page = page, Limit = limit }, ct);

            return ResponseOk(response.Contacts);
        }
        
        [HttpGet("ddd/{ddd:int}")]
        public async Task<IActionResult> GetAllContacts(int ddd, CancellationToken ct, int page = 1, int limit = 10)
        {
            var response = await _mediator.Send(new SearchContactsByDDDRequestDto
            {
                DDD = ddd, 
                Page = page,
                Limit = limit
            }, ct);

            return ResponseOk(response.Contacts);
        }
    }
}
