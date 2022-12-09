public static class Day07
{
    public static string PartOne()
    {
        var allDirectories = ParseInput().Walker();

        return allDirectories.Where(d => d.TotalSize <= 100000).Sum(d => d.TotalSize).ToString();
    }

    public static string PartTwo()
    {
        var rootDirectory = ParseInput();
        var spaceToFree = rootDirectory.TotalSize - 40000000;

        var toDelete = rootDirectory.Walker()
                        .Where(d => d.TotalSize > spaceToFree)
                        .OrderBy(d => d.TotalSize).First();

        return toDelete.TotalSize.ToString();
    }

    private static Directory ParseInput()
    {
        var input = File.ReadAllLines("day07_input");

        Directory currentDirectory = null;

        foreach(string line in input)
        {
            if(line.StartsWith("$ cd .."))
            {
                currentDirectory = currentDirectory.Root;
            }
            else if(line.StartsWith("$ cd "))
            {
                currentDirectory = new Directory(currentDirectory, line.Substring(5));
            }
            else if(char.IsDigit(line[0]))
            {
                // File detail
                currentDirectory.Size += int.Parse(line.Split(' ')[0]);
            }
        }

        var rootDirectory = currentDirectory;
        while(rootDirectory.Root != null) rootDirectory = rootDirectory.Root;

        return rootDirectory;
    }

    private class Directory
    {
        public Directory? Root { get; }
        public List<Directory> Childs {get;} = new List<Directory>();
        public string Name { get; }
        public int Size { get; set; }
        public int TotalSize 
        {
            get
            {
                return Size + Childs.Sum(c => c.TotalSize);
            }
        }

        public Directory(Directory root, string name)
        {
            Root = root;
            Root?.Childs.Add(this);

            Name = name;
        }

        public string ToString(int depth = 0)
        {
            return string.Join("", Enumerable.Repeat("  ", depth)) + Name + " (" + Size + ") (" + TotalSize + ")"
                    + Environment.NewLine
                    + string.Join(Environment.NewLine, Childs.Select(c => c.ToString(depth+1)));
        }

        public IEnumerable<Directory> Walker()
        {
            yield return this;

            foreach(var c in Childs.SelectMany(c => c.Walker()))
                yield return c;
        }
    }
}