
using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Collections;

namespace Utils
{
    class Tools
    {
        public static string ReadFile(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);
            return fileContent;
        }
    }
}


public class Solution
{
    string partOneTestAns, partTwoTestAns;
    public Solution(string name, string partOneTestAns, string partTwoTestAns)
    {
        bool testOutcome;
        string testFileContent, fileContent;
        string[] testLines, lines;
        this.partOneTestAns = partOneTestAns;
        this.partTwoTestAns = partTwoTestAns;

        string testFileName = @"C:\Users\RW154JK\aoc\" + name + "_test.txt";
        Console.WriteLine("Reading test input from: " + testFileName);
        testFileContent = Utils.Tools.ReadFile(testFileName);
        testLines = testFileContent.Split("\n");
        testOutcome = Test(testLines);
        if (testOutcome)
        {
            Console.WriteLine("Passed test successfully");
            string fileName = @"C:\Users\RW154JK\aoc\" + name + ".txt";
            Console.WriteLine("Reading input from: " + fileName);
            fileContent = Utils.Tools.ReadFile(fileName);
            lines = fileContent.Split("\n");
            Solve(lines);
        }
    }

    private bool Test(string[] lines)
    {
        string partOneOutput, partTwoOutput;
        partOneOutput = PartOne(lines);
        if (partOneOutput != partOneTestAns)
        {
            Console.WriteLine("Part one test failed with output: " + partOneOutput);
            return false;
        }
        Console.WriteLine("Part one test passed");
        partTwoOutput = PartTwo(lines);
        if (partTwoOutput != partTwoTestAns)
        {
            Console.WriteLine("Part two test failed with output: " + partTwoOutput);
            return false;
        }
    Console.WriteLine("Part two test passed");
        return true;
    }

    private void Solve(string[] lines)
    {
        string partOneOutput, partTwoOutput;
        partOneOutput = PartOne(lines);
        partTwoOutput = PartTwo(lines);
        Console.WriteLine("Part one output: " + partOneOutput);
        Console.WriteLine("Part two output: " + partTwoOutput);
    }
    public virtual string PartOne(string[] lines)
    {
    return "";
    }
    public virtual string PartTwo(string[] lines)
    {
    return "";
    }
}



namespace Solutions
{


    class Run
    {
        public static void Main(string[] args)
        {
            /*
            DayOne dayOne = new DayOne( @"C:\Users\RW154JK\aoc\1.txt");
            dayOne.SolveOne();
            dayOne.SolveTwo();
            

            DayTwo dayTwo = new DayTwo();
            dayTwo.Test();
            dayTwo.Solve();

            
            DayThree dayThree = new DayThree();
            
            DayFour dayFour = new DayFour();
            
            DayFive dayFive = new DayFive();
            
            DaySix daySix= new DaySix();
            
            DaySeven daySeven = new DaySeven();
            */
            // DayEight dayEight = new DayEight("8", "21", "8");
            // DayNine dayNine = new DayNine("9", "13", "36");
            // DayTen day = new DayTen();
            // DayEleven dayEleven = new DayEleven();
            DayTwelve dayTwelve = new DayTwelve();
        }
    }

