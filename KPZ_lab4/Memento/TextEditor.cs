namespace KPZ_lab4.Memento;

class TextEditor
{
    private TextDocument document;

    public TextEditor(TextDocument document)
    {
        this.document = document;
    }

    public void Write(string text)
    {
        document.SetContent(text);
    }

    public void Show()
    {
        Console.WriteLine($"Current text: {document.Content}");
    }

    public TextEditorMemento Save()
    {
        return new TextEditorMemento(document.Content);
    }

    public void Restore(TextEditorMemento memento)
    {
        document.SetContent(memento.SavedContent);
    }
}