// 23. Visitor

// • Назначение: Представляет новый функционал, не изменяя структуру существующих классов.
// • Пример из реального мира: Представьте, что у вас есть приложение для создания отчетов. Вам нужно иметь возможность создавать отчеты для разных типов данных, например, для сотрудников, для проектов, для задач.
// • Пример кода:

// Интерфейс для элемента (например, сотрудник, проект, задача)
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Конкретные элементы
public class Employee : IElement
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Project : IElement
{
    public string Name { get; }

    public Project(string name)
    {
        Name = name;
    }

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

// Интерфейс для посетителя
public interface IVisitor
{
    void Visit(Employee employee);
    void Visit(Project project);
}

// Конкретные посетители
public class EmployeeReportVisitor : IVisitor
{
    public void Visit(Employee employee) => Console.WriteLine($"Сотрудник: {employee.Name}");
    public void Visit(Project project) { }
}

public class ProjectReportVisitor : IVisitor
{
    public void Visit(Employee employee) { }
    public void Visit(Project project) => Console.WriteLine($"Проект: {project.Name}");
}

// Использование Visitor
public class ReportGenerator
{
    public void GenerateReport(List<IElement> elements, IVisitor visitor)
    {
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}

// Объяснение: В этом примере Visitor позволяет нам добавлять новый функционал (создание отчетов) к существующим элементам (сотрудник, проект), не изменяя их код. Мы можем создавать разные посетители, которые будут генерировать разные типы отчетов.