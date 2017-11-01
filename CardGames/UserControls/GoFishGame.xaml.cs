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
            SetUpPlayerPositions();
            //Maybe loop for pairs, found pair remove found pair remove
        }

        private void SetUpPlayerPositions()
        {
            Binding a = new Binding("Name");
            a.Source = Game.Players[0];
            BottomHand.SetBinding(Button.ContentProperty, a);

            switch (Game.Players.Count())
            {
                case 2:
                    TopHand.Visibility = Visibility.Visible;
                    Binding b = new Binding("Name");
                    b.Source = Game.Players[1];
                    TopHand.SetBinding(Button.ContentProperty, b);
                    break;
                case 3:
                    LeftHand.Visibility = Visibility.Visible;
                    Binding c = new Binding("Name");
                    c.Source = Game.Players[1];
                    LeftHand.SetBinding(Button.ContentProperty, c);
                    RightHand.Visibility = Visibility.Visible;
                    Binding c2 = new Binding("Name");
                    c2.Source = Game.Players[2];
                    RightHand.SetBinding(Button.ContentProperty, c2);
                    break;
                case 4:
                    LeftHand.Visibility = Visibility.Visible;
                    Binding d = new Binding("Name");
                    d.Source = Game.Players[1];
                    LeftHand.SetBinding(Button.ContentProperty, d);
                    TopHand.Visibility = Visibility.Visible;
                    Binding d2 = new Binding("Name");
                    d2.Source = Game.Players[2];
                    TopHand.SetBinding(Button.ContentProperty, d2);
                    RightHand.Visibility = Visibility.Visible;
                    Binding d3 = new Binding("Name");
                    d3.Source = Game.Players[3];
                    RightHand.SetBinding(Button.ContentProperty, d3);
                    break;
            }
        }

        private void TopHand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftHand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightHand_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
