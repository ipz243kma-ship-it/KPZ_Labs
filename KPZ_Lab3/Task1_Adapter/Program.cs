using System;
using System.IO;

public interface ILogger
{
    void Log(string message);
    void Error(string message);
    void Warn(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[LOG] " + message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[ERROR] " + message);
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[WARN] " + message);
        Console.ResetColor();
    }
}

public class FileWriter
{
    private readonly string _path;

    public FileWriter(string path)
    {
        _path = path;
    }

    public void Write(string message)
    {
        File.WriteAllText(_path, message);
    }

    public void WriteLine(string message)
    {
        File.AppendAllText(_path, message + Environment.NewLine);
    }
}

public class FileLoggerAdapter : ILogger
{
    private readonly FileWriter _fileWriter;

    public FileLoggerAdapter(string path)
    {
        _fileWriter = new FileWriter(path);
    }

    public void Log(string message)
    {
        _fileWriter.WriteLine("[LOG] " + message);
    }

    public void Error(string message)
    {
        _fileWriter.WriteLine("[ERROR] " + message);
    }

    public void Warn(string message)
    {
        _fileWriter.WriteLine("[WARN] " + message);
    }
}

class Program
{
    static void Main()
    {
        ILogger consoleLogger = new Logger();

        consoleLogger.Log("Звичайне повідомлення");
        consoleLogger.Warn("Попередження");
        consoleLogger.Error("Помилка");

        ILogger fileLogger = new FileLoggerAdapter("log.txt");

        fileLogger.Log("Повідомлення у файл");
        fileLogger.Warn("Попередження у файл");
        fileLogger.Error("Помилка у файл");

        Console.WriteLine("Файловий лог записано у log.txt");
    }
}