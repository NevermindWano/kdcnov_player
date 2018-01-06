using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataProvider;
using System.Runtime.InteropServices;
using Audio;
using PlaylistLib;
using clserlib;

namespace kdcnovAutoWinForms
{

    public partial class Settings : Form
    {

        private string mainTrackPath = "";
        private MainForm form;
        private Data options;

        public Settings(MainForm form)
        {
            InitializeComponent();

            this.form = form;
            this.options = new Data();

            getDefaultPlayer();
            getMidiDevices();
            getOSCSettings();
            getBgSettings();
            getFonts();
            readColors();
        }

        private void getBgSettings()
        {
            if (Proccess.bgPlaylist != null)
            {
                if (Proccess.bgPlaylist.folderPath != null)
                    folderPathBox.Text = Proccess.bgPlaylist.folderPath;
                if (Proccess.bgPlaylist.midiNotes != null)
                    listToListView(midiListView, Proccess.bgPlaylist.midiNotes);

                if (Proccess.bgPlaylist.oscTracks != null)
                    listToListView(oscListView, Proccess.bgPlaylist.oscTracks);
            }


            if (Proccess.bgMain.audioFilePath != null)
            {
                mainTrackTextBox.Text = Proccess.bgMain.audioFilePath;
                mainTrackOSCUpDown.Value = Proccess.bgMain.oscCommand;
                mainTrackMIdi.Value = Proccess.bgMain.midiNote;
            }

            volumeUpDown.Value = options.Read<int>("bgVolume");
        }

        private void getMidiDevices()
        {
            foreach (KeyValuePair<int, string> device in NAudioMidi.GetDevices())
            {
                midiDeviceComboBox.Items.Insert(device.Key, device.Value);
            }
            try { midiDeviceComboBox.SelectedIndex = options.Read<int>("midiDeviceNo"); }
            catch { }
        }

        private void getDefaultPlayer()
        {
            if (options.Read<string>("defaultPlayer") != null)
            {
                switch (options.Read<string>("defaultPlayer"))
                {
                    case "naudio":
                        naudioRadioButton.Checked = true;
                        break;
                    case "aimp":
                        aimpRadioButton.Checked = true;
                        break;
                }
            }
        }

        private void listToListView(ListView listView, List<int> list)
        {
            foreach (int item in list)
            {
                addToList(item.ToString(), listView);
            }
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] fileList = Directory.GetFiles(fbd.SelectedPath, "*.mp3", SearchOption.TopDirectoryOnly);

                Proccess.bgPlaylist = new BgPlaylist(fbd.SelectedPath) { folderPath = fbd.SelectedPath };

                folderPathBox.Text = fbd.SelectedPath;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (naudioRadioButton.Checked)
                options.Save("defaultPlayer", "naudio");
            if (aimpRadioButton.Checked)
                options.Save("defaultPlayer", "aimp");

            options.Save("midiDeviceNo", midiDeviceComboBox.SelectedIndex);

            saveBgSettings();
            saveOSCSettings();
            saveColors();
            saveFonts();
            form.InitColors();
            form.FillListView();
            Proccess.Init();
            Close();
        }

        private void saveBgSettings()
        {
            options.Save("bgMidiNotes", getListViewsParams(midiListView));
            options.Save("bgOscTracks", getListViewsParams(oscListView));

            options.Save("bgVolume", (int)volumeUpDown.Value);

            // Фоновый плейлист
            options.Save("bgPlaylistFolder", folderPathBox.Text);

            Proccess.bgMain = new Track(true)
            {
                audioFilePath = mainTrackTextBox.Text,
                midiNote = (int)mainTrackMIdi.Value,
                oscCommand = (int)mainTrackOSCUpDown.Value
            };

            options.Save("mainTrackPath", mainTrackTextBox.Text);
            options.Save("mainMidiNote", (int)mainTrackMIdi.Value);
            options.Save("mainTrackOsc", (int)mainTrackOSCUpDown.Value);
        }

