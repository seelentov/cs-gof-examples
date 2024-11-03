// 10. Facade

// • Назначение: Предоставляет упрощенный интерфейс к сложной системе классов.
// • Пример из реального мира: Представьте, что вы работаете над приложением для управления автомобилем. Вам нужно иметь возможность управлять различными системами автомобиля, такими как двигатель, тормозная система, климат-контроль.
// • Пример кода:

// Подсистемы автомобиля
public class Engine
{
    public void Start() => Console.WriteLine("Запуск двигателя");
    public void Stop() => Console.WriteLine("Остановка двигателя");
}

public class BrakeSystem
{
    public void ApplyBrakes() => Console.WriteLine("Активация тормозной системы");
}

public class ClimateControl
{
    public void SetTemperature(int degrees) => Console.WriteLine($"Установка температуры {degrees} градусов");
}

// Фасад для управления автомобилем
public class CarFacade
{
    private readonly Engine _engine;
    private readonly BrakeSystem _brakeSystem;
    private readonly ClimateControl _climateControl;

    public CarFacade()
    {
        _engine = new Engine();
        _brakeSystem = new BrakeSystem();
        _climateControl = new ClimateControl();
    }

    public void StartCar()
    {
        _engine.Start();
        _climateControl.SetTemperature(22); // Автоматически устанавливаем температуру
    }

    public void StopCar()
    {
        _engine.Stop();
        _brakeSystem.ApplyBrakes();
    }
}

// Использование фасад
public class Driver
{
    public void DriveCar()
    {
        var car = new CarFacade();
        car.StartCar();
        Console.WriteLine("Езда...");
        car.StopCar();
    }
}

// Объяснение: В этом примере Facade позволяет нам управлять автомобилем, используя простой интерфейс CarFacade. Facade скрывает сложность взаимодействия с различными подсистемами автомобиля, предоставляя нам удобный способ управления.

