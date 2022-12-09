public static class Day06
{
    public static string PartOne()
    {
        var input = File.ReadAllText("day06_input");

        for(int i = 3; i < input.Length; i++)
        {
            if(input.Skip(i-3).Take(4).Distinct().Count() == 4)
                return (i+1).ToString();
        }

        return "ERROR";
    }

    public static string PartTwo()
    {
        var input = File.ReadAllText("day06_input");

        for(int i = 13; i < input.Length; i++)
        {
            if(input.Skip(i-13).Take(14).Distinct().Count() == 14)
                return (i+1).ToString();
        }

        return "ERROR";
    }
}