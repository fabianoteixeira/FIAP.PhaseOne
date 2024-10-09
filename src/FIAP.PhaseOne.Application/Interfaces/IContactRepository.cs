﻿using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Interfaces;

public interface IContactRepository
{
    Task Add(Contact contact, CancellationToken ct);
    Task<Contact?> GetById(Guid id, CancellationToken ct);
    Task Update(Contact contact, CancellationToken ct);
    Task Remove(Guid id, CancellationToken ct);
    Task<IEnumerable<Contact>> GetAll(int page, int limit, CancellationToken ct);
}
