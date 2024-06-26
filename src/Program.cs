using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class ToListComparison
{
    [Params(100, 1000, 10000)]
    public int N;

    [Benchmark]
    public void ListConstructor()
    {
        List<int> numbers = new List<int>(Enumerable.Range(1, N));
    }

    [Benchmark]
    public void ToListTest()
    {
        List<int> numbers = Enumerable.Range(1, N).ToList();
    }


    [Benchmark]
    public void SpreadTest()
    {
        List<int> numbers = [.. Enumerable.Range(1, N)];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ToListComparison>();
    }
}