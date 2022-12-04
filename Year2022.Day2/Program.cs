namespace Year2022.Day2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code - Year 2022 - Day 2");

        #region Part 1 - Example
        {
            Console.WriteLine("Part 1 - Example");

            var exampleInput = File.ReadAllLines("example.txt");

            int totalScore = 0;

            foreach (var line in exampleInput)
            {
                var lineArray = line.Split(' ');

                totalScore += EvaluateRound(char.Parse(lineArray[0]), char.Parse(lineArray[1]));
            }

            Console.WriteLine($"Total Score is {totalScore}");
        }
        #endregion

        #region Part 1
        {
            Console.WriteLine("Part 1");

            var exampleInput = File.ReadAllLines("input.txt");

            int totalScore = 0;

            foreach (var line in exampleInput)
            {
                var lineArray = line.Split(' ');

                totalScore += EvaluateRound(char.Parse(lineArray[0]), char.Parse(lineArray[1]));
            }

            Console.WriteLine($"Total Score is {totalScore}");
        }
        #endregion

        #region Part 2
        {
            Console.WriteLine("Part 2");

            var exampleInput = File.ReadAllLines("input.txt");

            int totalScore = 0;

            foreach (var line in exampleInput)
            {
                var lineArray = line.Split(' ');

                var yourShape = EvaluateUsersShape(char.Parse(lineArray[0]), char.Parse(lineArray[1]));

                totalScore += EvaluateRound(char.Parse(lineArray[0]), yourShape);
            }

            Console.WriteLine($"Total Score is {totalScore}");

        }
        #endregion

    }

    static int EvaluateRound(char opponentsShape, char yourShape)
    {
        // evaluate the score for your selection
        int scoreForYourSelection = yourShape switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new Exception("Failure in EvaluateRound(); unexpected char.")
        };

        // evaluate score for the outcome
        int scoreForOutcome = 0;

        // draw
        if (
            (opponentsShape == 'A' && yourShape == 'X') ||
            (opponentsShape == 'B' && yourShape == 'Y') ||
            (opponentsShape == 'C' && yourShape == 'Z'))
        {
            scoreForOutcome = 3;
        }
        // win
        else if (
            (opponentsShape == 'A' && yourShape == 'Y') ||
            (opponentsShape == 'B' && yourShape == 'Z') ||
            (opponentsShape == 'C' && yourShape == 'X'))
        {
            scoreForOutcome = 6;
        }
        // lose
        else if (
            (opponentsShape == 'A' && yourShape == 'Z') ||
            (opponentsShape == 'B' && yourShape == 'X') ||
            (opponentsShape == 'C' && yourShape == 'Y'))
        {
            scoreForOutcome = 0;
        }

        return (scoreForYourSelection + scoreForOutcome);
    }

    static char EvaluateUsersShape(char opponentsShape, char outcome)
    {
        // lose
        if (opponentsShape == 'A' && outcome == 'X') { return 'Z'; }
        if (opponentsShape == 'B' && outcome == 'X') { return 'X'; }
        if (opponentsShape == 'C' && outcome == 'X') { return 'Y'; }
        // draw
        if (opponentsShape == 'A' && outcome == 'Y') { return 'X'; }
        if (opponentsShape == 'B' && outcome == 'Y') { return 'Y'; }
        if (opponentsShape == 'C' && outcome == 'Y') { return 'Z'; }
        // win
        if (opponentsShape == 'A' && outcome == 'Z') { return 'Y'; }
        if (opponentsShape == 'B' && outcome == 'Z') { return 'Z'; }
        if (opponentsShape == 'C' && outcome == 'Z') { return 'X'; }
        else
            throw new Exception($"Something went wrong. Opponent's shape: '{opponentsShape}'. Outcome: '{outcome}' ");
    }
}