using System;

namespace AsyncProgramming.Demo01
{
    class Program
    {
        static void Main(string[] args)
        {

            // Some Tricks for working with console


            // Q) Where Console write "Hello World" ? Is in terminal screen?

            // No, The program can't write directly to screen.
            // Default Behavior: It writes in  STDOUT file
            // to override this behavior run the console app from terminal command Prompt as following
            // // 1- cd to path od project : cd D:\Learning_Repos\C#_Async_Programming_by_Rainer_Stropek\AsyncProgramming\AsyncProgramming.Demo01
            // // 2- run the cmd: >dotnet run > myfile.exe          // this will redirect STDOUT 


         
            Console.WriteLine("Hello World!");


            // Try the following find command: >dotnet run | find "World"
            // // this will do the following:
            ////// - dotnet run will write in STDOUT
            /////  - find will read from STDIN


            // Try: >dotnet run <  myfile.exe
            var l = Console.ReadLine();


            // Try: >echo "Hello World" | dotnet run

        }
    }
}
