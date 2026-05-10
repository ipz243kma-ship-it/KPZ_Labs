using System;
using System.Collections.Generic;

public abstract class LightNode
{
    public abstract string OuterHTML();
    public abstract string InnerHTML();
}

public class LightTextNode : LightNode
{
    private string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML() => _text;
    public override string InnerHTML() => _text;
}

public class LightElementNode : LightNode
{
    private string _tagName;
    private bool _isBlock;
    private bool _selfClosing;
    private List<string> _classes = new List<string>();
    private List<LightNode> _children = new List<LightNode>();

    public LightElementNode(string tagName, bool isBlock, bool selfClosing)
    {
        _tagName = tagName;
        _isBlock = isBlock;
        _selfClosing = selfClosing;
    }

    public void AddClass(string className)
    {
        _classes.Add(className);
    }

    public void AddChild(LightNode node)
    {
        _children.Add(node);
    }

    public override string InnerHTML()
    {
        string result = "";
        foreach (var child in _children)
        {
            result += child.OuterHTML();
        }
        return result;
    }

    public override string OuterHTML()
    {
        string classAttr = _classes.Count > 0 ? $" class=\"{string.Join(" ", _classes)}\"" : "";

        if (_selfClosing)
        {
            return $"<{_tagName}{classAttr}/>";
        }

        return $"<{_tagName}{classAttr}>{InnerHTML()}</{_tagName}>";
    }
}

class Program
{
    static void Main()
    {
        var div = new LightElementNode("div", true, false);
        div.AddClass("container");

        var h1 = new LightElementNode("h1", true, false);
        h1.AddChild(new LightTextNode("Hello World"));

        var p = new LightElementNode("p", true, false);
        p.AddChild(new LightTextNode("This is paragraph"));

        div.AddChild(h1);
        div.AddChild(p);

        Console.WriteLine(div.OuterHTML());
    }
}