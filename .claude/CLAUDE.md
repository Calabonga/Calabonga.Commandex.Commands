# CLAUDE.md

Guidance for Claude Code (claude.ai/code) when working in the **`Calabonga.Commandex.Commands`** repository.

> Дополнительные правила — в [`.claude/rules/code-styles.md`](rules/code-styles.md) (стиль C#) и [`.claude/rules/workflow.md`](rules/workflow.md) (ветки, коммиты).
> Общий контекст рабочего пространства из шести репозиториев — в `../CLAUDE.md`.

## Что это за репозиторий

Набор **самостоятельных проектов-примеров команд** для Commandex — по одному-два `.sln` на каждый пример, общего solution нет. Каждый проект — WPF class library (`net10.0-windows8.0`, `UseWPF=true`), реализующая один из типов `ICommandexCommand` из `Calabonga.Commandex.Engine`. Собранная `.dll` подключается к `Shell` (не через project reference, а копированием в `Calabonga.Commandex.Shell/PublishedCommands` — см. ниже).

Тип в терминах версионирования рабочего пространства — **Samples**: мажорная версия всех проектов равна мажорной версии Framework (сейчас `5`), минор/патч инкрементируются самостоятельно. В NuGet ничего не публикуется, **CI нет** (`.github/` содержит только `FUNDING.yml`).

## Проекты-примеры

| Solution / проект | Тип команды (базовый класс Engine) | Что демонстрирует |
| --- | --- | --- |
| `Calabonga.Commandex.HelloWorld` | `EmptyCommandexCommand` | простейшая команда «запустил и забыл» |
| `Calabonga.Commandex.WelcomeCommand` | `EmptyCommandexCommand` + `ResultCommandexCommand<string>` | два типа в одном проекте; чтение настроек через `SettingsBase` + keyed DI |
| `Calabonga.Commandex.ValidateApiCommand` | `ResultCommandexCommand<bool>` + `ResultCommandexCommand<ValidateResult>` | возврат простого и составного результата, возврат ошибки через `Operation.Error` |
| `Calabonga.Commandex.DialogCommand` | `DialogCommandexCommand<TView,TResult>` | модальный диалог с валидацией (`DefaultDialogWithValidationResult`) |
| `Calabonga.Commandex.QuizCommand` | `DialogCommandexCommand<…>` | диалог + `GetResult()` → `ClipboardResult` (нужен `Engine.Processors`) |
| `Calabonga.Commandex.TaxPayerStatusCommand` | `DialogCommandexCommand<…>` | реальный вызов сервиса ФНС; `GetResult()` → `TextFileResult`; `INugetDependency` (`Calabonga.TokenGeneratorCore`) |
| `Calabonga.Commandex.PersonWizardCommand` | `WizardDialogCommandexCommand<TViewModel>` | многошаговый wizard (4 шага, payload `PersonViewModel`), `INugetDependency` |
| `Calabonga.Commandex.ParameterCommands` | `ParameterCommandexCommand<PersonData>` ×2 (`ParameterOne`, `ParameterTwo`) | обмен данными между двумя командами через `.prm`-файл |
| `Calabonga.Commandex.RelatedResultsCommand` | `ParameterCommandexCommand<CreatedAtParameter>` ×3 (`First/Second/ThirdCommand`) | цепочка команд, `ThirdCommand` отдаёт результат через `Engine.Processors` |
| `Calabonga.Commandex.ZoneCommand` | `ZoneCommandexCommand<TView,TViewModel>` | встраивание View в зону `MainZone` Shell вместо окна |

Соглашения внутри проекта: класс команды + `Core/` (View/ViewModel/Result/Entities), рядом `*Definition : AppDefinition` с `ConfigureServices` (регистрирует `ICommandexCommand` + View + ViewModel/Result). Версия команды берётся из `Assembly…GetName().Version` (`<Version>` в `.csproj`).

## Сборка


Общего solution нет. Для сборки всех команда в `src` можно использовать `build-all.ps1` в той же папке. А можно собирать каждый `.sln` отдельно:

```bash
dotnet build src/Calabonga.Commandex.DialogCommand/Calabonga.Commandex.DialogCommand.sln -c Release
```

Все 10 solution'ов собираются (Release). Тестов в репозитории нет.

### CopyDLLs

В каждом `.csproj` есть одинаковый post-build target:

```xml
<Target Name="CopyDLLs" AfterTargets="Build">
  <PropertyGroup>
    <PublishedCommandsDir>..\..\..\..\Calabonga.Commandex.Shell\PublishedCommands</PublishedCommandsDir>
  </PropertyGroup>
  <Copy SourceFiles="$(TargetDir)$(ProjectName).dll;$(TargetDir)$(ProjectName).pdb" DestinationFolder="$(PublishedCommandsDir)" />
</Target>
```

Путь `..\..\..\..\Calabonga.Commandex.Shell\PublishedCommands` рассчитан на раскладку рабочего пространства (`Commandex/<repo>/src/<sln-dir>/<proj-dir>/`). Если Shell лежит иначе — правится `PublishedCommandsDir`. `Directory.Build.props` в репозитории нет, target скопирован в каждый `.csproj` (как и во всём рабочем пространстве).

## Версионирование

- Мажор всех проектов = мажор Framework (`Engine`). Сейчас все на `<Version>5.0.1</Version>` и `PackageReference … Version="5.0.1"`.
- Framework поднял минор/патч → подтянуть новую версию `Engine`/`Engine.Processors` в `PackageReference` и инкрементировать только свой `patch`.
- Framework поднял мажор → все проекты переезжают на новый мажор.

`Engine.Processors` — это `Engine` плюс дополнительные обработчики результатов (`ClipboardResult`, `TextFileResult`), поэтому ссылаться на `Engine.Processors` можно в любом проекте команды, независимо от того, использует ли команда эти обработчики. В репозитории оба варианта встречаются и оба допустимы.

## Соглашения

- Все 10 solution'ов собираются в Release без warnings; тестов в репозитории нет.
- Конкретные классы (команды, `*Definition`, результаты, VM, конвертеры, `INugetDependency`) — `sealed` / `sealed partial`. DTO без наследования от классов Engine — `record`.
- Регистрация команды в `*Definition` — `services.AddScoped<ICommandexCommand, …>()`.
- Логирование — только через шаблон (`_logger.LogInformation("{Data}", data)`), не динамической строкой.
- Имя проекта/sln/namespace — `Calabonga.Commandex.<Name>`; класс команды не должен совпадать с именем базового класса Engine.
