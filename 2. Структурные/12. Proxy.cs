// 12. Proxy

// • Назначение: Позволяет заменять объект специальным представителем, чтобы контролировать доступ к нему.
// • Пример из реального мира: Представьте, что у вас есть приложение, которое может работать с файлами на сервере. Вам нужно иметь возможность контролировать доступ к файлам, чтобы предотвратить несанкционированное использование.
// • Пример кода:

// Интерфейс для работы с файлами
public interface IFileService
{
    string ReadFile(string fileName);
    void WriteFile(string fileName, string content);
}

// Реальный сервис для работы с файлами
public class RealFileService : IFileService
{
    public string ReadFile(string fileName)
    {
        Console.WriteLine($"Чтение файла {fileName}");
        // ... чтение файла
        return "Content of file";
    }

    public void WriteFile(string fileName, string content)
    {
        Console.WriteLine($"Запись в файл {fileName}");
        // ... запись в файл
    }
}

// Прокси для контроля доступа
public class FileServiceProxy : IFileService
{
    private readonly RealFileService _realService;

    public FileServiceProxy(RealFileService realService)
    {
        _realService = realService;
    }

    public string ReadFile(string fileName)
    {
        if (CheckAccess(fileName))
        {
            Console.WriteLine($"Доступ разрешен");
            return _realService.ReadFile(fileName);
        }
        else
        {
            Console.WriteLine($"Доступ запрещен");
            return null;
        }
    }

    public void WriteFile(string fileName, string content)
    {
        if (CheckAccess(fileName))
        {
            Console.WriteLine($"Доступ разрешен");
            _realService.WriteFile(fileName, content);
        }
        else
        {
            Console.WriteLine($"Доступ запрещен");
        }
    }

    private bool CheckAccess(string fileName)
    {
        // ... логика проверки доступа
        return true; // В этом примере доступ всегда разрешен
    }
}

// Использование Proxy
public class Application
{
    public void AccessFiles()
    {
        var realService = new RealFileService();
        var proxy = new FileServiceProxy(realService);
        Console.WriteLine(proxy.ReadFile("important_file.txt"));
        proxy.WriteFile("log.txt", "Some log message");
    }
}

// Объяснение: В этом примере Proxy позволяет нам контролировать доступ к файлам на сервере. Прокси проверяет права доступа к файлу, прежде чем делегировать вызов реальному сервису.

