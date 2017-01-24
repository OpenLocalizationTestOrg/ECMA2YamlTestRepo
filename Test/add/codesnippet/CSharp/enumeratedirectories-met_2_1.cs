DirectoryInfo dirPrograms = new DirectoryInfo(@"c:\program files");
DateTime StartOf2009 = new DateTime(2009, 01, 01);

var dirs = from dir in dirPrograms.EnumerateDirectories()
            where dir.CreationTimeUtc < StartOf2009
            select new
            {
                ProgDir = dir,
            };

foreach (var di in dirs)
{
    Console.WriteLine("{0}", di.ProgDir.Name);
}