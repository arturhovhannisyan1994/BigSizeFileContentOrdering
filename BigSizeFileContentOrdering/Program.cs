// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


using var fileGenerator = new HugeFileGenerator();
await fileGenerator.Generate("huge.txt");

var spliter = new FileSplitter("huge.txt");
var files = spliter.Split();

SortAndMerge(fileGenerator, files);

static void SortAndMerge(HugeFileGenerator fileGenerator, IEnumerable<string> files)
{
    var streams = files.Select(x => new StreamReader(x)).ToArray();


    try
    {
        var values = streams.Where(x => !x.EndOfStream).Select(x => x.ReadLine()).ToList();
        while (values.Count > 0)
        {


            var value = values.OrderBy(x => x).First();
            fileGenerator.WriteSortedValue("sorted.txt", value);
            values.Remove(value);
            var sm = streams.Where(x => !x.EndOfStream).OrderByDescending(x => x.BaseStream.Position).FirstOrDefault();
            if (sm != null)
            {
                values.Add(sm.ReadLine());
            }





        }
    }
    finally
    {
        foreach (var stream in streams)
            stream.Dispose();
    }
}

