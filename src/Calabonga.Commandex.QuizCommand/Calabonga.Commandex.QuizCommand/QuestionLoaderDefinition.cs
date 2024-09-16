using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.QuizCommand.Core;
using Calabonga.Commandex.QuizCommand.Core.ViewModels;
using Calabonga.Commandex.QuizCommand.Core.Views;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.QuizCommand;

public class QuestionLoaderDefinition : AppDefinition
{
    /// <summary>
    /// Configure services for current application
    /// </summary>
    /// <param name="services">instance of <see cref="IServiceCollection"/></param>
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<QuizDialogView>();
        services.AddScoped<QuizViewModel>();
        services.AddScoped<ICommandexCommand, QuestionLoadedCommand>();
    }
}