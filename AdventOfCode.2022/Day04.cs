public static class Day4
{
    public static string PartOne()
    {
        var input = File.ReadLines("input_day4");
        int fullyContainsCount = 0;

        foreach (var line in input)
        {
            var assignments = line.Split(new char[] { ',', '-'})
                                    .Select(a => int.Parse(a))
                                    .ToArray();

            if(assignments[0] <= assignments[2] && assignments[1] >= assignments[3])
                fullyContainsCount++;
            else if(assignments[0] >= assignments[2] && assignments[1] <= assignments[3])
                fullyContainsCount++;
        }

        return fullyContainsCount.ToString();
    }

    public static string PartTwo()
    {
        var input = File.ReadLines("input_day4");
        int count = 0;

        foreach (var line in input)
        {
            var assignments = line.Split(new char[] { ',', '-'})
                                    .Select(a => int.Parse(a))
                                    .ToArray();

            // Check for each stop to be included in the other array
            if(IsInRange(assignments[2], assignments[3], assignments[0])
                || IsInRange(assignments[2], assignments[3], assignments[1])
                || IsInRange(assignments[0], assignments[1], assignments[2])
                || IsInRange(assignments[0], assignments[1], assignments[3]))
                count++;
        }

        return count.ToString();
    }

    private static bool IsInRange(int rangeStart, int rangeEnd, int value)
        => rangeStart <= value && value <= rangeEnd;
}