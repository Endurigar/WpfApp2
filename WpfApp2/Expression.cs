using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2
{
    internal class Expression
    {
        private float firstNumber;
        private float secondNumber;
        private int startExpIndex;
        private int endExpIndex;

        public float FirstNumber { get => firstNumber; }
        public float SecondNumber { get => secondNumber; }
        public int StartExpIndex { get => startExpIndex; }
        public int EndExpIndex { get => endExpIndex; }

        internal Expression(float number1,float number2,int startIndex,int endIndex)
        {
            firstNumber = number1;
            secondNumber = number2;
            startExpIndex = startIndex;
            endExpIndex = endIndex;
        }
    }
}
