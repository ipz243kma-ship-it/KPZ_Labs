namespace KPZ_lab4.Observer;

class LightTextNode : LightNode
{
    private string text;

    public LightTextNode(string text)
    {
        this.text = text;
    }

    public override string OuterHTML()
    {
        return text;
    }

    public override string InnerHTML()
    {
        return text;
    }
}