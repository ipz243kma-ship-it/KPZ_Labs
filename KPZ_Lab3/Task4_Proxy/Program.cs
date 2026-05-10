using System;
using System.IO;
using System.Text.RegularExpressions;

public interface ITextReader
{
    char[][] Read(string path);
}

public class SmartTextReader : ITextReader
{
    public char[][] Read(string path)
    {
        var lines = File.ReadAllLines(path);
        char[][] result = new char[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].ToCharArray();
        }

        return result;
    }
}

public class SmartTextChecker : ITextReader
{
    private SmartTextReader _reader = new SmartTextReader();

    public char[][] Read(string path)
    {
        Console.WriteLine("Opening file...");
        
        var data = _reader.Read(path);

        Console.WriteLine("Reading file...");

        int lines = data.Length;
        int chars = 0;

        foreach (var line in data)
        {
            chars += line.Length;
        }

        Console.WriteLine($"Lines: {lines}, Chars: {chars}");
        Console.WriteLine("Closing file...");

        return data;
    }
}

public class SmartTextReaderLocker : ITextReader
{
    private SmartTextReader _reader = new SmartTextReader();
    private Regex _regex;

    public SmartTextReaderLocker(string pattern)
    {
        _regex = new Regex(pattern);
    }

    public char[][] Read(string path)
    {
        if (_regex.IsMatch(path))
        {
            Console.WriteLine("Access denied!");
            return Array.Empty<char[]>();
        }

        return _reader.Read(path);
    }
}

class Program
{
    static void Main()
    {
        string path = "test.txt";

        ITextReader checker = new SmartTextChecker();
        checker.Read(path);

        Console.WriteLine();

        ITextReader locker = new SmartTextReaderLocker("secret");

        locker.Read("secret_file.txt");
        locker.Read("test.txt");
    }
}