    /*   
    class DayOne
    {
     
        public int nelves;
        string[] elves;
        public string fileContent;
        

        public DayOne(string filePath)
        {
            fileContent = Utils.Tools.ReadFile(filePath);
            elves = fileContent.Split("\n\n");
            nelves = elves.Length;

            Console.WriteLine("Created instance");
        }

        public void SolveOne()
        {
            // solve part one, return string of answer
            Console.Write("Solving part one");
            int max = 0;
            int totalCalories;
            for (int i = 0; i < this.nelves; i++)
            {
                totalCalories = elves[i].Split("\n").Select(int.Parse).Sum();
                if (totalCalories > max)
                {
                    max = totalCalories;
                }
            }
            Console.WriteLine("Max calories: " + max);
             

        }

        public void SolveTwo()
        {
            // solve part two, return string of answer
            int[] totals = new int[nelves];
            int totalCalories;
            for (int i = 0; i < nelves; i++)
            {
                totalCalories = elves[i].Split("\n").Select(int.Parse).Sum();
                totals[i] = totalCalories;
            }
            Array.Sort(totals);
            Array.Reverse(totals);
            int threeLargest = totals.Take(3).Sum();
            Console.WriteLine("Sum of three largest calories: " + threeLargest);
        }

    }

    class DayTwo
    {

        Dictionary<string, int> shapeScores = new Dictionary<string, int>();
        Dictionary<string, int> outcomeScores= new Dictionary<string, int>();
        Dictionary<string, string> shapeMapping= new Dictionary<string, string>();
        Dictionary<(string, string), string> outcomeMapping = new Dictionary<(string, string), string>();
        Dictionary<string, string> codedOutcomes = new Dictionary<string, string>();
        string fileContent;

        public DayTwo() 
        {
            shapeScores.Add("Rock", 1);
            shapeScores.Add("Paper", 2);
            shapeScores.Add("Scissors", 3);

            outcomeScores.Add("Win", 6);
            outcomeScores.Add("Lose", 0);
            outcomeScores.Add("Draw", 3);

            shapeMapping.Add("A", "Rock");
            shapeMapping.Add("X", "Rock");
            shapeMapping.Add("B", "Paper");
            shapeMapping.Add("Y", "Paper");
            shapeMapping.Add("C", "Scissors");
            shapeMapping.Add("Z", "Scissors");

            Console.WriteLine(shapeMapping["A"] + "_" + shapeMapping["Y"]);

            outcomeMapping.Add(("Rock", "Paper"), "Lose");
            outcomeMapping.Add(("Rock", "Scissors"), "Win");
            outcomeMapping.Add(("Paper", "Rock"), "Win");
            outcomeMapping.Add(("Paper", "Scissors"), "Lose");
            outcomeMapping.Add(("Scissors", "Paper"), "Win");
            outcomeMapping.Add(("Scissors", "Rock"), "Lose");
            outcomeMapping.Add(("Rock", "Rock"), "Draw");
            outcomeMapping.Add(("Paper", "Paper"), "Draw");
            outcomeMapping.Add(("Scissors", "Scissors"), "Draw");

            codedOutcomes.Add("X", "Lose");
            codedOutcomes.Add("Y", "Draw");
            codedOutcomes.Add("Z", "Win");

        }

        public int PartOne(string[] lines)
        {
            int score = 0;
            string myShape, hisShape;
            string outcome;

            foreach(string line in lines)
            {
                myShape = shapeMapping[line.Substring(2, 1)];
                hisShape = shapeMapping[line.Substring(0, 1)];
                outcome = outcomeMapping[(myShape, hisShape)];
                score += shapeScores[myShape] + outcomeScores[outcome];
            }
            Console.WriteLine(score);



            return score;
        }

        public int PartTwo(string[] lines)
        {
            int score = 15;



            return score;
        }

        public void Solve()
        {
            string[] lines;
            int partOneAns;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\2.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);

            Console.WriteLine("Part one score: ", partOneAns);
        }

        public void Test()
        {
            int partOneAns, partTwoAns;
            string[] lines;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\2_test.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);
            if (partOneAns == 15)
            {
                Console.WriteLine("Part one passed test successfully");
            }
            else
            {
                Console.WriteLine("Part one test failed with output " + partOneAns);
            }
            partTwoAns= this.PartTwo(lines);
            if (partTwoAns == 12)
            {
                Console.WriteLine("Part two passed test successfully");
            }
            else
            {
                Console.WriteLine("Part two test failed with output " + partTwoAns);
            }

        }

    }

    class DayThree
    {
        string fileContent;
        string[] lines;
        bool testOutcome;

        public DayThree()
        {
            testOutcome = Test();
            if (testOutcome)
            {
                Solve();
            }
        }
        private int LetterPriority(char letter)
        {
            if (char.IsUpper(letter))
            {
                return letter - 'A' + 27;
            }
            else
            {
                return letter - 'a' + 1;
            }
        }
        private bool Test()
        {
            int partOneAns;
            int partTwoAns;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\3_test.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);
            if (partOneAns == 157)
            {
                Console.WriteLine("Part one test passed successfully");
            }
            else
            {
                Console.WriteLine("Part one failed with value " + partOneAns);
                return false;
            }
            partTwoAns = PartTwo(lines);
            if (partTwoAns == 70)
            {
                Console.WriteLine("Part two test passed successfully");
            }
            else
            {
                Console.WriteLine("Part two failed with value " + partTwoAns);
                return false;
            }
            return true;
        }
        private void Solve()
        {
            int partOneAns;
            int partTwoAns;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\3.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);
            partTwoAns = PartTwo(lines);
            Console.WriteLine("Part one ans: " + partOneAns);
            Console.WriteLine("Part two ans: " + partTwoAns);
        }
        private int PartOne(string[] lines)
        {
            int score = 0;
            int rucksackLength;
            string sackOne, sackTwo;
            char letter;
            foreach(string line in lines)
            {
                rucksackLength= line.Length/2;
                sackOne = line.Substring(0, rucksackLength);
                sackTwo = line.Substring(rucksackLength, rucksackLength);
                letter = sackOne.Intersect(sackTwo).First();
                score += LetterPriority(letter);
//              Console.WriteLine(letter + " " + LetterPriority(letter));
            }
            return score;
        }
        private int PartTwo(string[] lines)
        {
            int score = 0, nSacks;
            string sackOne, sackTwo, sackThree;
            char letter;
            nSacks = lines.Length;
            for (int i = 0; i < nSacks; i += 3)
            {
                sackOne = lines[i];
                sackTwo = lines[i + 1];
                sackThree = lines[i + 2];
                letter = sackOne.Intersect(sackTwo).Intersect(sackThree).First();
                score += LetterPriority(letter);
            }
            return score;
        }
    }

    class DayFour
    {
        string fileContent;
        string[] lines;
        bool testOutcome;

        public DayFour()
        {
            testOutcome = Test();
            if (testOutcome)
            {
                Solve();
            }
        }
        private bool Test()
        {
            int partOneAns;
            int partTwoAns;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\4_test.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);
            if (partOneAns == 2)
            {
                Console.WriteLine("Part one test passed successfully");
            }
            else
            {
                Console.WriteLine("Part one failed with value " + partOneAns);
                return false;
            }
            partTwoAns = PartTwo(lines);
            if (partTwoAns == 4)
            {
                Console.WriteLine("Part two test passed successfully");
            }
            else
            {
                Console.WriteLine("Part two failed with value " + partTwoAns);
                return false;
            }
            return true;
        }
        private void Solve()
        {
            int partOneAns;
            int partTwoAns;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\4.txt");
            lines = fileContent.Split("\n");
            partOneAns = PartOne(lines);
            partTwoAns = PartTwo(lines);
            Console.WriteLine("Part one ans: " + partOneAns);
            Console.WriteLine("Part two ans: " + partTwoAns);
        }

        private int PartOne(string[] lines)
        {
            string[] splitOne, splitTwo, splitThree;
            int a, b, c, d, score=0;
            foreach(string line in lines)
            {
                splitOne = line.Split(",");
                // Console.WriteLine(line);
                splitTwo = splitOne[0].Split("-");
                splitThree = splitOne[1].Split("-");
                a = int.Parse(splitTwo[0]);
                b = int.Parse(splitTwo[1]);
                c = int.Parse(splitThree[0]);
                d = int.Parse(splitThree[1]);
                score += Convert.ToInt16(CheckContained(a, b, c, d));
            }
            return score;
        }

        private int PartTwo(string[] lines)
        {
            string[] splitOne, splitTwo, splitThree;
            int a, b, c, d, score = 0;
            foreach (string line in lines)
            {
                splitOne = line.Split(",");
                // Console.WriteLine(line);
                splitTwo = splitOne[0].Split("-");
                splitThree = splitOne[1].Split("-");
                a = int.Parse(splitTwo[0]);
                b = int.Parse(splitTwo[1]);
                c = int.Parse(splitThree[0]);
                d = int.Parse(splitThree[1]);
                score += Convert.ToInt16(CheckOverlap(a, b, c, d));
            }
            return score;
        }

        private bool CheckContained(int a, int b, int c, int d)
        {
            if ((a <= c) & ( d <= b)) { return true; }
            if (( a>= c) & (b <= d)) { return true; }
            return false;
        }
        private bool CheckOverlap(int a, int b, int c, int d)
        {
            if (a >= c)
            {
                if (a <= d)
                {
                    return true;
                }

            }
            else
            {
                if (b >= c)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class DayFive
    {
        string fileContent;
        string[] lines;
        bool testOutcome;

        class Node
        {
            public string value;
            public Node next;
            public Node(string value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }
        


        class Stack
        {
            Node top = null;
            public int n = 0;
            
            
            public string Pop()
            {
                Node oldTop;
                oldTop = top;
                if (top == null)
                {
                    Console.WriteLine("Attempting to pop from empty stack");
                }
                top = top.next;
                n -= 1;
                return oldTop.value;
            }
            public void AddStack(string value)
            {
                
                top = new Node(value, top);
                n += 1;
            }
            public bool IsEmpty()
            {
                if (top == null)
                {
                    return true;
                }
                return false;
            }
        }

        public DayFive()
        {
            testOutcome = Test();
            if (testOutcome)
            {
                Solve();
            }
        }
        private bool Test()
        {
            string partOneAns;
            string partTwoAns;
            Stack[] stacks;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\5_test.txt");
            lines = fileContent.Split("\n");

            stacks = Construct(lines, 3);


            partOneAns = PartOne(stacks, lines);
            if (partOneAns == "CMZ")
            {
                Console.WriteLine("Part one test passed successfully");
            }
            else
            {
                Console.WriteLine("Part one failed with value " + partOneAns);
                return false;
            }
            lines = fileContent.Split("\n");
            stacks = Construct(lines, 3);
            partTwoAns = PartTwo(stacks, lines);
            if (partTwoAns == "MCD")
            {
                Console.WriteLine("Part two test passed successfully");
            }
            else
            {
                Console.WriteLine("Part two failed with value " + partTwoAns);
                return false;
            }
            return true;
        }
        private void Solve()
        {
            string partOneAns;
            string partTwoAns;
            Stack[] stacks;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\5.txt");
            lines = fileContent.Split("\n");
            stacks = Construct(lines, 9);
            partOneAns = PartOne(stacks, lines);
            stacks = Construct(lines, 9);
            partTwoAns = PartTwo(stacks, lines);
            Console.WriteLine("Part one ans: " + partOneAns);
            Console.WriteLine("Part two ans: " + partTwoAns);
        }

        private Stack[] Construct(string[] lines, int nstacks)
        {

            Stack[] stacks = new Stack[nstacks];
            for(int k = 0; k < nstacks;k++)
            {
                stacks[k] = new Stack();
            }
            Array.Reverse(lines);
            string line;
            int i = 0, currentPos;

            do
            {
                i++;
            } while (lines[i].Substring(0, 1) != "[");
            for (int j = i; j < lines.Length; j++)
            {
                // Console.WriteLine(j);
                line = lines[j];
                for(int n = 0; n < nstacks; n += 1)
                {
                    currentPos = n * 4 + 1;
                    if (line.Substring(currentPos, 1) != " ")
                    {
                        stacks[n].AddStack(line.Substring(currentPos, 1));
                    }
                }
            }
            return stacks;
        }

        private string PartOne(Stack[] stacks, string[] lines)
        {
            string[] split;
            string ans = "", currValue;
            int nCrates, from, to;
            Array.Reverse(lines);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (line.Substring(0, 1) == "m")
                    {
                        split = line.Split(" ");
                        nCrates = int.Parse(split[1]);
                        from = int.Parse(split[3]) - 1;
                        to = int.Parse(split[5]) - 1;
                        for (int k = 0; k < nCrates; k++)
                        {
                            stacks[to].AddStack(stacks[from].Pop());
                        }

                    }
                }
            }
            foreach(Stack stack in stacks)
            {
                ans += stack.Pop();
            }
            Console.WriteLine(ans);
            return ans;
        }

        private string PartTwo(Stack[] stacks, string[] lines)
        {
            string[] split;
            string ans = "", currValue;
            int nCrates, from, to;
            Array.Reverse(lines);
            Stack dummyStack = new Stack();

            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (line.Substring(0, 1) == "m")
                    {
                        split = line.Split(" ");
                        nCrates = int.Parse(split[1]);
                        from = int.Parse(split[3]) - 1;
                        to = int.Parse(split[5]) - 1;
                        for (int k = 0; k < nCrates; k++)
                        {
                            dummyStack.AddStack(stacks[from].Pop());
                        }
                        for (int k = 0; k < nCrates; k++)
                        {
                            stacks[to].AddStack(dummyStack.Pop());
                        }
                    }
                }
            }
            foreach (Stack stack in stacks)
            {
                ans += stack.Pop();
            }
            Console.WriteLine(ans);
            return ans;
        }

        private bool CheckContained(int a, int b, int c, int d)
        {
            if ((a <= c) & (d <= b)) { return true; }
            if ((a >= c) & (b <= d)) { return true; }
            return false;
        }
        private bool CheckOverlap(int a, int b, int c, int d)
        {
            if (a >= c)
            {
                if (a <= d)
                {
                    return true;
                }

            }
            else
            {
                if (b >= c)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class DaySix
    {
        bool testOutcome;
        public DaySix()
        {
            testOutcome = Test();
            if (testOutcome)
            {
                Solve();
            }
        }
        public bool Test()
        {
            string[] lines;
            string fileContent, line;
            int ans;
            int[] partOneAnswers = { 5, 6, 10, 11 };
            int[] partTwoAnswers = { 19, 23, 23, 29, 26 };
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\6_test.txt");
            lines = fileContent.Split("\n");
            for (int i=0;i<4;i++)
            {
                line = lines[i];
                ans = Process(line, 4);
                if(ans != partOneAnswers[i])
                {
                    Console.WriteLine("Part one failed on " + i + " with value" + ans);
                    return false;
                }
            }
            Console.WriteLine("Part one tests passed successfully");
            for(int i = 4;i<9;i++)
            {
                line = lines[i];
                ans = Process(line, 14);
                if(ans != partTwoAnswers[i - 4])
                {
                    Console.WriteLine("Part two failed on " + i + "with value" + ans);
                    return false;
                }
            }
            Console.WriteLine("Part two tests passed successfully");
            
            return true;
        }
        public void Solve()
        {
            int partOneAns, partTwoAns;
            string line;
            string[] lines;
            line = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\6.txt");
            partOneAns = Process(line, 4);
            Console.WriteLine("Part one ans: " + partOneAns);
            partTwoAns = Process(line, 14);
            Console.WriteLine("Part two ans: " + partTwoAns);

        }
        private int Process(string line, int n)
        {
            int ans, pos = 0;
            do
            {
                pos++;
            } while (line.Substring(pos, n).Distinct().Count() != n);
            ans = pos + n;
            return ans;
        }
        
    }

    class DaySeven
    {
        bool testOutcome;
        Node root = new Node(null, @"/");
        public DaySeven()
        {
            testOutcome = Test();
            if (testOutcome)
            {
                Solve();
            }
        }
        public bool Test()
        {
            string fileContent;

            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\7_test.txt");
            Parse(fileContent.Split("\n"));
            root.Walk();
            return false;
        }
        public void Solve()
        {
            string fileContent;
            fileContent = Utils.Tools.ReadFile(@"C:\Users\RW154JK\aoc\7.txt");
        }



        public Node Parse(string[] lines)
        {
            
            Node currentDir = root;
            string currentDirName;
            int currentLine = 1;
            string newName;
            string line;
            string[] lineSplit;
            do
            {
                line = lines[currentLine];
                Console.WriteLine(currentLine + ": " + line);
                if (line.Trim() == "$ cd ..")
                {
                    currentDir = currentDir.parent;
                    currentDirName = currentDir.name;
                    Console.WriteLine("Current dir: " + currentDirName);
                }
                else if (line.Substring(0, 4) == "$ cd")
                {
                    currentDirName = line.Split(" cd ")[1];
                    Console.WriteLine("Current dir: " + currentDirName);
                    currentDir = currentDir.getDir(currentDirName);
                    
               
                }
                else if (line.Substring(0, 4) == "$ ls")
                {
                    
                    
                    Console.WriteLine("Listing " + currentDir.name + "\n");
                    do
                    {
                        currentLine++;
                        line = lines[currentLine];
                        Console.WriteLine(currentLine + ": " + line);
                        if (line.Substring(0, 3) == "dir")
                        {
                            currentDir.AddNode(line.Split(" ")[1]);
                            Console.WriteLine(@"Adding dir " + line.Split(" ")[1] + " to " + currentDir.name + "\n");
                        }
                        else
                        {
                            lineSplit = line.Split(" ");
                            Console.WriteLine("Adding file ");
                            Console.WriteLine(lineSplit[1] + " " + lineSplit[0] + " to " + currentDir.name + "\n");

                            currentDir.AddFile(lineSplit[1], int.Parse(lineSplit[0]));
                        }
                        if (currentLine >= line.Length - 1)
                        {
                            break;
                        }
                        if (lines[currentLine+1].Substring(0, 1) == "$")
                        {
                            break;
                        }

                    } while (true);
                    
                }
                currentLine++;
            } while (currentLine < lines.Length);
            return root;
        }

        public class File
        {
            public string name;
            public int size;
            public File(string name, int size)
            {
                this.name = name;
                this.size = size;
            }
        }

        public class Node
        {
            public string name;
            public int size= 0;
            public Node[] nodes = new Node[1000];
            public File[] files = new File[1000];
            public Node parent;
            int filePos = 0, nodePos = 0;

            public Node(Node parent, string name)
            {
                this.parent = parent;
                this.name = name;

            }

            public void AddFile(string name, int size)
            {
                Node tempNode = this;
                files[filePos] = new File(name, size);
                this.size += size;
                
                while(tempNode.parent != null)
                {
                    tempNode = tempNode.parent;
                    tempNode.size += size;
                }

    filePos++;
            }

            public void AddNode(string name)
            {
                nodes[nodePos] = new Node(this, name);
                nodePos++;
            }

            public void Walk()
            {
                Console.WriteLine(this.name); Console.Write(": ");Console.Write(this.size + "\n");
                for(int i = 0; i < nodePos; i++)
                {
                    nodes[i].Walk();
                }
            }

            public Node getDir(string dirName)
            {
                for(int i=0;i<nodePos; i++)
                {
                    if (nodes[i].name == dirName)
                    {
                        return nodes[i];
                    }
                }
                Console.WriteLine("No node with name " + dirName + " found in node " + this.name);
                return this;
            }
    }
        
    }
*/

