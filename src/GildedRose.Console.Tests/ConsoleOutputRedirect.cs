using System;
using System.IO;

namespace GildedRose.Tests;

/// <summary>
/// this class gets the output of a console from a specific program and puts it into a stringwriter for later review within a test for example
/// </summary>
public class ConsoleOutputRedirect : IDisposable
{
    private StringWriter stringWriter;
    private TextWriter originalOutput;

    public ConsoleOutputRedirect()
    {
        stringWriter = new StringWriter();
        originalOutput = System.Console.Out;
        System.Console.SetOut(stringWriter);
    }

    public string GetOutput()
    {
        return stringWriter.ToString();
    }

    public void Dispose()
    {
        stringWriter.Dispose();
        System.Console.SetOut(originalOutput);
    }
}