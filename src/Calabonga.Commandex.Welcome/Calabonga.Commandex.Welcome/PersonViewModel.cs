using System.ComponentModel.DataAnnotations;

namespace Calabonga.Commandex.Welcome;

/// <summary>
/// Person Wizard Payload ViewModel
/// </summary>
public class PersonViewModel
{
    [Required]
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required]
    public string? LastName { get; set; }
}