using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Audio;
using Video;
using PlaylistLib;

namespace kdcnovAutoWinForms
{
    public partial class SettingsTrack : Form
    {
        Track track;
        MainForm form;

        public SettingsTrack(Track track, MainForm form)
        {
            InitializeComponent();

            this.track = track;
            this.form = form;

            nameTextBox.Text = track.name;
            bpmUpDown.Value = track.bpm;
            oscUpDown.Value = track.oscCommand;

           // nextComboBox.DataSource = Enum.GetValues(typeof(nextTrack));

            nextComboBox.DisplayMember = "Description";
            nextComboBox.ValueMember = "Value";
            nextComboBox.DataSource = Enum.GetValues(typeof(nextTrack))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            nextComboBox.SelectedValue = track.next;

            midiFileRadio.Checked = (!track.isMidiNote) ? true : false;            
            bgRadioButton.Checked = (track.bg) ? true : false;
            setRadios();


            midiFileTextBox.Text = track.midiFile;
            midiUpDown.Value = track.midiNote;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (midiFileRadio.Checked && midiFileTextBox.Text == "")
            {
                MessageBox.Show("Вы выбрали воспроизвести миди файл, но не выбрали какой");
                return;
            }

            track.name = nameTextBox.Text;
            track.bpm = (int)bpmUpDown.Value;
            track.next = (nextTrack)nextComboBox.SelectedValue;
            track.midiNote = (int)midiUpDown.Value;
            track.oscCommand = (int)oscUpDown.Value;

            if (midiFileRadio.Checked)
                track.isMidiNote = false;
            else
                track.isMidiNote = true;

            track.midiNote = (int)midiUpDown.Value;
            track.midiFile = midiFileTextBox.Text;
            track.bg = (mainRadioButton.Checked) ? false : true;
            form.FillListView();

            if (Proccess.mainPlayList.namePlaylist == null || Proccess.mainPlayList.namePlaylist == "")
                form.SaveAsMenuItem_Click(sender, e);
            else
              Proccess.mainPlayList.Save(form.playlistFileName);
            Close();
        }

        private void sendMidiButton_Click(object sender, EventArgs e)
        {
            NAudioMidi.Send((int)midiUpDown.Value);
        }

        private void oscSendButton_Click(object sender, EventArgs e)
        {
            OSC.OnTrack((int)oscUpDown.Value);
        }

        private void midiNoteRadio_CheckedChanged(object sender, EventArgs e)
        {
            setRadios();
        }

        private void setRadios()
        {
            if (midiNoteRadio.Checked)
            {
                midiFileTextBox.Enabled = false;
                midiUpDown.Enabled = true;
            }
            if (midiFileRadio.Checked)
            {
                midiUpDown.Enabled = false;
                midiFileTextBox.Enabled = true;
            }
        }

        private void midiFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            setRadios();
        }

        private void midiFileTextBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                midiFileTextBox.Text = ofd.FileName;
            }
        }
    }
}
