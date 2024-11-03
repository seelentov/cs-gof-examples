// 21. Strategy

// • Назначение: Определяет семейство алгоритмов, инкапсулирует каждый из них и делает их взаимозаменяемыми.
// • Пример из реального мира: Представьте, что вы создаете приложение для маршрутизации. Вам нужно иметь возможность использовать разные алгоритмы маршрутизации, например, самый быстрый путь, самый короткий путь, путь с наименьшим количеством поворотов.
// • Пример кода:

// Интерфейс алгоритма маршрутизации
public interface IRouteStrategy
{
    string GetRoute(string start, string end);
}

// Конкретные алгоритмы маршрутизации
public class FastestRouteStrategy : IRouteStrategy
{
    public string GetRoute(string start, string end) => $"Самый быстрый маршрут от {start} до {end}";
}

public class ShortestRouteStrategy : IRouteStrategy
{
    public string GetRoute(string start, string end) => $"Самый короткий маршрут от {start} до {end}";
}

// Контекст приложения
public class NavigationApp
{
    private IRouteStrategy _strategy;

    public void SetRouteStrategy(IRouteStrategy strategy) => _strategy = strategy;

    public string GetRoute(string start, string end) => _strategy.GetRoute(start, end);
}

// Использование Strategy
public class User
{
    public void FindRoute()
    {
        var app = new NavigationApp();

        Console.WriteLine("Выберите алгоритм маршрутизации:");
        Console.WriteLine("1. Самый быстрый");
        Console.WriteLine("2. Самый короткий");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": app.SetRouteStrategy(new FastestRouteStrategy()); break;
            case "2": app.SetRouteStrategy(new ShortestRouteStrategy()); break;
        }

        var route = app.GetRoute("Москва", "Санкт-Петербург");
        Console.WriteLine($"Маршрут: {route}");
    }
}

// Объяснение: В этом примере Strategy позволяет нам использовать разные алгоритмы маршрутизации, не изменяя код приложения. Мы можем динамически выбирать алгоритм, который нам нужен.

