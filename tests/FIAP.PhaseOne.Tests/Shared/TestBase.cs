using Bogus;

namespace FIAP.PhaseOne.Tests.Shared;

public class TestBase
{
    protected readonly Faker _faker = new("pt_BR");
}