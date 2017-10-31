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
    /// Interaction logic for GoFishGame.xaml
    /// </summary>
    public partial class GoFishGame : UserControl
    {

        public MainWindow Window { get; set; }
        public GoFishController Game { get; set; }
        public GoFishGame(MainWindow window, GoFishController game)
        {
            Game = game;
            Window = window;
            InitializeComponent();

            StartGame();
        }

        public void StartGame()
        {

        }





    }
}
