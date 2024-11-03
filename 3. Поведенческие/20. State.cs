// 20. State

// • Назначение: Позволяет объекту изменять свое поведение при изменении его внутреннего состояния.
// • Пример из реального мира: Представьте, что вы создаете игру. У персонажа могут быть разные состояния, например, "в движении", "в атаке", "в защите".
// • Пример кода:

// Интерфейс состояния
public interface IGameState
{
    void HandleInput(GameContext context, string input);
}

// Конкретные состояния
public class WalkingState : IGameState
{
    public void HandleInput(GameContext context, string input)
    {
        if (input == "Attack")
        {
            Console.WriteLine("Переход в состояние атаки");
            context.SetState(new AttackingState());
        }
        else
        {
            Console.WriteLine("Продолжение движения");
        }
    }
}

public class AttackingState : IGameState
{
    public void HandleInput(GameContext context, string input)
    {
        if (input == "Move")
        {
            Console.WriteLine("Переход в состояние движения");
            context.SetState(new WalkingState());
        }
        else
        {
            Console.WriteLine("Продолжение атаки");
        }
    }
}

// Контекст игры
public class GameContext
{
    private IGameState _state;

    public GameContext(IGameState state)
    {
        _state = state;
    }

    public void SetState(IGameState state) => _state = state;

    public void HandleInput(string input) => _state.HandleInput(this, input);
}

// Использование State
public class Game
{
    public void Play()
    {
        var context = new GameContext(new WalkingState());

        context.HandleInput("Move");
        context.HandleInput("Attack");
        context.HandleInput("Attack");
        context.HandleInput("Move");
    }
}

// Объяснение: В этом примере State позволяет нам изменять поведение персонажа в зависимости от его состояния. Мы можем переключаться между состояниями "движение", "атака", "защита" в зависимости от ввода пользователя.

