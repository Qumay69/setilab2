using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using setilab2;

namespace CasinoApp
{
    public class CasinoTable
    {
        public List<Player> players { get; private set; } = new List<Player>();
        private readonly Random rand = new Random(); 
        private int totalPlayers;

        public CasinoTable(int totalPlayers)
        {
            this.totalPlayers = totalPlayers;
        }

        public async Task StartDay()
        {
            List<Task> playerTasks = new List<Task>();
            List<string> report = new List<string>();

            for (int i = 0; i < totalPlayers; i++)
            {

                Player newPlayer = new Player(i + 1, rand.Next(100, 500));
                players.Add(newPlayer);

                playerTasks.Add(Task.Run(async () =>
                {
                    Console.WriteLine($"Игрок {newPlayer.Id} с начальной суммой {newPlayer.StartingAmount}");

                    while (newPlayer.IsActive)
                    {
                        newPlayer.MakeBet();
                        await Task.Delay(10);
                    }

                    Console.WriteLine($"Игрок {newPlayer.Id} закончил с суммой {newPlayer.CurrentAmount}");
                    report.Add($"Игрок {newPlayer.Id} - Начальная сумма: {newPlayer.StartingAmount}, Конечная сумма: {newPlayer.CurrentAmount}");
                }));
            }

            await Task.WhenAll(playerTasks);

            System.IO.File.WriteAllLines("CasinoReport.txt", report);
            Console.WriteLine("День завершен. Отчет сохранен в файл CasinoReport.txt.");
        }
    }
}
