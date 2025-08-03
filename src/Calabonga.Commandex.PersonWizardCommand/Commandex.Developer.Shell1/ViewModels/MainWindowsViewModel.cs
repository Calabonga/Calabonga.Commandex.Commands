using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.Commandex.Engine.Zones;
using Commandex.Developer.Shell1.Zones;

namespace Commandex.Developer.Shell1.ViewModels;
/// <summary>
/// ViewModel for MainWindow View.
/// </summary>
public partial class MainWindowsViewModel : ViewModelBase
{
    public MainWindowsViewModel(
        IZoneManager zoneManager,
        IAppSettings settings)
    {

        Title = $"Commandex Shell Emulator ({settings.CommandsPath})";

        zoneManager.ActivateZone<IPreviewView, IPreviewViewModel>(zoneManager.GetDefaultZoneName());
    }
}
