namespace FIAP.PhaseOne.Application.Commands.AddContact;

public class AddContactRequest : IRequest<AddContactResponse>
{
    public required string Street { get; set; }
    public required string Number { get; set; }
    public string? Complement { get; set; }
    public required string City { get; set; }
    public required string District { get; set; }
    public required string Country { get; set; }
    public required string Zipcode { get; set; }
}
