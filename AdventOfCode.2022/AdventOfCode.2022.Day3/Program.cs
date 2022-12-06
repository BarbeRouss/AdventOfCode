
var input = File.ReadLines("input");
var priorities = 0;

foreach (var line in input)
{
    string compartment1 = line.Substring(0, line.Length / 2);
    string compartment2 = line.Substring(line.Length / 2, line.Length / 2);

    var commonItem = compartment1.Intersect(compartment2).Single();

    if (char.IsUpper(commonItem))
        priorities += commonItem - 38; // 'A' = 65, 'B' = 66. Remove 38 to get the expected priority
    else
        priorities += commonItem - 96; // 'a' = 97, 'b' = 98. Remove 96 to get the expected priority
}

Console.WriteLine($"Priorities: {priorities}");