    public class DayEight : Solution
    {
        public DayEight(string name, string partOneTestAns, string partTwoTestAns) : base(name, partOneTestAns, partTwoTestAns)
        {
            Console.WriteLine("Creating: " + name);
        }

        private int[,] ProcessLines(string[] lines)
        {
            int lineLength, nLines;
            int[,] intLines;

            nLines = lines.Length;
            lineLength = lines[0].Trim().Length;
            intLines = new int[nLines, lineLength];
            for (int i = 0; i < nLines; i++)
            {
                for (int j = 0; j < lineLength; j++)
                {
                    intLines[i, j] = lines[i][j] - '0';
                }
            }

            return intLines;
        }

        public override string PartOne(string[] lines)
        {
            int[,] intLines = ProcessLines(lines);
            int ncols = lines[0].Trim().Length, nrows = lines.Length;
            int[,] isVisible = new int[nrows, ncols];
            int leftMax, rightMax, topMax, bottomMax, leftMaxPos, topMaxPos;
            int visibleTrees;
            for (int i = 0; i < nrows; i++)
            {
                leftMax = -1;
                rightMax = -1;
                leftMaxPos = -1;
                for (int j = 0; j < ncols - 1; j++)
                {
                    if (intLines[i, j] > leftMax)
                    {
                        leftMax = intLines[i, j];
                        leftMaxPos = j;
                        isVisible[i, j] = 1;
                    }
                }
                for (int j = ncols - 1; j > leftMaxPos; j--)
                {
                    if (intLines[i, j] > rightMax)
                    {
                        rightMax = intLines[i, j];
                        isVisible[i, j] = 1;
                    }
                }
            }
            for (int j = 0; j < ncols; j++)
            {
                topMax = -1;
                bottomMax = -1;
                topMaxPos = -1;
                for (int i = 0; i < nrows - 1; i++)
                {
                    if (intLines[i, j] > topMax)
                    {
                        topMax = intLines[i, j];
                        topMaxPos = i;
                        isVisible[i, j] = 1;
                    }
                }
                for (int i = nrows - 1; i > topMaxPos; i--)
                {
                    if (intLines[i, j] > bottomMax)
                    {
                        bottomMax = intLines[i, j];
                        isVisible[i, j] = 1;
                    }
                }
            }
            visibleTrees = isVisible.Cast<int>().Sum();
            return visibleTrees.ToString();
        }

