using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            ListyIterator<string> names = null;

            while ((command = Console.ReadLine())!= "END")
            {
                var tokens = command.Split();

                if (tokens[0] == "Create")
                {
                    names = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if(tokens[0] == "Move")
                {
                    Console.WriteLine(names.Move());
                }
                else if (tokens[0] == "Print")
                {
                    try
                    {
                        names.Print();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        throw;
                    }
                    names.Print();
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(names.HasNext());
                }
            }
        }
    }
}
