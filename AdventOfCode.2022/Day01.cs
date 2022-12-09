public static class Day01
{
    public static string PartOne()
    {
        var input = File.ReadLines("day01_input");

        List<Elf> elfs = new List<Elf>();
        Elf currentElf = new Elf();
        elfs.Add(currentElf);

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                currentElf = new Elf();
                elfs.Add(currentElf);
            }
            else
            {
                var calories = int.Parse(line);
                currentElf.TotalCalories += calories;
            }
        }

        return elfs.Max(e => e.TotalCalories).ToString();
    }
    
    public static string PartTwo()
    {
        var input = File.ReadLines("day01_input");

        List<Elf> elfs = new List<Elf>();
        Elf currentElf = new Elf();
        elfs.Add(currentElf);

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                currentElf = new Elf();
                elfs.Add(currentElf);
            }
            else
            {
                var calories = int.Parse(line);
                currentElf.TotalCalories += calories;
            }
        }

        return elfs.OrderByDescending(e => e.TotalCalories).Take(3).Sum(e => e.TotalCalories).ToString();
    }

    private class Elf
    {
        public int TotalCalories { get; set; }
    }
}