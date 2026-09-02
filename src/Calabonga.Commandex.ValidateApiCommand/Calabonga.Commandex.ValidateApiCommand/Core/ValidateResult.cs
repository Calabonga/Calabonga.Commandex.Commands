namespace Calabonga.Commandex.ValidateApiCommand.Core;

public sealed record ValidateResult
{
    public required string Name { get; init; }

    public bool IsExists { get; init; }
}
