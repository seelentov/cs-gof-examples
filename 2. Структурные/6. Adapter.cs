// 6. Adapter

// • Назначение: Позволяет совместить несовместимые интерфейсы.
// • Пример из реального мира: Представьте, что у вас есть устройство, которое использует USB-порт, но вам нужно подключить к нему устройство с другим типом разъема.
// • Пример кода:

// Интерфейс USB-устройства
public interface IUsbDevice
{
    void Connect();
    void Disconnect();
    void SendData();
}

// Устройство с другим разъемом
public class LegacyDevice
{
    public void LegacyConnect() => Console.WriteLine("Connecting to legacy device");
    public void LegacySendData() => Console.WriteLine("Sending data to legacy device");
    public void LegacyDisconnect() => Console.WriteLine("Disconnecting from legacy device");
}

// Адаптер для совместимости
public class LegacyDeviceAdapter : IUsbDevice
{
    private readonly LegacyDevice _device;

    public LegacyDeviceAdapter(LegacyDevice device)
    {
        _device = device;
    }

    public void Connect() => _device.LegacyConnect();
    public void Disconnect() => _device.LegacyDisconnect();
    public void SendData() => _device.LegacySendData();
}

// Использование адаптера
public class Computer
{
    public void UseDevice(IUsbDevice device)
    {
        device.Connect();
        device.SendData();
        device.Disconnect();
    }
}

// Объяснение: В этом примере Adapter позволяет использовать устройство с устаревшим разъемом (LegacyDevice) через USB-порт, используя интерфейс IUsbDevice. Adapter преобразует методы LegacyDevice в методы IUsbDevice, делая устройство совместимым с компьютером.

