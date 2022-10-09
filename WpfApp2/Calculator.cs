﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Calculator
    {
        public string Starter(string numbers)
        {
            Calculator pr = new Calculator();
            string result = pr.Math(numbers);
            while (true)
            {
                float n;
                if (float.TryParse(result, out n))
                {
                    break;
                }
                if (!result.Contains('-') && !result.Contains('*') && !result.Contains('/') && !result.Contains('+'))
                {
                    break;
                }
                result = pr.Math(result);
            }
            return result;
        }
        public string Math(string numbers)
        {
            float[] otveti = new float[100];
            if (numbers.Contains('('))
            {
                numbers = Skobka(numbers);
                return numbers;
            }
            if (numbers.Contains('*'))
            {
                numbers = Umnojenie(otveti, numbers.IndexOf('*'), numbers);
                return numbers;
            }
            if (numbers.Contains('/'))
            {
                numbers = Delenie(otveti, numbers.IndexOf('/'), numbers);
                return numbers;
            }
            if (numbers.Contains('+'))
            {
                numbers = Slojenie(otveti, numbers.IndexOf('+'), numbers);
                return numbers;
            }
            for(int i=0; i<numbers.Length; i++)
            {
                if (!Char.IsNumber(numbers[i]) && numbers[i] != '-' && numbers[i] != ',')
                {
                    break;
                }
                if (numbers[i] == '-' && i != 0)
                {
                    numbers = Vichitanie(otveti, i, numbers);
                    return numbers;
                }
            }
            return numbers;
        }
        public string Skobka(string numbers)
        {
            int startSS;
            int lastSS;
            string skobochka;
            int lenth;
            for(int i = numbers.IndexOf('(')+1; i < numbers.Length; i++)
            {
                if(numbers[i] == '(')
                {
                    startSS = i;
                    lastSS = numbers.IndexOf(')');
                    lenth = lastSS - startSS;
                    skobochka = numbers.Substring(startSS + 1, lenth - 1);
                    float n;
                    while (true)
                    {
                        if (skobochka.Contains('*') || skobochka.Contains('/') || skobochka.Contains('+') || skobochka.Contains('-'))
                        {
                            skobochka = Math(skobochka);
                        }
                        if (float.TryParse(skobochka, out n))
                        {
                            break;
                        }
                        if (!skobochka.Contains('*') && !skobochka.Contains('/') && !skobochka.Contains('+') && !skobochka.Contains('-'))
                        {
                            break;
                        }
                    }
                    numbers = numbers.Replace(numbers.Substring(startSS, lenth + 1), skobochka);
                    break;
                }
                if(i == numbers.Length - 1)
                {
                    startSS = numbers.IndexOf('(');
                    lastSS = numbers.IndexOf(')');
                    lenth = lastSS - startSS;
                    skobochka = numbers.Substring(startSS + 1, lenth - 1);
                    float n;
                    while (true)
                    {
                        if (skobochka.Contains('*') || skobochka.Contains('/') || skobochka.Contains('+') || skobochka.Contains('-'))
                        {
                            skobochka = Math(skobochka);
                        }
                        if (float.TryParse(skobochka, out n))
                        {
                            break;
                        }
                        if (!skobochka.Contains('*') && !skobochka.Contains('/') && !skobochka.Contains('+') && !skobochka.Contains('-'))
                        {
                            break;
                        }
                    }
                    numbers = numbers.Replace(numbers.Substring(startSS, lenth + 1), skobochka);
                }    
            }
                return numbers;
        }
        public float[] Viroshenie(int charID, string numbers)
        {
            string temp = "";
            string temp1 = "";
            float indexReplaceStart = 0;
            float indexReplaceLast = 0;
            float number1 = 0;
            float number2 = 0;
            bool check;
            for (int i = charID - 1; i >= 0; i--)
            {
                check = Char.IsNumber(numbers[i]);
                if (check == true)
                {
                    temp = Char.ToString(numbers[i]);
                    temp1 = temp + temp1;
                }
                if (numbers[i] == ',')
                {
                    check = true;
                    temp1 = ',' + temp1;
                }
                if (check == false || i == 0)
                {
                    if ((numbers[i] == '-' && i == 0) || (numbers[i] == '-' && !Char.IsNumber(numbers[i-1])))
                    {
                        temp1 = '-' + temp1;
                        indexReplaceStart = i;
                        number1 = float.Parse(temp1);
                        break;
                    }
                indexReplaceStart = i + 1;
                    if (i == 0)
                    {
                        indexReplaceStart = i;
                    }
                    number1 = float.Parse(temp1);
                    break;
                }
            }
            temp1 = "";
            if (numbers[charID + 1] == '-')
            {
                temp1 = "-";
                charID = charID + 1;
            }
            for (int i = charID + 1; i < numbers.Length; i++)
            {
                check = Char.IsNumber(numbers[i]);
                if (check == true)
                {
                    temp = Char.ToString(numbers[i]);
                    temp1 = temp + temp1;
                }
                if (numbers[i] == ',')
                {
                    check = true;
                    temp1 = ',' + temp1;
                }
                if (check == false || i == numbers.Length - 1)
                {
                    indexReplaceLast = i;
                    if (i == numbers.Length - 1)
                    {
                        indexReplaceLast = i + 1;
                    }
                    char[] c = temp1.ToCharArray();
                    Array.Reverse(c);
                    temp1 = new string(c);
                    number2 = float.Parse(temp1);
                    break;
                }
            }
            float[] otveti = new float[4];
            otveti[0] = number1;
            otveti[1] = number2;
            otveti[2] = indexReplaceStart;
            otveti[3] = indexReplaceLast;
            return otveti;
        }
        public string Umnojenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] * otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public string Delenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] / otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public string Slojenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] + otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public string Vichitanie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] - otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
    }
}
