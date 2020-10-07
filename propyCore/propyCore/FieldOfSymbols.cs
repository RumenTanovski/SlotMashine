using System;
using System.Threading;

namespace propyCore
{
    public class FieldOfSymbols
    {
        private char[][] fieldOfSymbols;

        public FieldOfSymbols()
        {
            this.fieldOfSymbols = new char[4][];
        }

        public decimal WinOrNot()
        {
            decimal result = 0;

            bool isEqual = false;

            for (int row = 0; row < fieldOfSymbols.Length; row++)
            {
                char a = fieldOfSymbols[row][0];
                char b = fieldOfSymbols[row][1];
                char c = fieldOfSymbols[row][2];

                if ((a == b && b == c) || (a == '*' && b == c) || (a == c && b == '*') || (a == b && c == '*'
                    || (a == '*' && b == '*') || (a == '*' && c == '*')|| (b == '*' && c == '*')))
                {
                    isEqual = true;
                }

                if (isEqual)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var symbolCurrent = fieldOfSymbols[row][i];
                        if (symbolCurrent == 'A')
                        {
                            result += (decimal)0.2;
                        }
                        else if (symbolCurrent == 'B')
                        {
                            result += (decimal)0.4;
                        }
                        else if (symbolCurrent == 'P')
                        {
                            result += (decimal)0.6;
                        }
                    }
                }
                isEqual = false;

            }
            return result;
        }

        public void PrintMatrix()
        {
            for (int row = 0; row < fieldOfSymbols.Length; row++)
            {
                char[] currentRow = fieldOfSymbols[row];

                Console.WriteLine(string.Join(" ", currentRow));
            }
        }

        public void InputSymbols()
        {
            for (int row = 0; row < fieldOfSymbols.Length; row++)
            {
                char[] currentRow = ReturnRow();

                fieldOfSymbols[row] = currentRow;
            }
        }

        public char[] ReturnRow()
        {
            char[] row = new char[3];
            for (int i = 0; i < 3; i++)
            {
                row[i] = SelectSymbol();
            }

            return row;
        }

        public char SelectSymbol()
        {
            char symbol;

            Random randGen = new Random();

            int pA = 45;
            int pB = 35;
            int pP = 15;

            //this is important
            int milliseconds = 15;
            Thread.Sleep(milliseconds);

            int r = randGen.Next(1, 100);

            if (r <= pA)
            {
                symbol = 'A';
            }
            else if (r <= (pA + pB))
            {
                symbol = 'B';
            }
            else if (r <= (pA + pB + pP))
            {
                symbol = 'P';
            }
            else
            {
                symbol = '*';
            }
            return symbol;
        }

    }
}