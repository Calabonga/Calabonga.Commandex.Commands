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

## Video

### [Commandex Framework - Модульный монолит. Идея.](https://boosty.to/calabonga/posts/88abe79c-c396-4b03-9dc2-4c76b20a25ca)

В продолжение темы про эволюцию архитектуры программного обеспечения, в котором речь зашла про "модульный монолит".
В этом видео - пример реализации модульного монолита.

### [Commandex Framework - Модульный монолит. Знакомство.](https://boosty.to/calabonga/posts/3915ad48-1f0b-44cc-83ac-a1981d8d6c8e)
В этом видео я представлю вашему вниманию свой новый фреймворк, которые позволит без особых усилий организовать на платформе WPF приложение по работе с плагинами.

### [Commandex Framework - Модульный монолит. Shell.](https://boosty.to/calabonga/posts/dba3f618-314e-4383-ae7b-2485ba93a058)

Немного теории про Commandex Framework. В этом видео подробнее про Commandex Shell:

* Клонирование репозитория (загрузка)
* Компиляция
* Настройки в .env
* Справка по работе с Shell
   * Папка с плагинами
   * Nuget установленные и не только...
   * Логирование
   * И другие полезные мелочи

### [Commandex Framework - Модульный монолит. EmptyCommand.](https://boosty.to/calabonga/posts/fdfd99c2-a3d2-4b19-94ee-eae01aac2ae0)

`EmptyCommandexCommand` - это самый простой тип команды, которые ничего не должен возвращать на Shell, простой триггер, которые можно что-то сделать, и при этом не должен никому ни в чем отчитываться. Simplest command type for Commandex. This type does not anything returns to shell.

### Commandex Framework - Модульный монолит. Result-команды. Часть 4. [видео готовится]

`ResultCommandexCommand<T>` - это вид команды, который может вернуть на Shell результаты своей работы. На видео были созданы две новые команды:

* `CheckApiReadyCommandexCommand` - возвращает `bool`-значение, которое выбирается случайным образом. 
* `ValidateDocumentCommandexCommand` - возвращает класс `ValidateResult`, значения свойств которого, также выбирается случайным образом. Вдобавок, я показал как обрабатывает Shell ошибки, которые возникают при выполнении команд.


### Commandex Framework - Модульный монолит. Dialog-команды. Часть 5. [видео планируется]

### Commandex Framework - Модульный монолит. Wizard-команды. Часть 6.[видео планируется]

### Commandex Framework - Модульный монолит. Parameter-команды. Часть 7. [видео планируется]