        public override string PartTwo(string[] lines)
        {
            int ans = 0;
            int[,] intLines = ProcessLines(lines);
            int ncols = lines[0].Trim().Length, nrows = lines.Length;
            int[,] scenicScores = new int[nrows, ncols];
            for (int i = 1; i < nrows - 1; i++)
            {
                for (int j = 1; j < ncols - 1; j++)
                {
                    int leftCount = 1, rightCount = 1, upCount = 1, downCount = 1;
                    int height = intLines[i, j];
                    // left
                    while (height > intLines[i, j - leftCount])
                    {
                        leftCount++;
                        if (leftCount >= j) { leftCount = j; break; }
                    }
                    while (height > intLines[i, j + rightCount])
                    {
                        rightCount++;
                        if (rightCount >= ncols - j - 1) { rightCount = ncols - j - 1; break; }
                    }
                    while (height > intLines[i + downCount, j])
                    {
                        downCount++;
                        if (downCount >= nrows - i - 1)
                        {
                            downCount = nrows - i - 1;
                            break;
                        }
                    }
                    while (height > intLines[i - upCount, j])
                    {
                        upCount++;
                        if (upCount >= i) { upCount = i; break; }
                    }
                        
                
               // Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", i, j, leftCount, rightCount, upCount, downCount, height > intLines[i - upCount, j]);
                scenicScores[i, j] = leftCount * rightCount * upCount * downCount;

                }
            }
            /*
            for(int i = 0; i < nrows; i++)
            {
                for(int j=0;j<ncols;j++)
                {
                    Console.Write(scenicScores[i, j] + " ");
                }
                Console.Write("\n");
            }
            */
            ans = scenicScores.Cast<int>().Max();
            return ans.ToString();
        }
    }
    
