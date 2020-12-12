using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Year2020.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - Year 2020 - Day 6");


            #region Part 1

            Console.WriteLine("Part 1");

            // Dictionary to store bagging rules
            var baggingRules = new Dictionary<string, List<string>>();

            // have Hashset<string> of colors
            var setOfColors = new HashSet<string>();

            // process input
            ProcessInput(baggingRules, setOfColors);

            // Problem: find all bags containing (at least one) shiny gold bad
            // this is a graph traversal problem
            {
                // this stack holds the list of nodes to process
                var currentNodes = new Stack<string>();
                currentNodes.Push("shiny gold");

                var processedNodes = new HashSet<string>();

                // find all parents that have these nodes as children
                string currentNode = "";
                while (currentNodes.TryPop(out currentNode))
                {
                    // get the parent node that has this child node
                    var bagsContainingColor = baggingRules
                        .Where(r => r.Value.Contains(currentNode))
                        .Select(r => r.Key);

                    // put the current node on the list of processed nodes
                    processedNodes.Add(currentNode);

                    // filter the list of nodes returned
                    bagsContainingColor
                        // remove nodes that have already been visited
                        .Where(c => !processedNodes.Contains(c))
                        .ToList()
                        .ForEach(c => currentNodes.Push(c));
                }

                // need -1 to remove starting point
                int numberOfBags = processedNodes.Count() - 1;

                Console.WriteLine($"Number of bag colors that can contain at least 1 shiny gold bag : {numberOfBags}");
            }

            #endregion


            #region Part 2

            Console.WriteLine("Part 2");

            // same graph traversal problem, but now we are going the other way
            {
                // this stack holds the list of nodes to process
                var currentNodes = new Stack<string>();
                currentNodes.Push("shiny gold");

                // list that stores the bags (not nodes) required
                var processedNodes = new List<string>();
                
                string currentNode = "";
                while (currentNodes.TryPop(out currentNode))
                {
                    processedNodes.Add(currentNode);

                    // get child nodes for this node 
                    var bags = baggingRules[currentNode];

                    bags.ForEach(b => currentNodes.Push(b));
                }

                var numberOfBags = processedNodes.Count();

                Console.WriteLine($"The number of bags required inside your shiny gold bag are : {numberOfBags}");
            }
            #endregion

        }

        public static void ProcessInput(Dictionary<string, List<string>> baggingRulesOutput, HashSet<string> setOfColorsOutput)
        {
            // input.txt should be present in the /bin directory (Properties > Copy to output directory = Copy always)
            var input = File.ReadAllLines("input.txt");
            //var input = File.ReadAllLines("example.txt");

            // a bag contains other bags
            // need to parse the rules and setup bags accordingly

            // used regex101.com to develop these regex

            // "^([a-z ]+)" - matches a color
            // " bags contain" - mathces that exactly
            // "(.*)\.$" - matches the rest of the statement and the trailing period
            string regexSplitAcrossContains = @"^([a-z ]+) bags contain(.*)\.$";

            // this regex needs to be applied recursively (plan to)
            // "no other bags" - match exact
            // "[0-9] [a-z ]+ bags" - matches "<number> <color> bags
            // "1 [a-z ]+ bag" = mathces "1 <color> bag"
            // (, )? - optionally match ", " after an entry (or nothing)
            // .* - matches the remainder of the string (or nothing)
            string regex2ndHalfRecursive = @"(no other bags|[0-9] ([a-z ]+) bags|1 [a-z ]+ bag)(, )?(.*)$";

            // match any bag descrption in the 2nd half of the string
            string regexBagDetails = @"([0-9]+) ([a-z ]+) (bags|bag)";

            // process input
            foreach (var line in input)
            {
                var match = Regex.Match(line, regexSplitAcrossContains);
                var parentBagColor = match.Groups[1].Value;
                var childrenBagsString = match.Groups[2].Value;

                // add parent bag color to HashSet
                setOfColorsOutput.Add(parentBagColor);

                var childrenBags = new List<string>();

                while (childrenBagsString != "")
                {
                    var matchInner = Regex.Match(childrenBagsString, regex2ndHalfRecursive);
                    var bagDetails = matchInner.Groups[1].Value;

                    if (bagDetails == "no other bags")
                        break;

                    var matchBag = Regex.Match(bagDetails, regexBagDetails);
                    var numberOfBags = int.Parse(matchBag.Groups[1].Value);
                    var bagColor = matchBag.Groups[2].Value;

                    // add child bag color to HashSet
                    setOfColorsOutput.Add(bagColor);

                    for (int i = 0; i < numberOfBags; i++)
                    {
                        childrenBags.Add(new string(bagColor));
                    }

                    // recurse over the remainder of the string (exit if empty)
                    childrenBagsString = new string(matchInner.Groups[4].Value);
                }

                baggingRulesOutput.Add(parentBagColor, childrenBags);
            }

            // Check Dictionary.Keys().Count = Hashset<string>.Count - It does!
        }
    }
}
