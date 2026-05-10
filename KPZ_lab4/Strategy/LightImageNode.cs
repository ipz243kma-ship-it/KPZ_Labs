namespace KPZ_lab4.Strategy;

class LightImageNode
{
    private string href;
    private ImageLoadingStrategy strategy;

    public LightImageNode(string href)
    {
        this.href = href;

        if (href.StartsWith("http"))
        {
            strategy = new NetworkImageLoadingStrategy();
        }
        else
        {
            strategy = new FileImageLoadingStrategy();
        }
    }

    public void Render()
    {
        Console.WriteLine(strategy.Load(href));
    }
}