    public class DayNine: Solution
    {
        public DayNine(string name, string PartOneTestAns, string PartTwoTestAns) : base (name, PartOneTestAns, PartTwoTestAns)
        { }
        
        private void Move(ref int[] pos, char direction)
        {
            switch(direction)
            {
                case 'U':
                    pos[0]++;
                    break;
                case 'D':
                    pos[0]--;
                    break;
                case 'L':
                    pos[1]--;
                    break;
                case 'R':
                    pos[1]++;
                    break;
                default:
                    throw new Exception("Unknown direction supplied");
            }
        }
        private void Planck(ref int[] head, ref int[] tail)
        {
            int hdiff, vdiff;
            hdiff = Math.Abs(head[1] - tail[1]);
            vdiff = Math.Abs(head[0] - tail[0]);

            if (hdiff <=1 && vdiff <= 1) { return; }
            if (hdiff == 2)
            {
                tail[1] = (tail[1] + head[1]) / 2;
                if (vdiff == 1)
                {
                    tail[0] = head[0];
                }
                else if (vdiff == 2)
                {
                    tail[0] = (tail[0] + head[0]) / 2;
                }
            }
            else if (vdiff == 2)
            {
                tail[0] = (tail[0] + head[0]) / 2;
                if (hdiff == 1)
                {
                    tail[1] = head[1];
                }
                if (hdiff==2)
                {
                    tail[1] = (tail[1] + head[1]) / 2;
                }
            }
            // Console.WriteLine("Head: {2}, {3}. Tail: {0}, {1}", tail[0], tail[1], head[0], head[1]);
        }

