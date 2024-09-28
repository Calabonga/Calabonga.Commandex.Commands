using Calabonga.Commandex.Engine.Base;

namespace Calabonga.Commandex.ParameterOne.Core;

public class PersonData : CommandexParameter
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }
}