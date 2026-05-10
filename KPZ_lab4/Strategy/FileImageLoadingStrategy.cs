namespace KPZ_lab4.Strategy;

class FileImageLoadingStrategy : ImageLoadingStrategy
{
    public string Load(string href)
    {
        return $"Loading image from file system: {href}";
    }
}