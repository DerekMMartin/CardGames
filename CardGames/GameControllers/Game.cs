using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGames.GameControllers
{
    [Serializable]
    public abstract class Game
    {
        public List<Player> Players { get; set; }
        public Deck GDeck { get; set; }
        public virtual string FileExtension { get; protected set; }
        public virtual string GameName { get; protected set; }

        public void SaveGame()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = $"{GameName}|*.{FileExtension}";
            sfd.Title = "Save your game";
            sfd.ShowDialog();

            if(sfd.FileName != "")
            {
                FileStream fs = (FileStream)sfd.OpenFile();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
            }
        }
    }
}
