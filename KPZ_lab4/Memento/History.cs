namespace KPZ_lab4.Memento;

class History
{
    private Stack<TextEditorMemento> history = new();

    public void Save(TextEditorMemento memento)
    {
        history.Push(memento);
    }

    public TextEditorMemento? Undo()
    {
        if (history.Count == 0)
        {
            return null;
        }

        return history.Pop();
    }
}