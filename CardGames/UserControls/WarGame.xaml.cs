using CardGames.GameControllers;
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

        public bool IsPvP { get; set; }
        public WarController controller { get; set; }
        public WarGame()
        {
            InitializeComponent();
        }

        public WarGame(String player1)
        {
            IsPvP = false;
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = "Computer";
            controller = new WarController();
        }

        public WarGame(String player1, String player2)
        {
            IsPvP = true;
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = player2;
            controller = new WarController();
        }


        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            controller.Draw();
            string card1 = controller.Player1.FlippedCard.FaceValue.ToString() + controller.Player1.FlippedCard.FaceSuit.ToString();
            string card2 = controller.Player2.FlippedCard.FaceValue.ToString() + controller.Player2.FlippedCard.FaceSuit.ToString();
            Player1Card.Content = card1;
            Player2Card.Content = card2;
        }
    }
}
