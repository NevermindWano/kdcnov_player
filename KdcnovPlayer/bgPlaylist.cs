using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kdcnovAutoWinForms
{
    class BgPlaylist
    {
        public string folderPath { get; set; }
        public List<string> tracks { get; set; }
        public List<int> midiNotes { get; set; }
        public List<int> oscTracks { get; set; }

        private DataProvider.Data options = new DataProvider.Data();
        

        public BgPlaylist(string folderPath)
        {
            if (folderPath == null || folderPath == "")
                return;

            this.folderPath = folderPath;
            string[] fileNames = Directory.GetFiles(folderPath, "*.mp3", SearchOption.TopDirectoryOnly);

            tracks = new List<string>();
            foreach (string filename in fileNames)
            {
                tracks.Add(filename);
            }

            try
            {
                midiNotes = options.Read<string[]>("bgMidiNotes").Select(int.Parse).ToList();
            }
            catch { }
            try
            {
                oscTracks = options.Read<string[]>("bgOscTracks").Select(int.Parse).ToList();
            } catch { }
            options.Dispose();
        }
    }
}
