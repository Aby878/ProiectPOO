namespace Proiect.Classes;

public class ConsoleWrapper
{
    public virtual void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    
    public virtual string ReadLine(string message = "")
    {
        if (!string.IsNullOrEmpty(message))
        {
            WriteLine(message);
        }
        return Console.ReadLine()?.Trim();
    }
    
    public virtual int ReadInt(string message)
    {
        while (true)
        {
            WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            WriteLine("Input-ul nu este un numar valid! Incercati din nou.");
        }
    }
    
    public virtual void WriteList<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            WriteLine(item?.ToString());
        }
    }
}