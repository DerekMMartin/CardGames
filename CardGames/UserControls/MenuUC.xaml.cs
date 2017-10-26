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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public MainWindow Window { get; set; }
        public MenuUC(MainWindow w)
        {
            Window = w;
            InitializeComponent();

        }

        private void BlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Root.Children.Clear();
            Window.Root.Children.Add(new BlackJackStartMenu(Window));
        }

        private void GoFishButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
