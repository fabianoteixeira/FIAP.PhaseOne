namespace FIAP.PhaseOne.Domain.ContactAggregate;

internal class Phone
{
    public Phone(int dDD, string number)
    {
        DDD = dDD;
        Number = number;
    }

    public int DDD { get; private set; }
    public string Number { get; private set; }
}
