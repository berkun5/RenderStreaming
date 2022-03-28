using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class ObjectManager
{
    public static InitiatePowerShell InitiatePowerShell;
    // private static string _oldPort;

    public static string oldPort
    {
        get => NotepadPath();
    }

    // private static GameState _gameState;
    public static string exeName;
    public static FileInfo portInfo;
    
    public static string Between(string STR , string FirstString, string LastString)
    {       
        string FinalString;     
        int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
        int Pos2 = STR.IndexOf(LastString);
        FinalString = STR.Substring(Pos1, Pos2 - Pos1);
        return FinalString;
    }

    static string NotepadPath()
    {
        string port = null;

        DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\firat\\git\\RenderStreaming\\");
        FileInfo[] info = directoryInfo.GetFiles("*.txt");
        info.Select(f => f.FullName);

        string fileName = null;
        foreach (FileInfo files in info)
        {
            if (files.Name.Contains("PORT"))
            {
                fileName = files.ToString();
                port = Between(fileName, "T", ".");
            }
        }

        return "PORT" + port;
    }
}
