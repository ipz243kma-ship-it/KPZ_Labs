namespace KPZ_lab4.Observer;

class LightElementNode : LightNode
{
    private string tagName;
    private bool isBlock;
    private bool selfClosing;

    private List<string> classes = new();
    private List<LightNode> children = new();

    private Dictionary<string, List<EventListener>> eventListeners = new();

    public LightElementNode(string tagName, bool isBlock, bool selfClosing)
    {
        this.tagName = tagName;
        this.isBlock = isBlock;
        this.selfClosing = selfClosing;
    }

    public void AddClass(string className)
    {
        classes.Add(className);
    }

    public void AddChild(LightNode node)
    {
        children.Add(node);
    }

    public void AddEventListener(string eventType, Action handler)
    {
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<EventListener>();
        }

        eventListeners[eventType].Add(new EventListener(handler));
    }

    public void TriggerEvent(string eventType)
    {
        if (!eventListeners.ContainsKey(eventType))
        {
            Console.WriteLine($"No listeners for event: {eventType}");
            return;
        }

        foreach (var listener in eventListeners[eventType])
        {
            listener.Execute();
        }
    }

    public override string InnerHTML()
    {
        string result = "";

        foreach (var child in children)
        {
            result += child.OuterHTML();
        }

        return result;
    }

    public override string OuterHTML()
    {
        string classAttr = classes.Count > 0
            ? $" class=\"{string.Join(" ", classes)}\""
            : "";

        if (selfClosing)
        {
            return $"<{tagName}{classAttr}/>";
        }

        return $"<{tagName}{classAttr}>{InnerHTML()}</{tagName}>";
    }
}