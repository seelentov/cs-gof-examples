// 16. Iterator

// • Назначение: Предоставляет способ последовательного доступа к элементам агрегата, не раскрывая его внутреннего представления.
// • Пример из реального мира: Представьте, что вы работаете над приложением для просмотра фотографий. Вам нужно иметь возможность просматривать фотографии в альбоме по одной.
// • Пример кода:

// Интерфейс итератора
public interface IIterator
{
    object First();
    object Next();
    bool IsDone { get; }
    object CurrentItem { get; }
}

// Конкретный итератор
public class PhotoIterator : IIterator
{
    private readonly PhotoAlbum _album;
    private int _current = 0;

    public PhotoIterator(PhotoAlbum album)
    {
        _album = album;
    }

    public object First() => _album.Photos[_current];

    public object Next()
    {
        if (_current < _album.Photos.Count - 1)
        {
            _current++;
            return _album.Photos[_current];
        }
        else
        {
            return null;
        }
    }

    public bool IsDone => _current >= _album.Photos.Count;

    public object CurrentItem => _album.Photos[_current];
}

// Агрегат (Фотоальбом)
public class PhotoAlbum
{
    public List<string> Photos { get; } = new();

    public IIterator CreateIterator() => new PhotoIterator(this);
}

// Использование Iterator
public class PhotoViewer
{
    public void ViewPhotos(PhotoAlbum album)
    {
        var iterator = album.CreateIterator();
        while (!iterator.IsDone)
        {
            Console.WriteLine($"Фото: {iterator.CurrentItem}");
            iterator.Next();
        }
    }
}

// Объяснение: В этом примере Iterator позволяет нам просматривать фотографии в альбоме по одной, не зная о том, как хранятся фотографии в альбомe