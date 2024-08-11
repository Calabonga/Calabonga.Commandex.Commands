using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Dialogs;
using System.Windows;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardDialogResult : ViewModelBase, IWizardDialogResult
{
    public DemoWizardDialogResult()
    {
        Title = "DemoWizard";
    }

    /// <summary>
    /// Default value <see cref="ResizeMode.NoResize"/>
    /// </summary>
    public virtual ResizeMode ResizeMode => ResizeMode.NoResize;

    /// <summary>
    /// Default value <see cref="SizeToContent.WidthAndHeight"/>
    /// </summary>
    public virtual SizeToContent SizeToContent => SizeToContent.WidthAndHeight;

    /// <summary>
    /// Default value <see cref="WindowStyle.ToolWindow"/>
    /// </summary>
    public virtual WindowStyle WindowStyle => WindowStyle.ToolWindow;

    /// <summary>
    /// Window instance that open this dialog
    /// </summary>
    public object? Owner { get; set; }
}