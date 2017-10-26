using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for BlackJackStartMenu.xaml
    /// </summary>
    public partial class BlackJackStartMenu : UserControl
    {
        public MainWindow Window { get; set; }
        public BlackJackStartMenu(MainWindow window)
        {
            Window = window;
            InitializeComponent();
        }

        private void PlayerCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerNames.Children.Clear();
            for(int i = 0; i < PlayerCount.SelectedIndex+1; i++)
            {
                StackPanel s = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                Label l = new Label()
                {
                    Content = $"Player {i+1}"
                };
                TextBox t = new TextBox()
                {
                    MinWidth = 100,
                    
                };
                s.Children.Add(l);
                s.Children.Add(t);
                PlayerNames.Children.Add(s);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string[] names = new string[PlayerNames.Children.Count];
            for(int i = 0; i < PlayerNames.Children.Count;i++)
            {
                StackPanel s = (StackPanel)PlayerNames.Children[i];
                TextBox t = (TextBox)s.Children[1];
                names[i] = t.Text;
            }




            Window.Root.Children.Clear();
            Window.Root.Children.Add(new BlackJackGame(Window,names));
        }
    }
}
