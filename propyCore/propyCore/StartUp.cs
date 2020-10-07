using System;

namespace propyCore
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.Write("Input Deposit: ");
            decimal deposit = decimal.Parse(Console.ReadLine());
            decimal bet = 0;

            //  Make class for matrix 
            FieldOfSymbols fieldOfSymbols = new FieldOfSymbols();
            
            decimal resultCoeficent = 0;

            while (deposit > 0)
            {
                Console.Clear();

                Console.Write($"Total Balance = {deposit}            Place a Bet: ");
                bet = decimal.Parse(Console.ReadLine());
                if (bet > deposit)
                {
                    bet = deposit;
                }

                Console.Clear();

                Console.WriteLine($"Total Balance = {deposit}     Bet = {bet}");

                Console.WriteLine("After SPIN:");
                // Filling the matrix with randomly generated symbols with weights and show
                fieldOfSymbols.InputSymbols();
                fieldOfSymbols.PrintMatrix();

                // returns coeficent after checking 
                resultCoeficent = fieldOfSymbols.WinOrNot();

                if (resultCoeficent == 0)
                {
                    deposit -= bet;
                    Console.WriteLine($"You loose: {bet}        Total Balance = {deposit}");
                }
                else
                {
                    deposit += bet * resultCoeficent;
                    Console.WriteLine($"You Win: {bet * resultCoeficent}        Total Balance = {deposit}");
                }

                Console.WriteLine("Press any key to continue game.");
                Console.ReadKey();
            }

            Console.WriteLine("Game Over");
        }
    }
}
