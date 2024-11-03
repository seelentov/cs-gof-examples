// 3. Factory Method

// • Назначение: Определяет интерфейс для создания объекта, но позволяет подклассам решать, какой класс инстанцировать.
// • Пример из реального мира: Представьте, что вы создаете приложение, которое может работать с разными типами баз данных. Вам нужно иметь возможность создать объект, который будет взаимодействовать с выбранной базой данных.
// • Пример кода:

// Интерфейс для создания соединения с базой данных
public interface IDatabaseConnection
{
    void Connect();
    void Disconnect();
}

// Конкретные реализации для разных баз данных
public class MySQLConnection : IDatabaseConnection
{
    public void Connect() => Console.WriteLine("Connecting to MySQL");
    public void Disconnect() => Console.WriteLine("Disconnecting from MySQL");
}

public class PostgreSQLConnection : IDatabaseConnection
{
    public void Connect() => Console.WriteLine("Connecting to PostgreSQL");
    public void Disconnect() => Console.WriteLine("Disconnecting from PostgreSQL");
}

// Абстрактный класс фабрики
public abstract class ConnectionFactory
{
    public abstract IDatabaseConnection CreateConnection();
}

// Конкретные фабрики для разных типов баз данных
public class MySQLFactory : ConnectionFactory
{
    public override IDatabaseConnection CreateConnection() => new MySQLConnection();
}

public class PostgreSQLFactory : ConnectionFactory
{
    public override IDatabaseConnection CreateConnection() => new PostgreSQLConnection();
}

// Использование фабрики
public class DatabaseManager
{
    public void UseDatabase(ConnectionFactory factory)
    {
        var connection = factory.CreateConnection();
        connection.Connect();
        Console.WriteLine("Performing some operations...");
        connection.Disconnect();
    }
}

// Объяснение: В этом примере мы используем Factory Method для создания объекта, который будет взаимодействовать с выбранной базой данных. Каждый подкласс ConnectionFactory решает, какой конкретный тип соединения нужно создать, предоставляя нам гибкость в выборе базы данных.

