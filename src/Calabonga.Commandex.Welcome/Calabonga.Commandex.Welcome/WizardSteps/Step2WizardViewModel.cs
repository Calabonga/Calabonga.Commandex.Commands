using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public class Step2WizardViewModel : WizardStepViewModel
{
    public Step2WizardViewModel()
    {
        Title = "Step 2";
    }

    public override bool CanGoBack => true;
}