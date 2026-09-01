using Calabonga.Commandex.Engine.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Calabonga.Commandex.DialogCommand.Core.ViewModels;

public sealed partial class DemoDialogResult : DefaultDialogWithValidationResult
{
    public DemoDialogResult()
    {
        Title = "Dialog DEMO";
    }

    [Required]
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyDataErrorInfo]
    private string _firstName = string.Empty;

    [Required]
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyDataErrorInfo]
    private string _lastName = string.Empty;

    [RelayCommand(CanExecute = nameof(CanSaveCommand))]
    private void Save()
    {
        if (Owner is Window window)
        {
            window.Close();
        }
    }

    private bool CanSaveCommand => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
}