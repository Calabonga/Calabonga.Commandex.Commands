using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.ParameterTwo.Core;

public class PersonData : CommandexParameter
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }
}