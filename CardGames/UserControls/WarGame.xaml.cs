using CardGames.GameControllers;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardGames.UserControls
{
    /// <summary>
    /// Interaction logic for WarGame.xaml
    /// </summary>
    public partial class WarGame : UserControl
    {
        public WarController Controller { get; set; }
        public MainWindow Window { get; set; }

        public WarGame(String player1, MainWindow window)
        {
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = "Computer";
            Controller = new WarController(player1, "Computer");
            Window = window;
            UpdateLables();
        }

        public WarGame(String player1, String player2, MainWindow window)
        {
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = player2;
            Controller = new WarController(player1, player2);
            Window = window;
            UpdateLables();
        }

        public WarGame(WarController loaded, MainWindow window)
        {
            Controller = loaded;
            InitializeComponent();
            Player1Label.Content = loaded.Player1.Name;
            Player2Label.Content = loaded.Player2.Name;
            Window = window;
            UpdateLables();
        }

        private void UpdateLables()
        {
            Player1DrawLabel.Content = Controller.Player1.RemainingCards;
            Player2DrawLabel.Content = Controller.Player2.RemainingCards;
            Player1DiscardLabel.Content = Controller.Player1.NumDiscarded;
            Player2DiscardLabel.Content = Controller.Player2.NumDiscarded;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.Draw();

            if (!Controller.IsWon)
            {
                string card1 = Controller.Player1.FlippedCard.ToString();
                string card2 = Controller.Player2.FlippedCard.ToString();
                Player1Card.Content = card1;
                Player2Card.Content = card2;
                UpdateLables();
                if (Controller.IsWar)
                {
                    DrawButton.Content = "War!";
                    DrawButton.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    DrawButton.Content = "Draw!";
                    DrawButton.ClearValue(BackgroundProperty);
                }
            }
            else
            {
                DrawButton.IsEnabled = false;
                Player1Label.Content = "";
                if(Controller.LosingPlayer == Controller.Player2)
                {
                    Player2Label.Content = $"{Controller.Player1.Name} wins!";
                }
                else
                {
                    Player2Label.Content = $"{Controller.Player2.Name} wins!";
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Controller.IsWon)
            {
                Controller.SaveGame();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window.Root.Children.Clear();
            Window.Root.Children.Add(new MenuUC(Window));
        }
    }
}
