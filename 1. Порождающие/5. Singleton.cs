// 5. Singleton

// • Назначение: Обеспечивает создание единственного экземпляра класса и предоставляет глобальную точку доступа к этому экземпляру.
// • Пример из реального мира: Представьте, что у вас есть приложение, которое управляет настройками. Вам нужно, чтобы настройки были доступны из любой части приложения, и при этом вы не хотите, чтобы настройки дублировались.
// • Пример кода:

// Класс настроек
public class Settings
{
    private static Settings _instance;

    private Settings() { }

    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Settings();
            }
            return _instance;
        }
    }

    public string Theme { get; set; } = "Light";
    public bool NotificationsEnabled { get; set; } = true;
}

// Использование Singleton
public class Application
{
    public void LoadSettings()
    {
        Console.WriteLine($"Текущая тема: {Settings.Instance.Theme}");
        Console.WriteLine($"Уведомления: {Settings.Instance.NotificationsEnabled}");
    }
}

// Объяснение: В этом примере Singleton обеспечивает доступ к единственному экземпляру класса Settings. Это позволяет нам использовать настройки из любой части приложения, не беспокоясь о дублировании данных.