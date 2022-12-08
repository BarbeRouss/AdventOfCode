public static class Day5
{
    public static string PartOne()
    {
        var input = File.ReadLines("day05_input");

        var stackDefinition = new Stack<string>();
        foreach (var line in input.TakeWhile(s => s != string.Empty))
        {
            stackDefinition.Push(line);
        }
        var stacks = ReadStacks(stackDefinition);

        foreach (var line in input.SkipWhile(s => s != string.Empty))
        {
            if(line == string.Empty)
                continue;

            string[] moveDefinition = line.Split(' ');

            int count = int.Parse(moveDefinition[1]);
            int fromIndex = int.Parse(moveDefinition[3])-1;
            int toIndex = int.Parse(moveDefinition[5])-1;

            for(int i = 0; i<count; i++)
            {
                stacks[toIndex].Push(stacks[fromIndex].Pop());
            }
        }

        return new string(stacks.Select(s => s.Pop()).ToArray());
    }

    public static string PartTwo()
    {
        var input = File.ReadLines("day05_input");

        var stackDefinition = new Stack<string>();
        foreach (var line in input.TakeWhile(s => s != string.Empty))
        {
            stackDefinition.Push(line);
        }
        var stacks = ReadStacks(stackDefinition);

        foreach (var line in input.SkipWhile(s => s != string.Empty))
        {
            if(line == string.Empty)
                continue;

            string[] moveDefinition = line.Split(' ');

            int count = int.Parse(moveDefinition[1]);
            int fromIndex = int.Parse(moveDefinition[3])-1;
            int toIndex = int.Parse(moveDefinition[5])-1;

            Stack<char> tmpStack = new Stack<char>();
            for(int i = 0; i<count; i++)
                tmpStack.Push(stacks[fromIndex].Pop());
            while(tmpStack.Any())
                stacks[toIndex].Push(tmpStack.Pop());
        }

        return new string(stacks.Select(s => s.Pop()).ToArray());
    }

    private static Stack<char>[] ReadStacks(Stack<string> stackDefinitions)
    {
        int stackCount = stackDefinitions
            .Pop()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(i => int.Parse(i))
            .Max();

        var result = Enumerable.Repeat(0, stackCount).Select(zero => new Stack<char>()).ToArray();

        while(stackDefinitions.Any())
        {
            string rowDefinition = stackDefinitions.Pop();

            for(int i = 0; i< stackCount; i++)
            {
                char c = rowDefinition[i*4+1];
                if(char.IsAsciiLetter(c))
                    result[i].Push(c);
            }
        }

        return result;
    }
}