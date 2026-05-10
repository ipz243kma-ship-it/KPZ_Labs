namespace KPZ_lab4.Memento;

class TextEditorMemento
{
    public string SavedContent { get; }

    public TextEditorMemento(string content)
    {
        SavedContent = content;
    }
}