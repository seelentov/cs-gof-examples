// 15. Interpreter

// • Назначение: Определяет грамматику для языка и предоставляет механизм интерпретации.
// • Пример из реального мира: Представьте, что вы работаете над приложением, которое может выполнять математические выражения. Вам нужно иметь возможность интерпретировать выражения, написанные на языке математики.
// • Пример кода:

// Интерфейс для выражения
public interface IExpression
{
    int Interpret(Context context);
}

// Контекст для интерпретации
public class Context
{
    public Dictionary<string, int> Variables { get; } = new();

    public void SetVariable(string name, int value) => Variables[name] = value;
    public int GetVariable(string name) => Variables[name];
}

// Терминальные выражения
public class NumberExpression : IExpression
{
    private readonly int _value;

    public NumberExpression(int value)
    {
        _value = value;
    }

    public int Interpret(Context context) => _value;
}

public class VariableExpression : IExpression
{
    private readonly string _name;

    public VariableExpression(string name)
    {
        _name = name;
    }

    public int Interpret(Context context) => context.GetVariable(_name);
}

// Нетерминальные выражения
public class AddExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context) => _left.Interpret(context) + _right.Interpret(context);
}

// Использование Interpreter
public class ExpressionEvaluator
{
    public int Evaluate(string expression, Context context)
    {
        // ... логика разбора выражения и создания дерева выражений
        // В этом примере мы предполагаем, что выражение уже разбито на части
        var left = new VariableExpression("x");
        var right = new NumberExpression(5);
        var addExpression = new AddExpression(left, right);
        return addExpression.Interpret(context);
    }
}

// Объяснение: В этом примере Interpreter позволяет нам интерпретировать математические выражения. Мы создаем дерево выражений, которое представляет выражение, и затем интерпретируем это дерево, чтобы получить результат.

