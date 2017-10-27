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
        public GoFishSetupMenu(MainWindow window)
        {
                Window = window;
                InitializeComponent();
        }

        private void PlayerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayerNameArea.Children.Clear();
            for (int i = 0; i < PlayerComboBox.SelectedIndex + 2; i++)
            {
                StackPanel s = new StackPanel();
                s.Orientation = Orientation.Horizontal;
                Label l = new Label();
                TextBox t = new TextBox();
                l.Content = $"Player {i + 1}";
                s.Children.Add(l);
                s.Children.Add(t);
                PlayerNameArea.Children.Add(s);
            }
        }
    }
}
