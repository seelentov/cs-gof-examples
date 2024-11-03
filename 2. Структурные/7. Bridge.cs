// 7. Bridge

// • Назначение: Разделяет абстракцию и реализацию, позволяя изменять обе независимо.
// • Пример из реального мира: Представьте, что вы разрабатываете приложение для рисования. Вам нужно иметь возможность рисовать фигуры разных форм (круг, квадрат) и использовать разные инструменты (кисть, карандаш).
// • Пример кода:

// Интерфейс фигуры
public interface IShape
{
    void Draw();
}

// Конкретные фигуры
public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a circle");
}

public class Square : IShape
{
    public void Draw() => Console.WriteLine("Drawing a square");
}

// Интерфейс инструмента
public interface ITool
{
    void Use(IShape shape);
}

// Конкретные инструменты
public class Brush : ITool
{
    public void Use(IShape shape) => Console.WriteLine($"Using brush to draw a {shape.GetType().Name}");
}

public class Pencil : ITool
{
    public void Use(IShape shape) => Console.WriteLine($"Using pencil to draw a {shape.GetType().Name}");
}

// Использование Bridge
public class DrawingApplication
{
    public void Draw(IShape shape, ITool tool)
    {
        tool.Use(shape);
    }
}

// Объяснение: В этом примере Bridge позволяет нам использовать разные инструменты (кисть, карандаш) для рисования разных фигур (круг, квадрат). Мы можем менять и фигуры, и инструменты независимо друг от друга.

