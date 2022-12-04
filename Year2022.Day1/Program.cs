namespace Year2022.Day1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code - Year 2022 - Day 1");

        #region Part 1 - Example
        {
            Console.WriteLine("Part 1 - Example");

            var exampleInput = File.ReadAllLines("example.txt");

            int maximumTotalCalories = 0;
            int currentTotalCalories = 0;
            int positionOfElf = 1;
            int positionOfElfWithMaximumTotal = 0;

            foreach (var line in exampleInput)
            {
                if (line == String.Empty)
                {
                    if (currentTotalCalories > maximumTotalCalories)
                    {
                        maximumTotalCalories = currentTotalCalories;
                        positionOfElfWithMaximumTotal = positionOfElf;
                    }

                    positionOfElf++;

                    currentTotalCalories = 0;

                    continue;
                }
                else
                {
                    currentTotalCalories += int.Parse(line);
                }
            }

            // need to do the comparison for the final elf
            if (currentTotalCalories > maximumTotalCalories)
            {
                maximumTotalCalories = currentTotalCalories;
                positionOfElfWithMaximumTotal = positionOfElf;
            }

            Console.WriteLine($"{positionOfElfWithMaximumTotal}-th elf is carrying the most calories({maximumTotalCalories})");
        }
        #endregion

        #region Part 1
        {
            Console.WriteLine("Part 1");

            var exampleInput = File.ReadAllLines("input.txt");

            int maximumTotalCalories = 0;
            int currentTotalCalories = 0;
            int positionOfElf = 1;
            int positionOfElfWithMaximumTotal = 0;

            foreach (var line in exampleInput)
            {
                if (line == String.Empty)
                {
                    if (currentTotalCalories > maximumTotalCalories)
                    {
                        maximumTotalCalories = currentTotalCalories;
                        positionOfElfWithMaximumTotal = positionOfElf;
                    }

                    positionOfElf++;

                    currentTotalCalories = 0;

                    continue;
                }
                else
                {
                    currentTotalCalories += int.Parse(line);
                }
            }

            // need to do the comparison for the final elf
            if (currentTotalCalories > maximumTotalCalories)
            {
                maximumTotalCalories = currentTotalCalories;
                positionOfElfWithMaximumTotal = positionOfElf;
            }

            Console.WriteLine($"{positionOfElfWithMaximumTotal}-th elf is carrying the most calories({maximumTotalCalories})");
        }

        #endregion

        #region Part 2
        {
            Console.WriteLine("Part 2");

            var exampleInput = File.ReadAllLines("input.txt");

            int currentTotalCalories = 0;
            int positionOfElf = 1;
            
            // better to use a dictionary and then sort by values
            Dictionary<int, int> totalCaloriesCarried = new Dictionary<int, int>();

            foreach (var line in exampleInput)
            {
                if (line == String.Empty)
                {
                    totalCaloriesCarried.Add(positionOfElf, currentTotalCalories);
                    
                    positionOfElf++;

                    currentTotalCalories = 0;

                    continue;
                }
                else
                {
                    currentTotalCalories += int.Parse(line);
                }
            }

            // need to do the comparison for the final elf
            totalCaloriesCarried.Add(positionOfElf, currentTotalCalories);

            var totalCaloriesCarriedByTop3FattyElfs = totalCaloriesCarried
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Sum(x => x.Value);

            Console.WriteLine($"The top 3 elfs are carrying {totalCaloriesCarriedByTop3FattyElfs} calories in total.");
        }

        #endregion
    }
}