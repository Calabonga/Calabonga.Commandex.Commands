# Commands For Commandex

Example command implementations for **Commandex** — each project is a standalone WPF class library
(`net10.0-windows8.0`) with its own `.sln`, demonstrating one `ICommandexCommand` type from
`Calabonga.Commandex.Engine`. A post-build `CopyDLLs` target copies the built `.dll`/`.pdb` into
`Calabonga.Commandex.Shell/PublishedCommands` so the Shell can pick the command up by reflection.

## Examples

| Solution | Command type | Demonstrates |
| --- | --- | --- |
| `Calabonga.Commandex.HelloWorld` | `EmptyCommandexCommand` | the simplest "fire and forget" command |
| `Calabonga.Commandex.WelcomeCommand` | `EmptyCommandexCommand` + `ResultCommandexCommand<string>` | two command types in one project; settings via `SettingsBase` + keyed DI |
| `Calabonga.Commandex.ValidateApiCommand` | `ResultCommandexCommand<bool>` + `ResultCommandexCommand<ValidateResult>` | returning a simple and a composite result, and returning an error |
| `Calabonga.Commandex.DialogCommand` | `DialogCommandexCommand<TView, TResult>` | a modal dialog with input validation |
| `Calabonga.Commandex.QuizCommand` | `DialogCommandexCommand<…>` | dialog + `GetResult()` → `ClipboardResult` |
| `Calabonga.Commandex.TaxPayerStatusCommand` | `DialogCommandexCommand<…>` | real call to the FNS service; `GetResult()` → `TextFileResult`; `INugetDependency` |
| `Calabonga.Commandex.PersonWizardCommand` | `WizardDialogCommandexCommand<TViewModel>` | a 4-step wizard with a `PersonViewModel` payload; `INugetDependency` |
| `Calabonga.Commandex.ParameterCommands` | `ParameterCommandexCommand<PersonData>` ×2 | two commands exchanging data through a `.prm` file |
| `Calabonga.Commandex.RelatedResultsCommand` | `ParameterCommandexCommand<CreatedAtParameter>` ×3 | a chain of commands; the last one returns a result |
| `Calabonga.Commandex.ZoneCommand` | `ZoneCommandexCommand<TView, TViewModel>` | hosting a view inline in the Shell `MainZone` instead of a window |

## What is Calabonga.Commandex

The `Calabonga.Commandex` — a WPF application built with CommunityToolkit.Mvvm that launches and
executes modules (plugins):

* finds module `.dll` files (plugins) in a configured folder;
* launches or executes them from the GUI;
* collects the result of a module's work after it completes.

It is a solution spread across several repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** — the command executer / launcher.
* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** — this repository, example commands.
* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** — `dotnet new` template of a trimmed Shell for debugging a single command in place.
* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** — engine and contracts library.
* **[Calabonga.Commandex.Engine.Processors](https://github.com/Calabonga/Calabonga.Commandex.Engine.Processors)** — additional result processors on top of the Engine.
* **[Calabonga.CommandexCommand.Template](https://github.com/Calabonga/Calabonga.CommandexCommand.Template)** — `dotnet new` templates for creating a Commandex command.

## Video

The [Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell) repository has many videos about Commandex.
