using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp
{
    public class Player
    {
        public int Id { get; private set; }
        public int StartingAmount { get; private set; }
        public int CurrentAmount { get; private set; }
        private Random rand = new Random();

        public bool IsActive => CurrentAmount > 0;

        public Player(int id, int startingAmount)
        {
            Id = id;
            StartingAmount = startingAmount;
            CurrentAmount = startingAmount;
        }

        public void MakeBet()
        {
            if (CurrentAmount <= 0) return;

            int betAmount = 0;

            int minBet = 10;
            int maxBet = Math.Min(CurrentAmount, 100);

            if (CurrentAmount < minBet)
            {
                betAmount = CurrentAmount;
            }
            else
            {
                betAmount = rand.Next(minBet, maxBet + 1);
            }

            int winningNumber = rand.Next(0, 37);

            int betNumber = rand.Next(0, 37);

            Console.WriteLine($"Игрок {Id} ставит {betAmount} на число {betNumber}");

            int rouletteResult = rand.Next(0, 37);
            Console.WriteLine($"Выпало число: {rouletteResult}");

            if (rouletteResult == betNumber)
            {
                CurrentAmount += betAmount;
                Console.WriteLine($"Игрок {Id} выиграл! Текущая сумма: {CurrentAmount}");
            }
            else
            {
                CurrentAmount -= betAmount;
                Console.WriteLine($"Игрок {Id} проиграл! Текущая сумма: {CurrentAmount}");
            }
        }
    }
}
