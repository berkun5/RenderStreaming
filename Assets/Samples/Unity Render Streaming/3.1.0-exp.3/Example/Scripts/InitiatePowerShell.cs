using UnityEngine;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

public class InitiatePowerShell : MonoBehaviour
{
    //   private string oldPort = "oldPort";

    //   public string exeName = "localhost";

    private void Awake()
    {
        ObjectManager.InitiatePowerShell = this;
    }

    public void RunPowerShell(string port)
    {
        string webPath = "C:\\Users\\firat\\git\\RenderStreaming";
        string webCommand = webPath + "./webserver -w -p" + port;
        Process.Start("webserver.exe", webCommand);


        FileInfo portInfo = new FileInfo($"C:\\Users\\firat\\git\\RenderStreaming\\{ObjectManager.oldPort}.txt");
        File.Move(portInfo.Name, $"PORT{port}.txt");

        Process.Start("unityBuild.exe");
    }
}
