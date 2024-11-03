// 14. Command

// • Назначение: Окружает запрос объектом, чтобы сохранять и передавать его.
// • Пример из реального мира: Представьте, что вы работаете над текстовым редактором. Вам нужно иметь возможность выполнять разные команды, такие как "открыть файл", "сохранить файл", "отменить действие".
// • Пример кода:

// Интерфейс для команды
public interface ICommand
{
    void Execute();
}

// Конкретные команды
public class OpenFileCommand : ICommand
{
    private readonly string _fileName;

    public OpenFileCommand(string fileName)
    {
        _fileName = fileName;
    }

    public void Execute() => Console.WriteLine($"Открытие файла: {_fileName}");
}

public class SaveFileCommand : ICommand
{
    private readonly string _fileName;

    public SaveFileCommand(string fileName)
    {
        _fileName = fileName;
    }

    public void Execute() => Console.WriteLine($"Сохранение файла: {_fileName}");
}

// Приемник команды
public class TextEditor
{
    public void OpenFile(string fileName) => Console.WriteLine($"Открытие файла: {fileName}");
    public void SaveFile(string fileName) => Console.WriteLine($"Сохранение файла: {fileName}");
}

// Использование Command
public class EditorManager
{
    public void RunCommand(ICommand command)
    {
        command.Execute();
    }
}

// Объяснение: В этом примере Command позволяет нам инкапсулировать различные команды в отдельные объекты. Это позволяет нам легко сохранять, передавать и выполнять команды, не привязываясь к конкретному методу.

