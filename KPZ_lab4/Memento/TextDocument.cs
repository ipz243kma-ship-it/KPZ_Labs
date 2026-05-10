namespace KPZ_lab4.Memento;

class TextDocument
{
    public string Content { get; private set; }

    public TextDocument(string content)
    {
        Content = content;
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}