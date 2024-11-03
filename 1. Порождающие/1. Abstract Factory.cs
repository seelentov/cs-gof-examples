// 1.Abstract Factory

// • Назначение: Предоставляет интерфейс для создания семейств взаимосвязанных объектов без привязки к конкретным классам.
// • Пример из реального мира: Представьте, что вы разрабатываете интернет-магазин, который продает одежду разных брендов. Вам нужно иметь возможность создавать объекты, представляющие одежду разных брендов (например, футболки, штаны) с учетом особенностей дизайна и размеров каждого бренда.
// • Пример кода:

// Интерфейс для создания одежды
public interface IClothing
{
    string GetName();
    string GetBrand();
}

// Конкретные типы одежды
public class TShirt : IClothing
{
    public string GetName() => "Футболка";
    public string GetBrand() => "Nike";
}

public class Jeans : IClothing
{
    public string GetName() => "Джинсы";
    public string GetBrand() => "Levi's";
}

// Интерфейс фабрики
public interface IClothingFactory
{
    IClothing CreateTShirt();
    IClothing CreateJeans();
}

// Конкретные фабрики для разных брендов
public class NikeFactory : IClothingFactory
{
    public IClothing CreateTShirt() => new TShirt();
    public IClothing CreateJeans() => new Jeans { GetBrand() = "Nike" }; // Nike может делать и джинсы
}

public class LeviFactory : IClothingFactory
{
    public IClothing CreateTShirt() => new TShirt { GetBrand() = "Levi's" }; // Levi's может делать и футболки
    public IClothing CreateJeans() => new Jeans();
}

// Использование фабрики
public class Shop
{
    public void CreateClothing(IClothingFactory factory)
    {
        var shirt = factory.CreateTShirt();
        var jeans = factory.CreateJeans();
        Console.WriteLine($"Создана одежда: {shirt.GetName()} ({shirt.GetBrand()}), {jeans.GetName()} ({jeans.GetBrand()})");
    }
}

// Объяснение: В этом примере мы имеем два бренда (Nike и Levi's) и два типа одежды (футболка и джинсы). Abstract Factory позволяет нам создавать объекты одежды, используя подходящую фабрику для выбранного бренда. Это позволяет нам создавать разные виды одежды, сохраняя при этом когерентность дизайна и размеров для каждого бренда.

