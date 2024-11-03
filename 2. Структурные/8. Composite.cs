// 8. Composite

// • Назначение: Позволяет клиентам обращаться к отдельным объектам и к их составным представителям одинаково.
// • Пример из реального мира: Представьте, что вы работаете над приложением для организации файлов. Вам нужно иметь возможность обращаться к отдельным файлам и к папкам, которые могут содержать другие файлы и папки.
// • Пример кода:

// Интерфейс для файлов и папок
public interface IFileSystemItem
{
    string GetName();
    long GetSize();
}

// Класс файла
public class File : IFileSystemItem
{
    public string Name { get; }
    public long Size { get; }

    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }

    public string GetName() => Name;
    public long GetSize() => Size;
}

// Класс папки
public class Folder : IFileSystemItem
{
    public string Name { get; }
    private readonly List<IFileSystemItem> _items = new List<IFileSystemItem>();

    public Folder(string name)
    {
        Name = name;
    }

    public string GetName() => Name;
    public long GetSize() => _items.Sum(item => item.GetSize());

    public void AddItem(IFileSystemItem item) => _items.Add(item);
}

// Использование Composite
public class FileSystem
{
    public void ListItems(IFileSystemItem item)
    {
        Console.WriteLine($"{item.GetName()} ({item.GetSize()})");

        if (item is Folder folder)
        {
            foreach (var subItem in folder._items)
            {
                ListItems(subItem);
            }
        }
    }
}

// Объяснение: В этом примере Composite позволяет нам использовать единый подход для работы с файлами и папками. Мы можем обращаться к отдельным файлам, а также к папкам, которые могут содержать другие файлы и папки, используя один и тот же интерфейс IFileSystemItem.

