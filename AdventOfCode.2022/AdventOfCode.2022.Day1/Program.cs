
var input = File.ReadLines("input");

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

var topElfCalories = elfs.Max(e => e.TotalCalories);
var top3ElfTotalCalories = elfs.OrderByDescending(e => e.TotalCalories).Take(3).Sum(e => e.TotalCalories);

Console.WriteLine($@"Top 1: {topElfCalories}");
Console.WriteLine($@"Top 3: {top3ElfTotalCalories}");
