using GildedRose.Application;

namespace GildedRose.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var q = new QualityUpdater();
        System.Console.WriteLine(q.RunTheProgram());
    }
}