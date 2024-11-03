// 18. Memento

// • Назначение: Позволяет сохранить и восстановить состояние объекта, не раскрывая его внутреннего представления.
// • Пример из реального мира: Представьте, что вы работаете над текстовым редактором. Вам нужно иметь возможность отменять действия, которые были выполнены ранее.
// • Пример кода:

// Класс редактора
public class Editor
{
    private string _content;

    public void SetContent(string content) => _content = content;

    public Memento CreateMemento() => new Memento(_content);

    public void RestoreFromMemento(Memento memento) => _content = memento.Content;

    public string Content => _content;
}

// Класс хранилища состояния
public class Memento
{
    public string Content { get; }

    public Memento(string content)
    {
        Content = content;
    }
}

// Использование Memento
public class EditorManager
{
    public void RunEditor()
    {
        var editor = new Editor();
        editor.SetContent("Первоначальный текст");

        var memento = editor.CreateMemento();

        editor.SetContent("Измененный текст");

        Console.WriteLine($"Текущий текст: {editor.Content}");

        editor.RestoreFromMemento(memento);

        Console.WriteLine($"Восстановленный текст: {editor.Content}");
    }
}

// Объяснение: В этом примере Memento позволяет нам сохранить состояние редактора и восстановить его в любой момент. Мы можем создавать "моменты" (Memento) состояния редактора, а затем восстанавливать его из этих моментов. 

