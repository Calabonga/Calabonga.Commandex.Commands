﻿using Calabonga.Commandex.Engine;

namespace Calabonga.Commandex.Welcome;

public class CurrentAppSettings : SettingsBase
{
    public CurrentAppSettings(string commandsPath) : base(commandsPath)
    {
        Message = Environment.GetEnvironmentVariable("MESSAGE") ?? "Welcome";
    }

    public string Message { get; } = null!;

    protected override string CurrentSettings() => GetType().Namespace ?? throw new InvalidOperationException();

}