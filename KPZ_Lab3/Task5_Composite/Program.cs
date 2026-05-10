using System;
using System.Collections;
using System.Collections.Generic;

public interface IVisitor
{
    void VisitElementNode(LightElementNode element);
    void VisitTextNode(LightTextNode textNode);
}

public abstract class LightNode
{
    public abstract string OuterHTML();
    public abstract string InnerHTML();

    public abstract void Accept(IVisitor visitor);
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

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitTextNode(this);
    }
}

public class LightElementNode : LightNode, IEnumerable<LightNode>
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
        string classAttr =
            _classes.Count > 0
            ? $" class=\"{string.Join(" ", _classes)}\""
            : "";

        if (_selfClosing)
        {
            return $"<{_tagName}{classAttr}/>";
        }

        return $"<{_tagName}{classAttr}>{InnerHTML()}</{_tagName}>";
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitElementNode(this);

        foreach (var child in _children)
        {
            child.Accept(visitor);
        }
    }

    public IEnumerator<LightNode> GetEnumerator()
    {
        return _children.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class NodeCountVisitor : IVisitor
{
    public int ElementCount { get; private set; }
    public int TextNodeCount { get; private set; }

    public void VisitElementNode(LightElementNode element)
    {
        ElementCount++;
    }

    public void VisitTextNode(LightTextNode textNode)
    {
        TextNodeCount++;
    }
}

class Program
{
    static void Main()
    {
        var div = new LightElementNode("div", true, false);

        var h1 = new LightElementNode("h1", true, false);
        h1.AddChild(new LightTextNode("Hello World"));

        var p = new LightElementNode("p", true, false);
        p.AddChild(new LightTextNode("This is paragraph"));

        div.AddChild(h1);
        div.AddChild(p);

        var visitor = new NodeCountVisitor();

        div.Accept(visitor);

        Console.WriteLine("HTML:");
        Console.WriteLine(div.OuterHTML());

        Console.WriteLine("\nVisitor results:");
        Console.WriteLine($"Element nodes: {visitor.ElementCount}");
        Console.WriteLine($"Text nodes: {visitor.TextNodeCount}");
    }
}