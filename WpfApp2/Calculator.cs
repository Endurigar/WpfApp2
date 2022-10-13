using System;
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
            string result = Math(numbers);
            return result;
        }
        public string Math(string numbers)
        {


            if (!numbers.Contains('*') && !numbers.Contains('/') && !numbers.Contains('+'))
            {
                if (float.TryParse(numbers, out var temp))
                {
                    return numbers;
                }
            }

            if (numbers.Contains('('))
            {
                numbers = InBrackets(numbers);

            }
            if (numbers.Contains('*') || numbers.Contains('/'))
                for (int i = 0; i < numbers.Length; i++)
                {
                    bool isSymbol = !Char.IsNumber(numbers[i]);
                    if (isSymbol)
                    {
                        if (i < numbers.Length && numbers[i] == '*')
                        {
                            numbers = MathAction(MathActionType.Mul, i, numbers);
                            continue;
                        }
                        if (i < numbers.Length && numbers[i] == '/')
                        {
                            numbers = MathAction(MathActionType.Div, i, numbers);
                            continue;
                        }
                    }
                }
            if (numbers.Contains('+') || numbers.Contains('-'))
                for (int i = 0; i < numbers.Length; i++)
                {
                    bool isSymbol = !Char.IsNumber(numbers[i]);
                    if (isSymbol)
                    {
                        if (i < numbers.Length && numbers[i] == '+')
                        {
                            numbers = MathAction(MathActionType.Add, i, numbers);
                            continue;
                        }
                        if (i != 0 && numbers[i] == '-')
                        {
                            numbers = MathAction(MathActionType.Sub, i, numbers);
                            continue;
                        }

                    }
                }
            if (numbers.Contains('*') || numbers.Contains('/') || numbers.Contains('+') || numbers.Contains('-'))
            {
                numbers = Math(numbers);
            }
            return numbers;
        }
        public string InBrackets(string numbers)
        {
            string result = string.Empty;
            int bracketStartIndex = numbers.IndexOf('(');
            int bracketEndIndex = 0;
            int bracketInCounter = 0, bracketOutCounter = 0;
            for (int i = bracketStartIndex; i < numbers.Length; i++)
            {
                if (numbers[i] == '(') bracketInCounter++;
                if (numbers[i] == ')')
                {
                    bracketOutCounter++;
                    if (bracketInCounter == bracketOutCounter)
                    {
                        bracketEndIndex = i;
                        break;
                    }
                }
            }
            string expressionInBrackets = numbers.Substring(bracketStartIndex + 1, bracketEndIndex - bracketStartIndex - 1);
            result = numbers.Replace(numbers.Substring(bracketStartIndex, bracketEndIndex - bracketStartIndex + 1), Math(expressionInBrackets));
            return result;
        }
        public Expression GetExpression(int charID, string numbers)
        {

            string firstNumberString = string.Empty;
            string secondNumberString = string.Empty;
            int indexReplaceStart = 0;
            int indexReplaceLast = 0;
            float number1 = 0;
            float number2 = 0;

            for (int i = charID - 1; i >= 0; i--)
            {
                var currentChar = numbers[i];
                var isNumber = Char.IsNumber(currentChar);
                var isComma = currentChar == ',';
                var isMinus = currentChar == '-' && i == 0 || currentChar == '-' && !Char.IsNumber(numbers[i - 1]);
                if (isNumber || isComma || isMinus)
                {
                    firstNumberString += currentChar;
                    indexReplaceStart = i;
                }

                else if (i == 0)
                {
                    indexReplaceStart = i;

                    break;
                }
                else if (!isNumber)
                {
                    indexReplaceStart = i + 1;
                    break;
                }

            }

            for (int i = charID + 1; i < numbers.Length; i++)
            {
                var currentChar = numbers[i];
                var isNumber = Char.IsNumber(currentChar);
                var isComma = currentChar == ',';
                var isMinus = numbers[i] == '-' && secondNumberString == string.Empty;

                if (isNumber || isComma || isMinus)
                {
                    secondNumberString += currentChar;
                    indexReplaceLast = i;
                }
                else if (!isNumber)
                {
                    break;
                }
                else if (i == numbers.Length - 1)
                {
                    indexReplaceLast = i;
                }

            }
            firstNumberString = ReverseString(firstNumberString);
            number1 = float.Parse(firstNumberString);
            number2 = float.Parse(secondNumberString);
            return new Expression(number1, number2, indexReplaceStart, indexReplaceLast);
        }
        public string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string MathAction(MathActionType type, int charID, string numbers)
        {
            var tempExpression = GetExpression(charID, numbers);
            int length = tempExpression.EndExpIndex - tempExpression.StartExpIndex + 1;
            int start = tempExpression.StartExpIndex;
            float result = 0;
            switch (type)
            {
                case MathActionType.Add: result = tempExpression.FirstNumber + tempExpression.SecondNumber; break;
                case MathActionType.Sub: result = tempExpression.FirstNumber - tempExpression.SecondNumber; break;
                case MathActionType.Mul: result = tempExpression.FirstNumber * tempExpression.SecondNumber; break;
                case MathActionType.Div: result = tempExpression.FirstNumber / tempExpression.SecondNumber; break;
            }

            string tempString = numbers.Substring(start, length);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
    }
    enum MathActionType
    {
        Add,
        Sub,
        Mul,
        Div
    }
}
