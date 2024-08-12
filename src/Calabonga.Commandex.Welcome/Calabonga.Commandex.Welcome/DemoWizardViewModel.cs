using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardViewModel : WizardViewModelBase
{
    public DemoWizardViewModel(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        Title = "Демонстрация Wizard";
    }
}