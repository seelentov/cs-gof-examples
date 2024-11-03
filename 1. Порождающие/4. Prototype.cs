// 4. Prototype

// • Назначение: Позволяет копировать существующие объекты, не вдаваясь в подробности их реализации.
// • Пример из реального мира: Представьте, что вы работаете над редактором документов. Вам нужно иметь возможность дублировать существующие документы, чтобы не терять исходный вариант.
// • Пример кода:

// Интерфейс для клонирования
public interface ICloneable
{
    object Clone();
}

// Класс документа
public class Document : ICloneable
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public object Clone() => new Document(Title, Content);
}

// Использование Prototype
public class DocumentManager
{
    public void DuplicateDocument(Document document)
    {
        var copy = (Document)document.Clone();
        Console.WriteLine($"Создана копия документа: {copy.Title}");
    }
}

// Объяснение: В этом примере мы используем Prototype для создания копии существующего документа. Мы не используем конструктор для создания нового объекта, а вместо этого вызываем метод Clone(), который возвращает копию. Это позволяет нам не копировать всю логику создания документа, а использовать уже существующий объект как шаблон.