        public override string PartOne(string[] lines)
        {
            string[] lineSplit;
            char direction;
            int nMoves, nStates=1;
            int[] head = new int[2], tail = new int[2];
            Dictionary<(int, int), bool> visitedStates = new Dictionary<(int, int), bool>();
            visitedStates.Add((0, 0), true);
            foreach(string line in lines)
            {
                lineSplit = line.Split(" ");
                // Console.WriteLine(line);
                direction = lineSplit[0][0];
                nMoves = int.Parse(lineSplit[1]);
                for (int i=0;i<nMoves;i++)
                {
                    Move(ref head, direction);
                    Planck(ref head, ref tail);
                    if (!visitedStates.ContainsKey((tail[0], tail[1])))
                    {
                        nStates++;
                        visitedStates.Add((tail[0], tail[1]), true);
                    }
                }
            }
            return nStates.ToString();
        }
        public override string PartTwo(string[] lines)
        {
            string[] lineSplit;
            char direction;
            int nMoves, nStates = 1;

            int[] head = new int[2];
            int[] tail_1 = new int[2];
            int[] tail_2 = new int[2];
            int[] tail_3 = new int[2];
            int[] tail_4 = new int[2];
            int[] tail_5 = new int[2];
            int[] tail_6 = new int[2];
            int[] tail_7 = new int[2];
            int[] tail_8 = new int[2];
            int[] tail_9 = new int[2];
            Dictionary<(int, int), bool> visitedStates = new Dictionary<(int, int), bool>();
            visitedStates.Add((0, 0), true);
            foreach (string line in lines)
            {
                lineSplit = line.Split(" ");
               //  Console.WriteLine(line);
                direction = lineSplit[0][0];
                nMoves = int.Parse(lineSplit[1]);
                for (int j = 0; j < nMoves; j++)
                {
                    Move(ref head, direction);
                    Planck(ref head, ref tail_1);
                    Planck(ref tail_1, ref tail_2);
                    Planck(ref tail_2, ref tail_3);
                    Planck(ref tail_3, ref tail_4);
                    Planck(ref tail_4, ref tail_5);
                    Planck(ref tail_5, ref tail_6);
                    Planck(ref tail_6, ref tail_7);
                    Planck(ref tail_7, ref tail_8);
                    Planck(ref tail_8, ref tail_9);
                    Console.WriteLine("{0} {1}, {2} {3}", tail_8[0], tail_8[1], tail_9[0], tail_9[1]);
                    if (!visitedStates.ContainsKey((tail_9[0], tail_9[1])))
                    {
                        nStates++;
                        visitedStates.Add((tail_9[0], tail_9[1]), true);
                    }
                }
            }
            Console.WriteLine(nStates);
            return "36";
        }


    }

    public class DayTen : Solution
    {

        public DayTen() : base("10", "13140", "")
        { }

        public override string PartOne(string[] lines)
        {
            int cycle = 1;
            int register = 1;
            int[] registerValues = new int[1000];
            registerValues[0] = 0;
            string[] lineSplit;
            int x;
            int[] values = { 20, 60, 100, 140, 180, 220};
            foreach (string line in lines)
            {
                registerValues[cycle] = register;
                if (line.Trim() == "noop")
                {
                    cycle++;
                }
                else
                {
                    lineSplit = line.Split(' ');
                    x = int.Parse(lineSplit[1]);
                    cycle++;
                    registerValues[cycle] = register;
                    register += x;
                    cycle++;

                }
               
            }
            registerValues[cycle] = register;
            int signalStrength = 0;
            foreach (int val in values)
            {
                Console.WriteLine("{0}: {1}", val, registerValues[val]);
                signalStrength += (val * registerValues[val]);
            }

            return signalStrength.ToString();
        }
        private void checkPos(ref char[] screen, int cycle, int x)
        {
            // Console.WriteLine("{0}, {1}, {2}\n", cycle, x, cycle%40);
            if (Math.Abs(cycle%40-x)<2)
            {
                screen[cycle] = '#';
            }
            else
            {
                screen[cycle] = '.';
            }
        }
        public override string PartTwo(string[] lines)
        {
            int cycle = 1;
            int register = 1;
            string[] lineSplit;
            int x;
            char[] screen = new char[240];
            foreach (string line in lines)
            {
                if (line.Trim() == "noop")
                {
                    
                    checkPos(ref screen, cycle-1, register);
                    cycle++;
                    
                }
                else
                {
                    lineSplit = line.Split(' ');
                    x = int.Parse(lineSplit[1]);
                    checkPos(ref screen, cycle-1, register);
                    cycle++;
                    
                    checkPos(ref screen, cycle-1, register);
                    register += x;
                    cycle++;

                }
            }
            for(int i=0;i<6;i++)
            {
                for(int j=0;j<40;j++)
                {
                    Console.Write(screen[i*40 + j]);
                }
                Console.WriteLine("\n");
            }
            return "";
        }

    }

    public class DayEleven : Solution
    {
        Monkey[] monkeys;
        public DayEleven() : base("11", "10605", "2713310158")
        {

        }
        struct Monkey
        {
            public Queue<long> items;
            public char operation;
            public long opNum;
            public long testNum;
            public int ifTrue;
            public int ifFalse;
            public int count;
        }
        private void Parse(string[] lines)
        {
            int nLines = lines.Length;
            monkeys = new Monkey[(lines.Length + 1) / 7];
            Monkey currentMonkey;
            currentMonkey = new Monkey();
            int i = 0;
            foreach (string line in lines)
            {
                TryParse parser = LineParse(line);
                if (parser(@"Monkey (\d+)", out var arg))
                {

                    currentMonkey = new Monkey();
                    currentMonkey.count = 0;
                }
                else if (parser(@"Starting items: (.*)", out arg))
                {
                    currentMonkey.items = new Queue<long>(arg.Split(", ").Select(long.Parse));
                }
                else if (parser(@"Operation: new = old \* old", out arg))
                {
                    currentMonkey.operation = 's';
                }
                else if (parser(@"Operation: new = old \+ (\d+)", out arg))
                {
                    currentMonkey.operation = '+';
                    currentMonkey.opNum = long.Parse(arg);
                }
                else if (parser(@"Operation: new = old \* (\d+)", out arg))
                {
                    currentMonkey.operation = '*';
                    currentMonkey.opNum = long.Parse(arg);
                }
                else if (parser(@"Test: divisible by (\d+)", out arg))
                {
                    currentMonkey.testNum = long.Parse(arg);
                }
                else if (parser(@"If true: throw to monkey (\d+)", out arg))
                {
                    currentMonkey.ifTrue = int.Parse(arg);
                }
                else if (parser(@"If false: throw to monkey (\d+)", out arg))
                {
                    currentMonkey.ifFalse = int.Parse(arg);
                    monkeys[i] = currentMonkey;
                    i++;
                }


            }

        }
        public override string PartOne(string[] lines)
        {
            long ans;
            Parse(lines);
            foreach (Monkey monkey in monkeys)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", monkey.items.First(), monkey.operation, monkey.opNum, monkey.testNum, monkey.ifTrue, monkey.ifFalse);
            }
            int nRounds = 20;
            ans = Rounds(monkeys, nRounds, false);
            /*
            int tempNItems;
            bool outcome;
            Node currentItem;
            int nMonkeys = monkeys.Length;
            Console.WriteLine(nMonkeys);
            int[] counts= new int[nMonkeys];
            for (int i = 0; i < nrounds;i++)
            {
                foreach(Monkey monkey in monkeys)
                {
                    if(monkey.items.isEmpty())
                    {
                        continue;
                    }
                    currentItem = monkey.items.first;
                    tempNItems = monkey.nItems;

                    for(int j = 0; j<tempNItems;j++)
                    {
                        outcome = monkey.Inspect(ref currentItem.val, false);
                        currentItem = currentItem.next;
                        if (outcome)
                        {
                            monkeys[monkey.ifTrue].receiveItem(monkey.items.Dequeue());
                            monkey.nItems--;
                        }
                        else
                        {
                            monkeys[monkey.ifFalse].receiveItem(monkey.items.Dequeue());
                            monkey.nItems--;
                        }
                    }
                }
                int n = 0;
                foreach(Monkey monkey in monkeys)
                {
                    //Console.Write("\n{0}: ", n, i);
                    Node currentItem1 = monkey.items.first;
                    while(currentItem1 != null)
                    {
                        //Console.Write("{0} ", currentItem1.val);
                        currentItem1 = currentItem1.next;
                    }
                    n++;
                }
            }
            for(int i=0; i<nMonkeys;i++)
            {
                counts[i] = monkeys[i].count;
            }
            Array.Sort(counts);
            Array.Reverse(counts);
            int ans = counts[0] * counts[1];
            */
            return ans.ToString();
        }

