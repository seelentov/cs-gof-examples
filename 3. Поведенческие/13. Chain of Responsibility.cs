// 13. Chain of Responsibility

// • Назначение: Позволяет передавать запросы по цепочке обработчиков.
// • Пример из реального мира: Представьте, что у вас есть система обработки заявок. Заявка может пройти через несколько обработчиков, каждый из которых может ее одобрить, отклонить или передать следующему обработчику.
// • Пример кода:

// Интерфейс для обработчика
public interface IHandler
{
    void Handle(Request request);
    void SetNext(IHandler handler);
}

// Класс заявки
public class Request
{
    public string Name { get; }
    public int Amount { get; }

    public Request(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }
}

// Конкретные обработчики
public class FirstHandler : IHandler
{
    private IHandler _nextHandler;

    public void Handle(Request request)
    {
        if (request.Amount < 100)
        {
            Console.WriteLine($"FirstHandler одобрил заявку {request.Name} на сумму {request.Amount}");
        }
        else
        {
            Console.WriteLine($"FirstHandler передал заявку {request.Name} на сумму {request.Amount}");
            _nextHandler.Handle(request);
        }
    }

    public void SetNext(IHandler handler) => _nextHandler = handler;
}

public class SecondHandler : IHandler
{
    private IHandler _nextHandler;

    public void Handle(Request request)
    {
        if (request.Amount >= 100 && request.Amount < 500)
        {
            Console.WriteLine($"SecondHandler одобрил заявку {request.Name} на сумму {request.Amount}");
        }
        else
        {
            Console.WriteLine($"SecondHandler передал заявку {request.Name} на сумму {request.Amount}");
            _nextHandler.Handle(request);
        }
    }

    public void SetNext(IHandler handler) => _nextHandler = handler;
}

public class ThirdHandler : IHandler
{
    private IHandler _nextHandler;

    public void Handle(Request request)
    {
        if (request.Amount >= 500)
        {
            Console.WriteLine($"ThirdHandler одобрил заявку {request.Name} на сумму {request.Amount}");
        }
        else
        {
            Console.WriteLine($"ThirdHandler отклонил заявку {request.Name} на сумму {request.Amount}");
        }
    }

    public void SetNext(IHandler handler) => _nextHandler = handler;
}

// Использование Chain of Responsibility
public class RequestManager
{
    public void ProcessRequest(Request request)
    {
        var firstHandler = new FirstHandler();
        var secondHandler = new SecondHandler();
        var thirdHandler = new ThirdHandler();

        firstHandler.SetNext(secondHandler);
        secondHandler.SetNext(thirdHandler);

        firstHandler.Handle(request);
    }
}

// Объяснение: В этом примере Chain of Responsibility позволяет нам обработать заявку, передавая ее по цепочке обработчиков. Каждый обработчик может одобрить заявку, отклонить ее или передать ее следующему обработчику, в зависимости от суммы заявки.

