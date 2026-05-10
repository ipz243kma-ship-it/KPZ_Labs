using System;
using System.Collections;
using System.Collections.Generic;

public abstract class LightNode
{
    public abstract string OuterHTML();
    public abstract string InnerHTML();
}

public interface INodeState
{
    string GetStateName();
}

public class CreatedState : INodeState
{
    public string GetStateName() => "Created";
}

public class InsertedState : INodeState
{
    public string GetStateName() => "Inserted";
}

public class RemovedState : INodeState
{
    public string GetStateName() => "Removed";
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

    private INodeState _state;

    private List<string> _classes = new List<string>();
    private List<LightNode> _children = new List<LightNode>();

    public LightElementNode(string tagName, bool isBlock, bool selfClosing)
    {
        _tagName = tagName;
        _isBlock = isBlock;
        _selfClosing = selfClosing;

        _state = new CreatedState();
    }

    public void SetState(INodeState state)
    {
        _state = state;
    }

    public string GetState()
    {
        return _state.GetStateName();
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

        if (node is LightElementNode element)
        {
            element.SetState(new InsertedState());
        }
    }

    public void RemoveChild(LightNode node)
    {
        _children.Remove(node);

        if (node is LightElementNode element)
        {
            element.SetState(new RemovedState());
        }
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
}

class Program
{
    static void Main()
    {
        var div = new LightElementNode("div", true, false);

        var p = new LightElementNode("p", true, false);

        Console.WriteLine("Initial state:");
        Console.WriteLine(p.GetState());

        div.AddChild(p);

        Console.WriteLine("\nAfter insert:");
        Console.WriteLine(p.GetState());

        div.RemoveChild(p);

        Console.WriteLine("\nAfter remove:");
        Console.WriteLine(p.GetState());
    }
}