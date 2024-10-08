using FIAP.PhaseOne.Domain.ContactAggregate;

namespace FIAP.PhaseOne.Application.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        Contact GetById(Guid id);
        void Update(Contact contact);
        void Remove(Guid id);
    }
}
