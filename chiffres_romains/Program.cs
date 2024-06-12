using System;
using System.Data;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        Dictionary<char, int> numeros = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
        string entry1;
        String check = "yes";
        while (true)
        {
            Console.WriteLine("Enter roman number: ");
            entry1 = Console.ReadLine();
            bool stch = false;
            while (!(stch))
            {
                check = IsRomanRegEx(entry1);
                if (check == "yes")
                {
                    stch = true;
                }
                else
                {
                    Console.WriteLine("not a roman number. try again");
                    Console.WriteLine("Enter roman number: ");
                    entry1 = Console.ReadLine();
                    stch = false;
                }
            }
            int i = 0;
            int num = 0;
            int l = entry1.Length;
            while (i < l)
            {
                if ((i + 1) < l && numeros[entry1[i]] < numeros[entry1[i + 1]]) // I placé avant V, X placé avant L ou C place devant D
                {
                    num = num + (numeros[entry1[i + 1]] - numeros[entry1[i]]);
                    i = i + 2;
                }
                else
                {
                    num = num + numeros[entry1[i]];
                    i = i + 1;
                }
            }
            string arabNumber = num.ToString();
            Console.WriteLine("Arab number: " + arabNumber);
        }


    }
    public static string IsRomanRegEx(string entry) 
    {
        string pattern = @"^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        bool isMatch = Regex.IsMatch(entry, pattern);
        string check = "yes";
        if (isMatch == false) 
        {
            check = "no";
        }
        else 
        {
            check = "yes";
        }
        return check;
    }
    public static string IsRoman(string entry1) // probleme logic union/intersection d'ensembles
    {
        char[] lettres = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        char[] romans = entry1.ToCharArray();
        Dictionary<char, int> charCountRomans = new Dictionary<char, int>();
        foreach (char r in romans)
        {
            if (charCountRomans.ContainsKey(r))
            {
                charCountRomans[r]++;
            }
            else
            {
                charCountRomans[r] = 1;
            }
        }
        string check = "yes";
        
        foreach (char c in lettres)
        {
            if (!charCountRomans.ContainsKey(c))
            {
                check = "no";
                break;
            }
        }

        return check;
    }
        // string[] combis = {"DC"};
        // string[] except = { "IV", "XL","CD","CM"};
        
}