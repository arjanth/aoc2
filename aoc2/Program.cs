using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int min;
            int max;
            string letter;
            string password;
            string[] hak;
            char[] delimiterChars = { ' ', '-', ':' };  // was beter geweest om eerst te splitten op : om zo de policy van wachtwoord te scheiden
            bool valid;
            int validpasswordscounts=0;
            foreach (string line in File.ReadLines(@"C:\Repos\aoc2\aoc2\input\password.txt"))
            {
                
                hak = line.Split(delimiterChars);
                min = int.Parse(hak[0]);
                max = int.Parse(hak[1]);
                letter = hak[2];
                password = hak[4];

                int numberOfOccurencesOfLetterInPassword = Regex.Matches(password, letter).Count;
                valid=numberOfOccurencesOfLetterInPassword >= min && numberOfOccurencesOfLetterInPassword <= max;
                if (valid)  validpasswordscounts++;               
                Console.WriteLine($"{line} ----> {valid} ");

            }
            Console.WriteLine($"validpasswordscount volgens eerste deel= {validpasswordscounts}");

            int i;
            int j;
            char letter2;
            char[] password2;
            int validpasswordscounts2 = 0;
            foreach (string line in File.ReadLines(@"C:\Repos\aoc2\aoc2\input\password.txt"))
            {

                hak = line.Split(delimiterChars);
                i = int.Parse(hak[0])-1;
                j = int.Parse(hak[1])-1;
                letter2 = hak[2].ToCharArray()[0];
                password2 = hak[4].ToCharArray();

                
                valid = password2[i]==letter2^password2[j]==letter2 ;
                if (valid) validpasswordscounts2++;
                Console.WriteLine($"{line} ----> {valid} ");

            }
            Console.WriteLine($"validpasswordscount volgens tweede deel= {validpasswordscounts2}");

        }
    }
}
