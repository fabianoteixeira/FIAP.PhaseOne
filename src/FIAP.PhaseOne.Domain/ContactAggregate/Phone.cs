namespace FIAP.PhaseOne.Domain.ContactAggregate;

public class Phone : EntityBase
{
    public Phone(int dDD, string number)
    {
        DDD = dDD;
        Number = number;
    }

    public int DDD { get; private set; }
    public string Number { get; private set; }
    public Contact Contact{ get; set; }
    public Guid ContactId { get; set; }
}
