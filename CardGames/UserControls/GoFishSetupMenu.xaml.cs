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
    /// Interaction logic for GoFishSetupMenu.xaml
    /// </summary>
    public partial class GoFishSetupMenu : UserControl
    {
        public MainWindow Window { get; set; }

        public List<string> PlayerNames { get; set; }

        public List<TextBox> TextBoxes { get; set; }

        public int NumPlayers { get; set; }
        public GoFishSetupMenu(MainWindow window)
        {
                Window = window;
                InitializeComponent();
        }

        private void PlayerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerNames = new List<string>();
            TextBoxes = new List<TextBox>();
            PlayerNameArea.Children.Clear();
            NumPlayers = PlayerComboBox.SelectedIndex + 2;
            for (int i = 0; i < PlayerComboBox.SelectedIndex + 2; i++)
            {
                StackPanel s = new StackPanel();
                s.Background = Brushes.AliceBlue;
                s.Orientation = Orientation.Horizontal;
                s.Margin = new Thickness(20, 0, 20, 0);
                Label l = new Label();
                TextBox t = new TextBox();
                t.Width = 100;
                TextBoxes.Add(t);
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
            for (int i = 0; i < NumPlayers; i++)
            {
                string text = TextBoxes[i].Text;
                if(string.IsNullOrEmpty(text))
                {
                    text = $"Player {i + 1}";
                }
                PlayerNames.Add(text);
            }
            GoFishController g = new GoFishController(NumPlayers, PlayerNames);
            Window.Root.Children.Clear();
            Window.Root.Children.Add(new GoFishGame(Window, g));
        }
    }
}
