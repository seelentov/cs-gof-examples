// 2. Builder

// • Назначение: Разделяет конструирование сложного объекта и его представление, чтобы один и тот же процесс конструирования мог создавать разные представления.
// • Пример из реального мира: Представьте, что вы заказываете пиццу. Вы можете выбрать разные варианты начинки, теста, размера, и в зависимости от ваших предпочтений вы получите совершенно разную пиццу.
// • Пример кода:

// Класс пиццы
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; set; } = new();

    public override string ToString() => $"Pizza with {Dough} dough, {Sauce} sauce and toppings: {string.Join(", ", Toppings)}";
}

// Строитель пиццы
public class PizzaBuilder
{
    private readonly Pizza _pizza = new Pizza();

    public PizzaBuilder SetDough(string dough)
    {
        _pizza.Dough = dough;
        return this;
    }

    public PizzaBuilder SetSauce(string sauce)
    {
        _pizza.Sauce = sauce;
        return this;
    }

    public PizzaBuilder AddTopping(string topping)
    {
        _pizza.Toppings.Add(topping);
        return this;
    }

    public Pizza Build() => _pizza;
}

// Использование строителя
public class Pizzeria
{
    public void MakePizza()
    {
        var pizza = new PizzaBuilder()
            .SetDough("Thin crust")
            .SetSauce("Tomato sauce")
            .AddTopping("Cheese")
            .AddTopping("Pepperoni")
            .Build();
        Console.WriteLine($"Made pizza: {pizza}");
    }
}

// Объяснение: Builder позволяет нам шаг за шагом конструировать объект Pizza, добавляя нужные ингредиенты. В результате мы можем создавать пиццы с разными сочетаниями компонентов.