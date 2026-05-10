using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class ElementStyle //не створювати зайві однакові дані для кожного HTML-елемента
{
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool SelfClosing { get; }

    public ElementStyle(string tagName, bool isBlock, bool selfClosing) // Якщо у книзі 1000 абзаців <p>, не треба 1000 разів зберігати
    {
        TagName = tagName;
        IsBlock = isBlock;
        SelfClosing = selfClosing;
    }
}

public class ElementStyleFactory
{
    private readonly Dictionary<string, ElementStyle> _styles = new();

    public ElementStyle GetStyle(string tagName, bool isBlock, bool selfClosing)
    {
        string key = $"{tagName}_{isBlock}_{selfClosing}";

        if (!_styles.ContainsKey(key))
        {
            _styles[key] = new ElementStyle(tagName, isBlock, selfClosing); // Це словник, де зберігаються вже створені стилі h1 true false -> h1
        }

        return _styles[key];
    }

    public int Count => _styles.Count;
}

public abstract class LightNode
{
    public abstract string OuterHTML();
}

public class LightTextNode : LightNode
{
    private readonly string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML()
    {
        return _text;
    }
}

public class LightElementNode : LightNode
{
    private readonly ElementStyle _style;
    private readonly List<LightNode> _children = new();

    public LightElementNode(ElementStyle style)
    {
        _style = style;
    }

    public void AddChild(LightNode child)
    {
        _children.Add(child);
    }

    public override string OuterHTML()
    {
        if (_style.SelfClosing)
        {
            return $"<{_style.TagName}/>";
        }

        string inner = "";

        foreach (var child in _children)
        {
            inner += child.OuterHTML();
        }

        return $"<{_style.TagName}>{inner}</{_style.TagName}>";
    }
}

class Program
{
    static void Main()
    {
        string[] lines =
        {
            "My Book Title",
            "Chapter One",
            " This is a quote from the book.",
            "This is a normal paragraph with more than twenty characters.",
            "Short line",
            "Another normal paragraph for testing Flyweight pattern."
        };

        var factory = new ElementStyleFactory();
        var nodes = new List<LightNode>();

        long memoryBefore = GC.GetTotalMemory(true);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string tag;

            if (i == 0)
            {
                tag = "h1";
            }
            else if (line.Length < 20)
            {
                tag = "h2";
            }
            else if (char.IsWhiteSpace(line[0]))
            {
                tag = "blockquote";
            }
            else
            {
                tag = "p";
            }

            var style = factory.GetStyle(tag, true, false);
            var element = new LightElementNode(style);
            element.AddChild(new LightTextNode(line.Trim()));

            nodes.Add(element);
        }

        long memoryAfter = GC.GetTotalMemory(true);

        foreach (var node in nodes)
        {
            Console.WriteLine(node.OuterHTML());
        }

        Console.WriteLine();
        Console.WriteLine($"Memory used: {memoryAfter - memoryBefore} bytes");
        Console.WriteLine($"Unique flyweight styles created: {factory.Count}");
    }
}