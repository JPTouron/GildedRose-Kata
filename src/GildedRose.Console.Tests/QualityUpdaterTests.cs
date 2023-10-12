using System.IO;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests;

public class QualityUpdaterTests
{
    private QualityUpdater qualityUpdater;

    public QualityUpdaterTests()
    {
        qualityUpdater = new QualityUpdater();
    }

    [Fact]
    public void WhenExecuted_ThenMustReturnExpectedOutput()
    {
        //act
        var actualConsoleOutput = qualityUpdater.RunTheProgram();

        //assert
        //we'll use approval testing techinque to verify the state with super minimum changes in productive code
        string expectedConsoleOutput = GetExpectedConsoleOutput();
        Assert.Contains(expectedConsoleOutput, actualConsoleOutput);
    }

    private static string GetExpectedConsoleOutput()
    {
        //we ran the productive code once, and we took note of the output within this file,
        //and we accept it as the valid result, from there, we just contrast results against it to know if it's ok or not
        //info: https://approvaltests.com/
        //info: https://en.wikipedia.org/wiki/Acceptance_testing
        var filePath = "ProgramValidResult.txt";

        var expectedFileContents = File.ReadAllText(filePath);
        return expectedFileContents;
    }
}