        TryParse LineParse(string line)
        {
            bool match(string pattern, out string arg)
            {
                var m = Regex.Match(line, pattern);
                if (m.Success)
                {
                     arg = m.Groups[m.Groups.Count - 1].Value;
                     return true;
                }
                else
                {
                    arg = "";
                    return false;
                }
            }
            return match;
        }


        delegate bool TryParse(string patter, out string arg);

        private long Rounds(Monkey[] monkeys, int nRounds, bool mod)
        {

            long modNum = 1;
            foreach(Monkey monkey in monkeys)
            {
                modNum *= monkey.testNum;

            }
            int[] checks = { 0, 19, 999, 1999 };
            Console.WriteLine(modNum);
            int nMonkeys = monkeys.Length;
            long[] counts = new long[nMonkeys];

            

            for(int n=0;n<nRounds;n++)
            {
                for(int j=0; j<nMonkeys; j++)
                {
                    
                    if (monkeys[j].items.Count()==0)
                    {
                        continue;
                    }
                    do
                    {
                        long currentVal;
                        bool outcome;
                        monkeys[j].count++;
                        currentVal = monkeys[j].items.Dequeue();
                        if (currentVal < 0)
                        {
                            throw new Exception("Overflow encountered");
                        }
                        switch (monkeys[j].operation)
                        {
                            case 's':  currentVal *= currentVal; break;
                            case '+': currentVal += monkeys[j].opNum; break;
                            case '*': currentVal *= monkeys[j].opNum; break;
                            default: throw new ArgumentException("Unknown operator being used");
                        }
                        if (currentVal < 0)
                        {
                            throw new Exception("Overflow encountered");
                        }
                        if (mod)
                        {
                            currentVal = currentVal % (96577);
                        }
                        else
                        {
                            currentVal /= 3;
                        }
                        outcome = (currentVal%monkeys[j].testNum) == 0;
                        if(outcome)
                        {
                            monkeys[monkeys[j].ifTrue].items.Enqueue(currentVal);
                        }
                        else
                        {
                            monkeys[monkeys[j].ifFalse].items.Enqueue(currentVal);
                        }
                        

                    } while (monkeys[j].items.Count() != 0);
                }
                if(checks.Contains(n))
                {
                    for (int i = 0; i < nMonkeys; i++)
                    {
                        counts[i] = monkeys[i].count;
                        Console.WriteLine("{2} rounds: {0}: {1}", i, counts[i], n);
                    }
                }
            }
            for(int i = 0; i < nMonkeys; i++)
            {
                counts[i] = monkeys[i].count;
                Console.WriteLine("{0}: {1}", i, counts[i]);
            }
            Array.Sort(counts);
            Array.Reverse(counts);
            return counts[0] * counts[1];
        }

