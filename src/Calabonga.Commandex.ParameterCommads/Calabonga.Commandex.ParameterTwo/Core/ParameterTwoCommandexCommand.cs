﻿using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.ParameterTwo.Core;

public class ParameterTwoCommandexCommand : ParameterCommandexCommand<PersonData>
{
    public ParameterTwoCommandexCommand(IAppSettings appSettings) : base(appSettings)
    {
    }

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var person = ReadParameter();
        if (person is null)
        {
            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
        }

        person.BirthDate = DateTime.Today;

        WriteParameter(person);

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";
    public override string DisplayName => "Parameter Command 2";
    public override string Description => "Команда, которая может прочитать параметр, тот который создала другая команда номер 1";
    public override string Version => "1.0.0-rc.17.9.28"; //semver.org

    public override bool IsPushToShellEnabled => true;
}