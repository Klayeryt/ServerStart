using ServerStart;
using System.Diagnostics;
using System.Net;
class Program
{
    checkcn check = new checkcn();
    static void Main(string[] args)
    {

        String info = "info";
        String quest = "";
        String update = "update";
        String yes = "yes";
        String exit = "exit";
        String command = "";
        String startserver = "=0startserver";
        String no = "no";
        string password = "123456";
        string u_password = "";
        Console.Write("Ввидите пароль: ");
        u_password = Console.ReadLine();
        if (u_password == password)
        {
            goto Doing;
        }
        else
        {
            Console.WriteLine("Неправльный пароль!");
            Environment.Exit(0);
        }
    Doing:
        Console.WriteLine("Ввидите действие: ");
        quest = Console.ReadLine();
    Start:
        if (quest == yes)
        {
            Console.Write("Имя файла который нужно запустить:");
            string filename = Console.ReadLine();
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c node -i";
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
            stdin.WriteLine(".load " + filename);
            stdin.Flush();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Версия nodejs: 17.3.1");
            Console.WriteLine("Сервер успешно запущен!");
            p.WaitForExit();
            p.Close();
        }
        else if (quest == no)
        {
            Console.WriteLine("Жду ваших команд!");
            command = Console.ReadLine();
            if(command == startserver)
            {
                quest = yes;
                goto Start;
            }
            else if (command == exit)
            {
                Environment.Exit(0);
            }
            else if (command == info)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Приложение было разработано в практических намериниях создатель - Klayeryt\n" + "Версия приложения - v1.0.1\n" + "Пренадлежит компании SCARFⒸ︎");
                Console.ReadLine();
                goto Start;
            }
            else if (command == update)
            {
                String Filelink = "http://localhost/download/node-v16.16.0-x64.msi";
                String Filename = "node-v16.16.0-x64.msi";
                Console.WriteLine("Проверяю подключение...");
                checkcn.Testsite(Filelink);
                Console.WriteLine("Закачиваю...");
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c node";
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
                stdin.WriteLine(".load modules//upgrade.js");
                stdin.Flush();
                Console.ForegroundColor = ConsoleColor.Green;
                p.WaitForExit();
                p.Close();
                System.Diagnostics.Process.Start(Filename);
                Console.ReadLine();
            }
        };

    }
}