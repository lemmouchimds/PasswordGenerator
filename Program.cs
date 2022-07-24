using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = string.Empty;

            Console.WriteLine("do you want a fix string in the begginig ?");
            var respond = Console.ReadLine().ToLower();

            if (string.Equals(respond, "yes"))
            {
                Console.WriteLine("give me the prefix : ");
                var prefix = Console.ReadLine();
                output += prefix;
            }

            PasswordGenerator a = new PasswordGenerator();
            output += a.GenerateFromLists(13, PwModes.Digits | PwModes.Alpha | PwModes.Symbols);
            Console.WriteLine("this is your password : " + output);
        }

    }

    [Flags]
    public enum PwModes
    {
        None = 0x00,
        Alpha = 0x01,
        Digits = 0x02,
        Symbols = 0x04
    }

}
