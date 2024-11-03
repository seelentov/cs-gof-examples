// 11. Flyweight

// • Назначение: Использует разделение для эффективного использования памяти.
// • Пример из реального мира: Представьте, что вы создаете текстовый редактор. Вам нужно иметь возможность отображать текст, используя разные шрифты.
// • Пример кода:

// Интерфейс для шрифтов
public interface IFont
{
    void Draw(string text);
}

// Конкретные шрифты
public class ArialFont : IFont
{
    public void Draw(string text) => Console.WriteLine($"Arial: {text}");
}

public class TimesNewRomanFont : IFont
{
    public void Draw(string text) => Console.WriteLine($"Times New Roman: {text}");
}

// Фабрика шрифтов
public class FontFactory
{
    private readonly Dictionary<string, IFont> _fonts = new();

    public IFont GetFont(string name)
    {
        if (!_fonts.TryGetValue(name, out var font))
        {
            switch (name)
            {
                case "Arial": font = new ArialFont(); break;
                case "Times New Roman": font = new TimesNewRomanFont(); break;
            }
            _fonts[name] = font;
        }
        return font;
    }
}

// Использование Flyweight
public class TextEditor
{
    public void DisplayText(string text, string fontName)
    {
        var fontFactory = new FontFactory();
        var font = fontFactory.GetFont(fontName);
        font.Draw(text);
    }
}

// Объяснение: В этом примере Flyweight позволяет нам использовать один и тот же объект Font для отображения разных текстов. Фабрика FontFactory гарантирует, что для каждого имени шрифта создается только один объект Font. Это позволяет нам сэкономить память, особенно если мы работаем с большим количеством текста.

