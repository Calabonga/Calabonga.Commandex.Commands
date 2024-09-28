using Calabonga.Commandex.Engine.Base;


namespace Calabonga.Commandex.RelatedResultsCommand;

/// <summary>
/// Simple parameter for demo
/// </summary>
public class CreatedAtParameter : CommandexParameter
{
    public DateTime CreatedAt { get; set; }

    public string? RandomData { get; set; }
}