using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Zones;
using Calabonga.ZoneCommandexCommand.Core.ViewModels;
using Calabonga.ZoneCommandexCommand.Core.Views;

namespace Calabonga.ZoneCommandexCommand.Core;

public class ZoneCommandCommandexCommand : ZoneCommandexCommand<ZoneCommandView, ZoneCommandViewModel>
{
    public ZoneCommandCommandexCommand(IZoneManager zoneManager) : base(zoneManager)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2025";

    public override string DisplayName => "MySecondCommand";

    public override string Description => "My second commandex command for demo";

    public override string Version => GetType().Assembly.GetName().Version?.ToString() ?? "0.0.0";
}