        private void saveOSCSettings()
        {
            options.Save("oscIP", ipTextBox.Text);
            options.Save("oscPORT", (int)portUpDown.Value);
        }      

        private void getOSCSettings()
        {
            ipTextBox.Text = Proccess.ip;
            portUpDown.Value = Proccess.port;
        }

        private string[] getListViewsParams(ListView list)
        {
            string[] tags = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++)
            {
                tags[i] = list.Items[i].Text;
            }

            return tags;
        }

        private void mainTrackButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mainTrackPath = ofd.FileName;
                mainTrackTextBox.Text = ofd.FileName;
            }
        }

        private void addMidiButton_Click(object sender, EventArgs e)
        {
            addToList(midiUpDown.Value.ToString(), midiListView);
        }

        private void oscAddButton_Click(object sender, EventArgs e)
        {
            addToList(oscUpDown.Value.ToString(), oscListView);
        }

        private void midiListView_MouseClick(object sender, MouseEventArgs e)
        {
            listItemRemove(e, midiListView);
        }

        private void oscListView_MouseClick(object sender, MouseEventArgs e)
        {
            listItemRemove(e, oscListView);
        }

        private void listItemRemove(MouseEventArgs e, ListView list)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (list.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    list.SelectedItems[0].Remove();
                    // contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void addToList(string value, ListView list)
        {
            string[] items = new string[3];
            items[0] = value;
            ListViewItem item = new ListViewItem(items)
            {
                Tag = value
            };
            list.Items.Add(item);
        }

        #region COLORS and FONTS

        private void saveColors()
        {
            Colors.Set("nextButtonColor", nextTrackColorButton.BackColor);
            Colors.Set("stopButtonColor", stopColorButton.BackColor);
            Colors.Set("nextTrackColor", nextTrackColor.BackColor);
            Colors.Set("concreteBgColor", concreteBgColor.BackColor);
            Colors.Set("bgTrackFontColor", bgTrackFontColor.BackColor);
            Colors.SaveToRegistry();
        }


        private void readColors()
        {
            nextTrackColorButton.BackColor = Colors.Get("nextButtonColor");
            stopColorButton.BackColor = Colors.Get("stopButtonColor");
            nextTrackColor.BackColor = Colors.Get("nextTrackColor");
            concreteBgColor.BackColor = Colors.Get("concreteBgColor");
            bgTrackFontColor.BackColor = Colors.Get("bgTrackFontColor");
        }

        private void nextTrackColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            nextTrackColorButton.BackColor = colorDialog1.Color;
        }

        private void stopColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            stopColorButton.BackColor = colorDialog1.Color;
        }

        private void nextTrackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            nextTrackColor.BackColor = colorDialog1.Color;
        }

        private void concreteBgColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            concreteBgColor.BackColor = colorDialog1.Color;
        }


        private void bgTrackFontColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            bgTrackFontColor.BackColor = colorDialog1.Color;
        }

        private void saveFonts()
        {
            Fonts.Set("mainFont", mainFontTextBox.Font);
            Fonts.Set("bgFont", bgFontTextBox.Font);
            Fonts.SaveToRegistry();
        }

        private void getFonts()
        {
            Font mainFont = Fonts.Get("mainFont");
            mainFontTextBox.Text = (mainFont != null) ? mainFont.Name : "";
            mainFontTextBox.Font = mainFont ?? mainFontTextBox.Font;

            Font bgFont = Fonts.Get("bgFont");
            bgFontTextBox.Text = (bgFont != null) ? bgFont.Name : "";
            bgFontTextBox.Font = bgFont ?? bgFontTextBox.Font;
        }
        #endregion

        private void mainFontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            mainFontTextBox.Text = fontDialog.Font.Name;
            mainFontTextBox.Font = fontDialog.Font;
        }

        private void bgFontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            bgFontTextBox.Text = fontDialog.Font.Name;
            bgFontTextBox.Font = fontDialog.Font;
        }

        ~Settings()
        {
            form.Dispose();
            form = null;

            options.Dispose();
            options = null;
        }
    }
}
