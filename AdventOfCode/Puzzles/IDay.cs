namespace AdventOfCode
{
    public interface IDay
    {
        string InputFile { get; }

        int Part1(string[] input);
        int Part2(string[] input);
    }
}