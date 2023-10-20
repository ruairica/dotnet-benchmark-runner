using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class ExistsVsAnyListComparison
{
    public List<int> NumbersList = Enumerable.Range(0, 10_000).ToList();

    [Benchmark]
    public void Any()
    {
        this.NumbersList.Any(x => x == 9_555);
    }

    [Benchmark]
    public void Exists()
    {
        this.NumbersList.Exists(x => x == 9_555);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ExistsVsAnyListComparison>();
    }
}