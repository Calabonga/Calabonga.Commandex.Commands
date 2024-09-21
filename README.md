## Commands Types in Commandex
Все типы перечисленные ниже реализуют интерфейс `ICommandexCommand`, то есть не обязательно наследовать свою команду от одного из существующих типов, можно просто реализовать интерфейс. Но в базоых реализациях очень много полезного.

### EmptyCommandexCommand
Это самый простой тип команды, которые ничего не должен возвращать на `Shell`, простой триггер, которые можно что-то сделать, и при этом не должен никому ни в чем отчитываться.
Simplest command type for Commandex. This type does not anything returns to shell.

### ResultCommand
[в процессе наполнения]

### DialogCommand
[в процессе наполнения]

### WizardCommand
[в процессе наполнения]

## What is Calabonga.Commandex

It's a complex solution with a few repositories:

* **[Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell)** → Command Executer or Command Launcher. To run commands of any type for any purpose. For example, to execute a stored procedure or just to copy some files to some destination.

* **[Calabonga.Commandex.Commands](https://github.com/Calabonga/Calabonga.Commandex.Commands)** → Commands for Calabonga.Commandex.Shell that can execute them from unified shell.

* **[Calabonga.Commandex.Shell.Develop.Template](https://github.com/Calabonga/Calabonga.Commandex.Shell.Develop.Template)** → This is a Developer version of the Command Executer (`Calabonga.Commandex`). Witch is created to runs commands of any type for any purposes. For example, to execute a stored procedure or just to co…

* **[Calabonga.Commandex.Engine](https://github.com/Calabonga/Calabonga.Commandex.Engine)** → Engine and contracts library for Calabonga.Commandex. Contracts are using for developing a modules for Commandex Shell.

## Видео (Video)

В основном репозитории [Calabonga.Commandex.Shell](https://github.com/Calabonga/Calabonga.Commandex.Shell) есть несколько видео с инструкциями и разъяснениями, как использовать Commandex. А также видео о том, какие типы команд существуют и как для Commandex создавать команды разных типов.
