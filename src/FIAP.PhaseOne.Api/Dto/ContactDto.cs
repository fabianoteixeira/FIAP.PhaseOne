namespace FIAP.PhaseOne.Api.Dto;

public class ContactDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public PhoneDto? Phone { get; set; }
    public string? Email { get; set; }
    public AddressDto? Address { get; set; }
}
