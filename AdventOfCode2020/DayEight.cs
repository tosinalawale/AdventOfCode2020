namespace AdventOfCode2020
{
    using System.Linq;

    public class DayEight
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var program = new MyProgram(input);
            program.Run();
            return program.Accumulator;
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            var instructionList = input.ToList();
            var instructionToAlter = instructionList.FindIndex(i => i.StartsWith("nop") || i.StartsWith("jmp"));

            while (instructionToAlter >= 0)
            {
                AlterInstruction(input, instructionToAlter);
                var program = new MyProgram(input);
                var programEndedSuccessfully = program.Run();

                if (programEndedSuccessfully)
                {
                    return program.Accumulator;
                }

                // change altered instruction back
                AlterInstruction(input, instructionToAlter);

                // alter next nop or jmp instruction
                instructionToAlter = instructionList.FindIndex(
                    ++instructionToAlter,
                    i => i.StartsWith("nop") || i.StartsWith("jmp"));
            }

            return int.MinValue;
        }

        private static void AlterInstruction(string[] instructionList, int instructionToAlter)
        {
            if (instructionList[instructionToAlter].StartsWith("nop"))
            {
                instructionList[instructionToAlter] = instructionList[instructionToAlter].Replace("nop", "jmp");
            }
            else
            {
                instructionList[instructionToAlter] = instructionList[instructionToAlter].Replace("jmp", "nop");
            }
        }
    }

    internal class MyProgram
    {
        public int Accumulator { get; set; }

        private readonly string[] instructions;
        private readonly int[] visited;
        private int pointer = 0;
        private int orderOfVisit = 0;

        public MyProgram(string[] instructions)
        {
            this.instructions = instructions;
            this.visited = new int[instructions.Length];
        }

        public bool Run()
        {
            while (pointer < instructions.Length)
            {
                if (visited[pointer] == 0)
                {
                    visited[pointer] = ++orderOfVisit;
                }
                else
                {
                    return false;
                }

                var instructionParts = instructions[pointer].Split(" ");
                var operation = instructionParts[0];
                var argument = short.Parse(instructionParts[1]);

                if (operation.Equals("acc"))
                {
                    Accumulator += argument;
                }
                else if (operation.Equals("jmp"))
                {
                    pointer += argument;
                    continue;
                }

                pointer++;
            }

            return true;
        } 
    }
}
