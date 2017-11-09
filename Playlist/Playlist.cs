using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.ListView;

namespace PlaylistLib
{
    [Serializable]
    public class Playlist
    {
        public Dictionary<int, Track> tracks = new Dictionary<int, Track>();
        public string namePlaylist {get; set;}

        public Playlist() { }

        public Playlist(string[] fileNames)
        {
            Create(fileNames);
        }

        public void Create(string[] fileNames)
        {
            int id = 0;

            tracks = new Dictionary<int, Track>();

            foreach (string file in fileNames)
            {
                Add(file);
                id++;
            }
        }

        public void Add(string file)
        {
            tracks[tracks.Count] = new Track()
            {
                audioFilePath = file,
                name = file.Remove(0, file.LastIndexOf('\\') + 1),
                next = nextTrack.bgRandom,
                isPlaylistTrack = true
            };
        }

        public void Save(string filename)
        {
            try
            {
                // создаем объект BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                   formatter.Serialize(fs, this);
                }

                namePlaylist = filename;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Remove(int key)
        {
            tracks.Remove(key);
        }

        public void Reorder(ListViewItemCollection items)
        {
            tracks.Clear();
            int id = 0;
            foreach (ListViewItem item in items)
            {
                tracks[id] = (Track)item.Tag;
                id++;                
            }
        }

        static public Playlist Open(string filename)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    return (Playlist)formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Какая-то херня с отрытием плейлиста: " + e.Message);
                return null;
            }
        }
    }
}
