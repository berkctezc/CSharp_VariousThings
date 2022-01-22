using System;

namespace XUnitDemo_ClassLibrary;

public static class Examples
{
    public static string ExampleLoadTextFile(string file)
    {
        if (file.Length < 10)
            throw new ArgumentException("The file name was too short", nameof(file));
        //throw new System.IO.FileNotFoundException();

        return "The file was correctly loaded.";
    }
}