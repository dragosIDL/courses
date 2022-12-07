using System.Collections.Generic;
using System.Linq;

namespace GoingDeclarative.Examples;

using static DomainLanguage;

public class DomainLanguage
{
    public record Country();
    public record Address(Country Country);
    public record Person(List<Address> Addresses);

    public void Execute(Person person, Country country)
    {
        // ...

        if (person.Addresses.Any(address => address.Country == country))
        {
            // ...
        }
        if (person.Addresses.Any(address => address.Country == country))
        {
            // ...
        }

        // ...
    }

    public void ExecuteRefactored(Person person, Country country)
    {
        // ...

        if (person.HasAddressInCountry(country))
        {
            // ...
        }
        if (person.ResidesIn(country))
        {
            // ...
        }

        // ...
    }
}

public static class PersonExtensions
{
    public static bool HasAddressInCountry(this Person person, Country country)
    {
        return person.Addresses.Any(a => a.Country == country);
    }

    public static bool ResidesIn(this Person person, Country country)
    {
        return person.Addresses.Any(a => a.Country == country);
    }
}
