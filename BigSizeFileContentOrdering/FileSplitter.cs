// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

public class FileSplitter
{
    private readonly string _filePath;
    private readonly int _partsCount;

    public FileSplitter(string filePath)
    {
        _filePath = filePath;
        //._partsCount = partsCount;
    }


    public IEnumerable<string> Split()
    {
        var files = new List<string>();
        var sw = Stopwatch.StartNew();
        int maxLines = 100_000;
        IList<string> list = new List<string>(maxLines);
        using var streamReader = new StreamReader(_filePath);
        int l = 0;
        int p = 1;
        while (!streamReader.EndOfStream)
        {
            using var streamWriter = new StreamWriter($"splitted{p}.txt");
            while (l < maxLines)

            {

                list.Add(streamReader.ReadLine());
                l++;
            }

            foreach (var line in list.OrderBy(x => x)) 
            {
                streamWriter.WriteLine(line);
            }

            files.Add($"splitted{p}.txt");
            list.Clear();

            p++;
            l = 0;


        }
        Console.WriteLine($"Split takes : {sw.Elapsed}");
        return files;

    }

}
