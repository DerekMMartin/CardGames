using CardGames.UserControls;
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

namespace CardGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            Root.Children.Clear();
            Root.Children.Add(new BlackJackStartMenu());
        }

        private void GoFishButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
