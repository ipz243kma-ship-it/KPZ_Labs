namespace KPZ_lab4.Strategy;

class NetworkImageLoadingStrategy : ImageLoadingStrategy
{
    public string Load(string href)
    {
        return $"Loading image from network: {href}";
    }
}