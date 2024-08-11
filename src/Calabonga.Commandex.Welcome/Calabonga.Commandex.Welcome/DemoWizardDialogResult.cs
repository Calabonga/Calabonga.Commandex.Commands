using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.Welcome.WizardSteps;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardDialogResult : WizardDialogResultBase<IWizardStepView, IWizardStepViewModel>
{
    public DemoWizardDialogResult()
    {
        RegisterStep(new WizardStep1());
        RegisterStep(new WizardStep2());
    }
}

public class WizardStep1 : IWizardStep<Step1, Step1WizardViewModel> { }
public class WizardStep2 : IWizardStep<Step2, Step2WizardViewModel> { }
public class WizardStep3 : IWizardStep<Step3, Step3WizardViewModel> { }