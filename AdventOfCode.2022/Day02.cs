public static class Day02
{
    public static string PartOne()
    {
        var input = File.ReadLines("day02_input");

        int score = 0;

        foreach (var line in input)
        {
            var outcome = ComputeOutcome(line[0], line[2]);
            score += ComputeOutComeScore(outcome);
            score += ComputeShapeScore(line[2]);
        }

        return score.ToString();
    }
    
    public static string PartTwo()
    {
        var input = File.ReadLines("day02_input");

        int score = 0;

        foreach (var line in input)
        {   
            var expectedOutcome = ParseOutcome(line[2]);
            var choice = ComputeChoice(line[0], expectedOutcome);
            score += ComputeOutComeScore(expectedOutcome);
            score += ComputeShapeScore(choice);
        }

        return score.ToString();
    }


    static int ComputeShapeScore(char shape) 
        => shape switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };

    static int ComputeOutComeScore(Outcome outcome)
        => outcome switch
        {
            Outcome.Won => 6,
            Outcome.Draw => 3,
            Outcome.Lost => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(outcome), outcome, null)
        };

    static Outcome ComputeOutcome(char opponentShape, char selectedShape)
        => selectedShape switch
        {
            'X' => opponentShape switch // ROCK
            {
                'A' => Outcome.Draw, // ROCK
                'B' => Outcome.Lost, // PAPER
                'C' => Outcome.Won, // SCISSOR
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            'Y' => opponentShape switch // PAPER
            {
                'A' => Outcome.Won, // ROCK
                'B' => Outcome.Draw, // PAPER
                'C' => Outcome.Lost, // SCISSOR
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            'Z' => opponentShape switch // SCISSOR
            {
                'A' => Outcome.Lost, // ROCK
                'B' => Outcome.Won, // PAPER
                'C' => Outcome.Draw, // SCISSOR
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(selectedShape), selectedShape, null)
        };

    static Outcome ParseOutcome(char fileOutcome)
        => fileOutcome switch
        {
            'X' => Outcome.Lost,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Won,
            _ => throw new ArgumentOutOfRangeException(nameof(fileOutcome), fileOutcome, null)
        };

    static char ComputeChoice(char opponentShape, Outcome expectedOutcome)
        => expectedOutcome switch
        {
            Outcome.Won => opponentShape switch
            {
                'A' => 'Y', // ROCK beaten by PAPER
                'B' => 'Z', // PAPER beaten by SCISSOR
                'C' => 'X', // SCISSOR beaten by ROCK
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            Outcome.Draw => opponentShape switch
            {
                'A' => 'X', // ROCK
                'B' => 'Y', // PAPER
                'C' => 'Z', // SCISSOR
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            Outcome.Lost => opponentShape switch
            {
                'A' => 'Z', // ROCK win over SCISSOR
                'B' => 'X', // PAPER win over ROCK
                'C' => 'Y', // SCISSOR win over PAPER
                _ => throw new ArgumentOutOfRangeException(nameof(opponentShape), opponentShape, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(expectedOutcome), expectedOutcome, null)
        };

    enum Outcome
    {
        Won,
        Draw,
        Lost
    };
}