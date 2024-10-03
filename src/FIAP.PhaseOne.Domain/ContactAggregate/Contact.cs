﻿namespace FIAP.PhaseOne.Domain.ContactAggregate;

internal class Contact : EntityBase
{
    public Contact(
        string name,
        Phone phone,
        string email,
        Address address)
    {
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }

    public string Name { get; private set; }
    public Phone Phone { get; private set; }
    public string Email { get; private set; }
    public Address Address { get; private set; }

}
