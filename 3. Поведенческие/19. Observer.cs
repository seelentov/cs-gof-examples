// 19. Observer

// • Назначение: Определяет зависимость между объектами "один ко многим", чтобы при изменении состояния одного объекта все зависящие от него объекты уведомлялись и обновлялись автоматически.
// • Пример из реального мира: Представьте, что вы создаете систему погоды. Вам нужно, чтобы пользователи получали уведомления об изменениях погоды.
// • Пример кода:

// Интерфейс наблюдателя
public interface IWeatherObserver
{
    void Update(string condition);
}

// Интерфейс источника уведомлений (погодная станция)
public interface IWeatherStation
{
    void Attach(IWeatherObserver observer);
    void Detach(IWeatherObserver observer);
    void NotifyObservers();
}

// Конкретный источник уведомлений
public class WeatherStation : IWeatherStation
{
    private readonly List<IWeatherObserver> _observers = new();
    private string _condition;

    public void Attach(IWeatherObserver observer) => _observers.Add(observer);
    public void Detach(IWeatherObserver observer) => _observers.Remove(observer);
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_condition);
        }
    }

    public string Condition
    {
        get => _condition;
        set
        {
            _condition = value;
            NotifyObservers();
        }
    }
}

// Конкретные наблюдатели
public class PhoneObserver : IWeatherObserver
{
    public void Update(string condition) => Console.WriteLine($"Телефон получил уведомление: {condition}");
}

public class EmailObserver : IWeatherObserver
{
    public void Update(string condition) => Console.WriteLine($"Электронная почта получила уведомление: {condition}");
}

// Использование Observer
public class WeatherApp
{
    public void Start()
    {
        var station = new WeatherStation();
        var phone = new PhoneObserver();
        var email = new EmailObserver();

        station.Attach(phone);
        station.Attach(email);

        station.Condition = "Солнечно";

        station.Detach(phone); // Отключаем уведомления на телефон

        station.Condition = "Дождь";
    }
}

// Объяснение: В этом примере Observer позволяет нам уведомлять разных пользователей (телефон, почта) об изменениях погоды. Погодная станция (WeatherStation) уведомляет всех своих подписчиков (наблюдателей) об изменениях состояния.

