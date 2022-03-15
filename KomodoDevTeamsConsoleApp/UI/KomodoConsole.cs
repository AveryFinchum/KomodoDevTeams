using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamsConsoleApp.UI
{
    internal class KomodoConsole
    {
        internal class RealConsole : IConsole
        {

            private string komodoSplash = "  _  __                         _         _____ | |/ /                        | |       | _   _ |                                          | ' / ___  _ __ ___   ___   __| | ___     | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___  |  < / _ \\| '_ ` _ \\ / _ \\ / _` |/ _ \\    | | | '_ \\/ __| | | | '__ / _` | '_ \\ / __/ _ \\ | . \\ (_) | | | | | | (_) | (_| | (_) |  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/ |_|\\_\\___/|_| |_| |_|\\___/ \\__,_|\\___/  |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___|";
            public void Clear()
            {
                Console.Clear();
                drawSplash();
                Thread.Sleep(500);
                Console.Clear();
            }

            private void drawSplash()
            {
                foreach (char l in komodoSplash) { Thread.Sleep(3); Console.Write(l); }
            }
            public void startUp()
            {
                drawSplash();
            }

            private void shutDown()
            {
                drawSplash();
                Console.Write("Goodbye!");
                Thread.Sleep(500);
            }
            public ConsoleKeyInfo ReadKey()
            {
                return Console.ReadKey();
            }

            public bool BoolQuestion(string question)
            {
                Console.WriteLine($"{question} /n/'Y/' or /'N/' ...");

                ConsoleKeyInfo result = Console.ReadKey(false);
                Thread.Sleep(250);
                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Write(string s)
            {
                Console.Write(s);
            }

            public void WriteLine(string s)
            {
                Console.WriteLine(s);
            }

            public void WriteLine(object o)
            {
                Console.WriteLine(o);
            }

            public void WriteLine()
            {
                Console.WriteLine();
            }

            public string ReadLine()
            {
                throw new NotImplementedException();
            }
        }
    }
}
