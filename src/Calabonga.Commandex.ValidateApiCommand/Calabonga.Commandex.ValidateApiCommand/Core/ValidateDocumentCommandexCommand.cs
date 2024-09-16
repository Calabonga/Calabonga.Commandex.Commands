﻿using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.ValidateApiCommand.Core
{
    public class ValidateDocumentCommandexCommand : ResultCommandexCommand<ValidateResult>
    {
        public override string CopyrightInfo => "Calabonga SOFT © 2024";

        public override string DisplayName => "Validate Document";

        public override string Description => "Validate document exists on server";

        public override string Version => "1.0.0-beta.15.0";

        protected override ValidateResult? Result { get; set; }

        public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
        {
            // check file name
            // check server
            // return object;

            var value = Random.Shared.Next(0, 3);
            var boolValue = value switch
            {
                0 => "False",
                1 => "True",
                _ => null
            };

            if (boolValue is null)
            {
                var error = new ExecuteCommandexCommandException("ERROR");
                return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Error(error));
            }

            var result = new ValidateResult
            {
                IsExists = bool.Parse(boolValue),
                Name = boolValue
            };

            Result = result;

            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
        }

        public override bool IsPushToShellEnabled => true;
    }
}