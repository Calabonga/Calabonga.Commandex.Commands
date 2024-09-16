using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Settings;

namespace Calabonga.Commandex.WelcomeCommand.Core.Settings;

public class CurrentAppSettings : SettingsBase
{
    public CurrentAppSettings(IAppSettings shellSettings, ISettingsReaderConfiguration settingsReader)
        : base(shellSettings, settingsReader)
    {
        Message = Environment.GetEnvironmentVariable("MESSAGE") ?? "Welcome";
    }

    public string Message { get; }
}