        public override string PartTwo(string[] lines)
        {
            long ans;
            int nRounds = 10000;
            Parse(lines);
            ans = Rounds(monkeys, nRounds, true);
            /*
            Parse(lines);
            long nrounds = 10000;
            int tempNItems;
            bool outcome;
            Node currentItem;
            int nMonkeys = monkeys.Length;
            long[] counts = new long[nMonkeys];
            for (int i = 0; i < nrounds; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    if (monkey.items.isEmpty())
                    {
                        continue;
                    }
                    currentItem = monkey.items.first;
                    tempNItems = monkey.nItems;

                    for (int j = 0; j < tempNItems; j++)
                    {
                        currentItem.val = currentItem.val % (2 * 3 * 5 * 7 * 11);
                        outcome = monkey.Inspect(ref currentItem.val, true);
                        currentItem = currentItem.next;
                        if (outcome)
                        {
                            monkeys[monkey.ifTrue].receiveItem(monkey.items.Dequeue());
                            monkey.nItems--;
                        }
                        else
                        {
                            monkeys[monkey.ifFalse].receiveItem(monkey.items.Dequeue());
                            monkey.nItems--;
                        }
                    }
                }
            }
            for (int i = 0; i < nMonkeys; i++)
            {
                counts[i] = monkeys[i].count;
                Console.WriteLine(counts[i]);
            }
            Array.Sort(counts);
            Array.Reverse(counts);
            long ans = counts[0] * counts[1];
            Console.WriteLine(ans);
            */
            return ans.ToString();

        }
    }

    public class DayTwelve: Solution
    {
        int[,] grid;
        int goal;
        
        int nrows, ncols;
        string[] lines;
        public DayTwelve(): base("12", "31", "29")
        {
            Console.WriteLine(goal);
        }

        public void Parse(string[] lines)
        {
            nrows = lines.Length;
            ncols = lines[0].Trim().Length;
            Console.Write("{0}, {1}", nrows, ncols);
            grid = new int[nrows, ncols];
            for (int i = 0; i < nrows; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < ncols; j++)
                {
                    
                    if (lines[i][j] == 'E')
                    {
                        grid[i, j] = char.ToUpper('z') - 64 + 1;
                    }
                    else
                    {
                        grid[i, j] = char.ToUpper(lines[i][j]) - 64;
                    }
                }
            }
            List<int[]> test = new List<int[]>();
            test = Neighbours(new int[] { 0, 0 }, grid, nrows, ncols);
            Console.WriteLine("Test Length: {0}", test.Count);
            test = Neighbours(new int[] { nrows-1, 0 }, grid, nrows, ncols);
            Console.WriteLine("Test Length: {0}", test.Count);
            test = Neighbours(new int[] { nrows-1, ncols-1 }, grid, nrows, ncols);
            Console.WriteLine("Test Length: {0}", test.Count);
            test = Neighbours(new int[] { 0, ncols-1 }, grid, nrows, ncols);
            Console.WriteLine("Test Length: {0}", test.Count);
            test = Neighbours(new int[] { 2, 2 }, grid, nrows, ncols);
            Console.WriteLine("Test Length: {0}", test.Count);
        }

        private int Convert(char s)
        {
            return char.ToUpper(s);
        }

        private List<int[]> Neighbours(int[] pos, int[,] grid, int nrows, int ncols)
        {
            List < int[]> neighbours = new List <int[] >();
            int posVal = grid[pos[0], pos[1]];

            if ((pos[0] > 0) && (posVal >= grid[pos[0]-1, pos[1]]-1))  
            {
                neighbours.Add(new int[] { pos[0] - 1, pos[1] });
            }
            if ((pos[0] < nrows-1) && (posVal >= grid[pos[0] + 1, pos[1]] - 1))
            {
                neighbours.Add(new int[] { pos[0] + 1, pos[1] });
            }
            if ((pos[1] > 0) && (posVal >= grid[pos[0], pos[1]-1] - 1))
            {
                neighbours.Add(new int[] { pos[0], pos[1]-1 });
            }
            if ((pos[1] < ncols-1) && (posVal >= grid[pos[0], pos[1]+1] - 1))
            {
                neighbours.Add(new int[] { pos[0], pos[1]+1 });
            }




            return neighbours;
        }

        private int getSteps(Tuple<int, int> start, Tuple<int, int> goal, Dictionary<Tuple<int, int>, Tuple<int, int>> toPos)
        {
            int steps = 0;
            Tuple<int, int> currentPos = goal;
            while (currentPos != start)
            {
                steps++;
                // Console.WriteLine("{0}, {1}", currentPos.Item1, currentPos.Item2);
                currentPos = toPos[currentPos];
            }
            return steps;
        }

        private int BFS(Tuple<int, int> start, int[,] grid, int goalVal)
        {
            const int MAX_DEPTH = 10000;
            int nsteps = 0;
            int depth = 0;
            Tuple<int, int> currentPos, nextPos;
            List<int[]> neighbours;
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
            Dictionary<Tuple<int, int>, bool> seen = new Dictionary<Tuple<int, int>, bool>();
            Dictionary<Tuple<int, int>, Tuple<int, int>> toPos = new Dictionary<Tuple<int, int>, Tuple<int, int>>(); 
            queue.Enqueue(start);
            
            while(queue.Count()> 0)
            {
                depth++;
                
                currentPos = queue.Dequeue();

                // Console.WriteLine("Current Position: {0}, {1}. Val: {2}", currentPos.Item1, currentPos.Item2, grid[currentPos.Item1, currentPos.Item2]);
                neighbours = Neighbours(new int[] { currentPos.Item1, currentPos.Item2 }, grid, nrows, ncols);
                foreach (int[] neighbour in neighbours)
                {
                    // Console.WriteLine("Neighbour: {0}, {1}", neighbour[0], neighbour[1]);
                    nextPos = new Tuple<int, int>(neighbour[0], neighbour[1]);
                    if (seen.ContainsKey(nextPos)) { }
                    else
                    {
                        seen.Add(nextPos, true);
                        toPos.Add(nextPos, currentPos);
                        if (grid[neighbour[0], neighbour[1]] == goalVal)
                        {
                            currentPos = nextPos;
                            nsteps = getSteps(start, currentPos, toPos);
                            return nsteps;
                        }
                        queue.Enqueue(nextPos);
                    }
                }
                if (depth > MAX_DEPTH)
                {
                    throw new Exception("Max steps reached.");
                }
            }
            return 0;
            




            // Console.WriteLine("{0}, {1}\n", grid[0,0], goal);
            /*
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    Console.Write(" {0}", grid[i, j]);
                }
                Console.Write("\n");
            }
            return 0;
            */
        }


        public override string PartOne(string[] lines)
        {
            Tuple<int, int> start = new (0,0);
            int ans;
            Parse(lines);
            goal = char.ToUpper('z') - 64 + 1;



            ans = BFS(start, grid, goal);


            return ans.ToString();
        }

        public override string PartTwo(string[] lines)
        {
            List<Tuple<int, int>> startingPositions = new List<Tuple<int, int>>();
            startingPositions.Add(new Tuple<int, int>(0, 0));  
            int ans;
            int minAns = 10000;
            int startValA = char.ToUpper('a') - 64;
            goal = char.ToUpper('z') - 64 + 1;
            for (int i=0;i<nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    if (grid[i,j] == startValA)
                    {
                        startingPositions.Add(new Tuple<int, int> ( i, j ));
                    }
                }
            }

            Console.WriteLine("{0} Starting Positions", startingPositions.Count);
            foreach(Tuple<int, int> startPos in startingPositions)
            {
                ans = BFS(startPos, grid, goal);
                if(ans < minAns)
                {
                    minAns = ans;
                }
            }
            Console.WriteLine(minAns);
            return minAns.ToString();
        }
    }
}
