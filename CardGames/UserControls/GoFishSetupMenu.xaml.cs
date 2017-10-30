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
    /// Interaction logic for GoFishSetupMenu.xaml
    /// </summary>
    public partial class GoFishSetupMenu : UserControl
    {
        public MainWindow Window { get; set; }

        public List<GoFishPlayer> Players { get; set; }
        public GoFishSetupMenu(MainWindow window)
        {
            Players = new List<GoFishPlayer>();
                Window = window;
                InitializeComponent();
        }

        private void PlayerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerNameArea.Children.Clear();
            for (int i = 0; i < PlayerComboBox.SelectedIndex + 2; i++)
            {
                StackPanel s = new StackPanel();
                s.Background = Brushes.AliceBlue;
                s.Orientation = Orientation.Horizontal;
                Label l = new Label();
                TextBox t = new TextBox();
                t.Width = 100;
                t.Name = $"Player{i + 1}TextBox";
                l.Content = $"Player {i + 1}";
                s.Children.Add(l);
                s.Children.Add(t);
                PlayerNameArea.Children.Add(s);
            }

            //Button b = new Button();
            //b.Content = "Enter";
            //PlayerNameArea.Children.Add(b);
            EnterButton.Visibility = Visibility.Visible;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerComboBox.Visibility = Visibility.Visible;
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Root.Children.Clear();
            Window.Root.Children.Add(new GoFishGame(Window, Players));
        }
    }
}
