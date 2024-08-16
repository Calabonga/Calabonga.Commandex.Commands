using Calabonga.Commandex.Engine.Settings;

namespace Calabonga.Commandex.Welcome.Core.Settings;

public class CurrentAppSettings : SettingsBase
{
    public CurrentAppSettings(string commandsPath) : base(commandsPath)
    {
        Message = Environment.GetEnvironmentVariable("MESSAGE") ?? "Welcome";
    }

    public string Message { get; }

    protected override string CurrentSettings() => GetType().Assembly.GetName().Name ?? throw new InvalidOperationException();

}