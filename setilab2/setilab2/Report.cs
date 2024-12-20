using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace CasinoApp
{
    public static class Report
    {
        public static void SaveReport(List<Player> players)
        {
            List<string> report = new List<string>();

            foreach (var player in players)
            {
                report.Add($"Игрок {player.Id} - Начальная сумма: {player.StartingAmount}, Конечная сумма: {player.CurrentAmount}");
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Текущая рабочая директория: {currentDirectory}");

            string reportPath = Path.Combine(currentDirectory, "CasinoReport.txt");
            File.WriteAllLines(reportPath, report);
            Console.WriteLine($"Отчет сохранен по пути: {reportPath}");
        }
    }
}