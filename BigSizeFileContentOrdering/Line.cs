// See https://aka.ms/new-console-template for more information




using System.Text;

public class Line
{
    public static int minCharacterSize = 80;

    public static int maxCharacterSize = 120;

    private static Random _random = new Random();


    public static string Get()
    {
        int length = _random.Next(_random.Next(minCharacterSize, maxCharacterSize));
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append((char)_random.Next('A', 'Z'));
        }
        return stringBuilder.ToString();
    }
}