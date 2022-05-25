using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/c node app.js -i";
        p.StartInfo.UseShellExecute = false;

        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardInput = true;

        p.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
        p.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
        p.Start();

        p.BeginOutputReadLine();
        p.BeginErrorReadLine();

        var stdin = p.StandardInput;
        stdin.WriteLine("console.log('Server succffuel starting')");
        stdin.Flush();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Сервер успешно запущен!");
        p.WaitForExit();
        p.Close();

    }
}