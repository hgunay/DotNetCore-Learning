using System;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                var customerName = args[0];
                var editorName = "VS Code";

                Console.WriteLine($"Hello {customerName}! This is {editorName}.");    
            }
            else 
            {
                Console.WriteLine("Hello Developer!");
            }            
        }
    }
}