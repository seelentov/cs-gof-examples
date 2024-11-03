// 9. Decorator

// • Назначение: Позволяет добавлять новые функциональные возможности к объекту динамически.
// • Пример из реального мира: Представьте, что вы работаете над приложением для заказа еды. Вам нужно иметь возможность добавлять к заказу дополнительные опции, такие как напитки, десерты, соусы.
// • Пример кода:

// Интерфейс для заказа
public interface IOrder
{
    decimal GetTotal();
    void AddItem(string item);
}

// Базовый заказ
public class BasicOrder : IOrder
{
    private decimal _total = 0;
    private readonly List<string> _items = new List<string>();

    public decimal GetTotal() => _total;

    public void AddItem(string item)
    {
        _total += 10; // Простая стоимость товара
        _items.Add(item);
    }
}

// Декораторы для дополнительных опций
public abstract class OrderDecorator : IOrder
{
    protected readonly IOrder _order;

    protected OrderDecorator(IOrder order)
    {
        _order = order;
    }

    public virtual decimal GetTotal() => _order.GetTotal();
    public virtual void AddItem(string item) => _order.AddItem(item);
}

public class DrinkDecorator : OrderDecorator
{
    public DrinkDecorator(IOrder order) : base(order) { }

    public override void AddItem(string item)
    {
        base.AddItem(item);
        Console.WriteLine($"Добавлен напиток {item}");
    }

    public override decimal GetTotal() => base.GetTotal() + 5; // Добавляем стоимость напитка
}

public class DessertDecorator : OrderDecorator
{
    public DessertDecorator(IOrder order) : base(order) { }

    public override void AddItem(string item)
    {
        base.AddItem(item);
        Console.WriteLine($"Добавлен десерт {item}");
    }

    public override decimal GetTotal() => base.GetTotal() + 8; // Добавляем стоимость десерта
}

// Использование Decorator
public class OrderManager
{
    public void PlaceOrder()
    {
        var order = new BasicOrder();
        order.AddItem("Пицца");
        order = new DrinkDecorator(order); // Добавляем напиток
        order.AddItem("Кола");
        order = new DessertDecorator(order); // Добавляем десерт
        order.AddItem("Чизкейк");

        Console.WriteLine($"Итоговая стоимость: {order.GetTotal()}");
    }
}

// Объяснение: В этом примере Decorator позволяет нам динамически добавлять к заказу дополнительные опции (напитки, десерты). Мы можем использовать разные декораторы, чтобы добавить различные опции к заказу, не изменяя основной код заказа.

