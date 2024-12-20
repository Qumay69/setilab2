using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Threading.Tasks;
using setilab2;

namespace CasinoApp
{
    public partial class MainWindow : Window
    {
        private CasinoTable casinoTable; 

        public MainWindow()
        {
            InitializeComponent();
        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;

            Random rand = new Random();
            int totalPlayers = rand.Next(20, 101);
            casinoTable = new CasinoTable(totalPlayers);

            await casinoTable.StartDay();

            playersListBox.Items.Clear();
            foreach (var player in casinoTable.players)
            {
                playersListBox.Items.Add($"Игрок {player.Id} - Начальная сумма: {player.StartingAmount} | Конечная сумма: {player.CurrentAmount}");
            }

            startButton.IsEnabled = true;
        }

    }
}
