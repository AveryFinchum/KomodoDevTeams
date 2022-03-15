using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamsConsoleApp.UI
{
    internal interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void WriteLine();
        void Write(string s);
        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();


    }
}
