// 22. Template Method

// • Назначение: Определяет общий интерфейс для алгоритмов, оставляя некоторые шаги подклассам.
// • Пример из реального мира: Представьте, что вы создаете приложение для заказа кофе. Вам нужно иметь возможность заказывать разные типы кофе, но при этом процесс приготовления должен быть общим.
// • Пример кода:

// Абстрактный класс для приготовления кофе
public abstract class CoffeeMaker
{
    public void PrepareCoffee()
    {
        BoilWater();
        BrewCoffee();
        PourInCup();
        AddSugarAndMilk(); // Этот шаг может быть опциональным
    }

    protected abstract void BrewCoffee();

    private void BoilWater() => Console.WriteLine("Закипание воды...");
    private void PourInCup() => Console.WriteLine("Наливание кофе в чашку...");
    private void AddSugarAndMilk() => Console.WriteLine("Добавление сахара и молока...");
}

// Конкретные реализации для разных типов кофе
public class AmericanoMaker : CoffeeMaker
{
    protected override void BrewCoffee() => Console.WriteLine("Заваривание кофе...");
}

public class CappuccinoMaker : CoffeeMaker
{
    protected override void BrewCoffee() => Console.WriteLine("Заваривание кофе с молочной пенкой...");
    protected override void AddSugarAndMilk() // Изменяем этот шаг
    {
        Console.WriteLine("Добавление сахара, молока и молочной пены...");
    }
}

// Использование Template Method
public class CoffeeShop
{
    public void MakeCoffee(CoffeeMaker maker)
    {
        maker.PrepareCoffee();
    }
}

// Объяснение: В этом примере Template Method определяет общий шаблон для приготовления кофе. Каждый подкласс (AmericanoMaker, CappuccinoMaker) реализует только один шаг (BrewCoffee), а остальные шаги остаются неизменными.

