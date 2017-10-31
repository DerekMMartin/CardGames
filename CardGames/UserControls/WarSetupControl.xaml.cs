using CardGames.GameControllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardGames.UserControls
{
    /// <summary>
    /// Interaction logic for WarSetupControl.xaml
    /// </summary>
    public partial class WarSetupControl : System.Windows.Controls.UserControl
    {
        public MainWindow Window { get; set; }
        public bool IsPvP { get; set; }
        public WarSetupControl(MainWindow window)
        {
            Window = window;
            IsPvP = false;
            InitializeComponent();
        }

        private void PVPButton_Click(object sender, RoutedEventArgs e)
        {
            Player2TextBox.IsEnabled = true;
            IsPvP = true;
            PVPButton.IsEnabled = false;
            PVCButton.IsEnabled = true;
        }

        private void PVCButton_Click(object sender, RoutedEventArgs e)
        {
            Player2TextBox.IsEnabled = false;
            IsPvP = false;
            PVPButton.IsEnabled = true;
            PVCButton.IsEnabled = false;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            String player1 = Player1TextBox.Text;
            String player2 = Player2TextBox.Text;

            if(string.IsNullOrWhiteSpace(player1))
            {
                player1 = "Player 1";
            }
            if(string.IsNullOrWhiteSpace(player2) && IsPvP)
            {
                player2 = "Player 2";
            }

            Window.Root.Children.Clear();
            if(IsPvP)
            {
                Window.Root.Children.Add(new WarGame(player1, player2, Window));
            }
            else
            {
                Window.Root.Children.Add(new WarGame(player1, Window));
            }
            
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            WarController loaded= null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "War Games|*.war";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = null;
                if((stream = ofd.OpenFile()) != null)
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    loaded = (WarController)deserializer.Deserialize(stream);
                    stream.Close();
                }
            }
            if (loaded != null)
            {
                Window.Root.Children.Clear();
                Window.Root.Children.Add(new WarGame(loaded, Window));
            }
        }
    }
}
