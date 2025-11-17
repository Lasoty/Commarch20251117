namespace ComarchCwiczenia.Model;

public class FileLogger(string filePath)
{
    public void Log(string message)
    {
        File.AppendAllText(filePath, message + Environment.NewLine);
    }
}
