// 17.Mediator

// • Назначение: Определяет объект, инкапсулирующий способ, в котором взаимодействуют наборы объектов.
// • Пример из реального мира: Представьте, что вы проектируете систему управления чатом. В чате могут быть разные участники, которые могут отправлять сообщения друг другу. 
// • Пример кода:

// Интерфейс медиатора
public interface IChatMediator
{
    void SendMessage(User sender, string message);
}

// Конкретный медиатор для чата
public class ChatMediator : IChatMediator
{
    private readonly Dictionary<string, User> _users = new();

    public void SendMessage(User sender, string message)
    {
        Console.WriteLine($"{sender.Name}: {message}");

        foreach (var user in _users.Values)
        {
            if (user != sender)
            {
                user.ReceiveMessage(message);
            }
        }
    }

    public void Join(User user) => _users[user.Name] = user;
}

// Класс пользователя
public class User
{
    public string Name { get; }
    private readonly IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message) => _mediator.SendMessage(this, message);
    public void ReceiveMessage(string message) => Console.WriteLine($"{Name} получил сообщение: {message}");
}

// Использование Mediator
public class ChatRoom
{
    public void Start()
    {
        var mediator = new ChatMediator();
        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);
        var user3 = new User("Charlie", mediator);

        mediator.Join(user1);
        mediator.Join(user2);
        mediator.Join(user3);

        user1.SendMessage("Привет всем!");
        user2.SendMessage("Привет, Alice!");
        user3.SendMessage("Привет, Alice! Привет, Bob!");
    }
}

// Объяснение: В этом примере Mediator(ChatMediator) управляет взаимодействием между пользователями чата. Пользователи отправляют сообщения через медиатора, который затем перенаправляет их другим пользователям.

