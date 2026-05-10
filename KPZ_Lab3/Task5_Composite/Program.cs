using System;
using System.Collections;
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

    public void RemoveClass(string className)
    {
        _classes.Remove(className);
    }

    public void AddChild(LightNode node)
    {
        _children.Add(node);
    }

    public void RemoveChild(LightNode node)
    {
        _children.Remove(node);
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

    public IEnumerator<LightNode> GetEnumerator()
    {
        return _children.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
<<<<<<< HEAD
}

public interface ICommand
{
    void Execute();
    void Undo();
}

public class AddChildCommand : ICommand
{
    private LightElementNode _parent;
    private LightNode _child;

    public AddChildCommand(LightElementNode parent, LightNode child)
    {
        _parent = parent;
        _child = child;
    }

    public void Execute()
    {
        _parent.AddChild(_child);
    }

    public void Undo()
    {
        _parent.RemoveChild(_child);
    }
}

public class AddClassCommand : ICommand
{
    private LightElementNode _element;
    private string _className;

    public AddClassCommand(LightElementNode element, string className)
    {
        _element = element;
        _className = className;
    }

    public void Execute()
    {
        _element.AddClass(_className);
    }

    public void Undo()
    {
        _element.RemoveClass(_className);
    }
=======
>>>>>>> main
}

class Program
{
    static void Main()
    {
        var div = new LightElementNode("div", true, false);
        var h1 = new LightElementNode("h1", true, false);
        var p = new LightElementNode("p", true, false);

        h1.AddChild(new LightTextNode("Hello World"));
        p.AddChild(new LightTextNode("This is paragraph"));

        ICommand addContainerClass = new AddClassCommand(div, "container");
        ICommand addHeader = new AddChildCommand(div, h1);
        ICommand addParagraph = new AddChildCommand(div, p);

        addContainerClass.Execute();
        addHeader.Execute();
        addParagraph.Execute();

        Console.WriteLine("After commands:");
        Console.WriteLine(div.OuterHTML());

<<<<<<< HEAD
        addParagraph.Undo();

        Console.WriteLine("\nAfter undo paragraph:");
        Console.WriteLine(div.OuterHTML());

        Console.WriteLine("\nIterator work:");
=======
        Console.WriteLine("\nIterator work:");

>>>>>>> main
        foreach (var node in div)
        {
            Console.WriteLine(node.OuterHTML());
        }
    }
}