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
        public List<GoFishPlayer> Players { get; set; }
        public GoFishGame(MainWindow window, List<GoFishPlayer> players)
        {
            Players = players;
            Window = window;
            InitializeComponent();
        }
    }
}
