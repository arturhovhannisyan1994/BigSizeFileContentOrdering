// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

public class HugeFileGenerator : IDisposable
{

    private StreamWriter _streamWriter;

    const int lines = 1_000_000;
    public async Task Generate(string path)
    {

        var sw = Stopwatch.StartNew();
        using var streamWriter = new StreamWriter(path);
        for (int i = 0; i < lines; i++)
        {
            await streamWriter.WriteLineAsync(Line.Get());

        }

        await Console.Out.WriteLineAsync($"Generate huge files takes : {sw.Elapsed}");


    }

    public void WriteSortedValue(string path, string value) 
    {
        if (_streamWriter is null)
            _streamWriter = new StreamWriter(path,false);

        _streamWriter.WriteLine(value);
    }

    public void Dispose() 
    {
        _streamWriter?.Dispose();
    }
}
