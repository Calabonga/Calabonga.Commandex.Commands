using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardDialogResult : WizardDialogResultBase
{
    public DemoWizardDialogResult()
    {
        Title = "DemoWizard";
    }

    public override List<IWizardStep> ConfigureSteps() =>
    [
        new WizardStep("Step1"),
        new WizardStep("Step2"),
        new WizardStep("Step3"),
        new WizardStep("Step4"),
        new WizardStep("Step5")
    ];
}