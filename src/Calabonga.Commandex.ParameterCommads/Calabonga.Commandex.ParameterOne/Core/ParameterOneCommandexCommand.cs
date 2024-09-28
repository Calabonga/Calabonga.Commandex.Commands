using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.ParameterOne.Core;

public class ParameterOneCommandexCommand : ParameterCommandexCommand<PersonData>
{
    public ParameterOneCommandexCommand(IAppSettings appSettings) : base(appSettings)
    {
    }

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        if (ReadParameter() is null)
        {
            var person = new PersonData
            {
                FirstName = "Евлампий",
                LastName = "Суходрищев"
            };

            WriteParameter(person);
        }

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";
    public override string DisplayName => "Parameter Command 1";
    public override string Description => "Команда, которая может создать параметр, чтобы его прочитала другая команда номер 2";
    public override string Version => "1.0.0-rc.17.9.28"; //semver.org

    public override bool IsPushToShellEnabled => true;
}