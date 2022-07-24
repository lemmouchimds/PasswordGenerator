using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {

        const int minimumLength = 12;
        //readonly List<char> alphaList = new List<char>();
        //readonly List<char> digitList = new List<char>();
        //readonly List<char> symboleList = new List<char>();

        Dictionary<PwModes, List<char>> dictionary = new Dictionary<PwModes, List<char>>();

        public PasswordGenerator()
        {
            GenerateLists();
        }
        public string Generate(int length = minimumLength)
        {
            if (length < minimumLength)
                return null;

            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int rand = random.Next('!', 'z');
                result.Append((char)rand);
            }


            return result.ToString();
        }

        void GenerateLists()
        {
            var alphaList = new List<char>();
            var digitList = new List<char>();
            var symboleList = new List<char>();

            for (char i = '!'; i <= 'z'; i++)
            {
                if (char.IsLetter((char)i))
                {
                    alphaList.Add((char)i);
                }
                else if (char.IsDigit((char)i))
                {
                    digitList.Add((char)i);
                }
                else
                {
                    symboleList.Add((char)i);
                }
            }

            dictionary.Add(PwModes.Alpha, alphaList);
            dictionary.Add(PwModes.Digits, digitList);
            dictionary.Add(PwModes.Symbols, symboleList);
        }


        public string GenerateFromLists(int length, PwModes pwMode)
        {
            if (pwMode == PwModes.None)
                return null;
                       

            StringBuilder result = new StringBuilder();

            List<char> MyList = new List<char>();

            foreach (var element in dictionary)
            {
                if((pwMode & element.Key) == element.Key)
                    MyList.AddRange(element.Value);
            }



            /*

            if ((pwMode & PwModes.Alpha) == PwModes.Alpha)
            {
              //  MyList.AddRange(alphaList);

                foreach (var v in alphaList)
                {
                    MyList.Add(v);
                }
            }

            if ((pwMode & PwModes.Digits) == PwModes.Digits)
            {
                foreach (var v in digitList)
                {
                    MyList.Add(v);
                }
            }

            if ((pwMode & PwModes.Symbols) == PwModes.Symbols)
            {
                foreach (var v in symboleList)
                {
                    MyList.Add(v);
                }
            }
            */
            Random rand = new Random();
            int max = MyList.Count;

            for (int i = 0; i < length; i++)
            {
                int pwInt = rand.Next(max);
                char pwChar = MyList[pwInt];
                result = result.Append(pwChar);
            }

            return result.ToString();

        }

    }
}
