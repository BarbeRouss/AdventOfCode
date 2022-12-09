public static class Day03
{
    public static string PartOne()
    {
        var input = File.ReadLines("day03_input");
        var priorities = 0;

        foreach (var line in input)
        {
            string compartment1 = line.Substring(0, line.Length / 2);
            string compartment2 = line.Substring(line.Length / 2, line.Length / 2);

            var commonItem = compartment1.Intersect(compartment2).Single();
            priorities += ComputePriority(commonItem);
        }

        return priorities.ToString();
    }

    public static string PartTwo()
    {
        var input = File.ReadLines("day03_input");
        var priorities = 0;

        foreach (var line in input.Chunk(3))
        {
            var commonItem = line[0].Intersect(line[1]).Intersect(line[2]).Single();
            priorities += ComputePriority(commonItem);
        }

        return priorities.ToString();
    }

    private static int ComputePriority(char item)
    {
        if (char.IsUpper(item))
            return item - 38; // 'A' = 65, 'B' = 66. Remove 38 to get the expected priority
        else
            return item - 96; // 'a' = 97, 'b' = 98. Remove 96 to get the expected priority
    }
}