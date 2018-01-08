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

            var tagClip     = new OSCState_clip();
            var tagTrack    = new OSCState_track();
            var tagCustom = new OSCState_custom();

            ResolumeTRACK.Tag = oscUpDown.Tag = tagTrack;
            ResolumeCLIP.Tag = clipUpDown.Tag = layerUpDown.Tag = tagClip;
            customOSCCommand.Tag = customOSCTextBox.Tag = tagCustom;

            this.track = track;
            this.form = form;

            nameTextBox.Text = track.name;
            bpmUpDown.Value = track.bpm;
            oscUpDown.Value = track.oscCommand;
            clipUpDown.Value = track.oscClip;
            layerUpDown.Value = track.oscLayer;
            customOSCTextBox.Text = track.oscCustom;

            RadioButton checkedButton =  OSCBox.Controls.OfType<RadioButton>()
                                   .Where(r => r.Tag == track.mode)
                                   .FirstOrDefault();

            if (checkedButton != null)
                checkedButton.Checked =  true;

            setRadios(OSCBox);

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
            setRadios(midiGroupBox);

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

            // Сохраняем настройки osc.
            saveOSC();


            // Сохраняем настройки midi
            track.isMidiNote = (getCheckedButton(midiGroupBox) == midiFileRadio) ? false : true;
            track.midiNote = (int)midiUpDown.Value;
            track.midiFile = midiFileTextBox.Text;
            track.bg = (mainRadioButton.Checked) ? false : true;
            form.FillListView();

            if (Proccess.mainPlayList.namePlaylist == null || Proccess.mainPlayList.namePlaylist == "")
                form.SaveAsMenuItem_Click(sender, e);
            else
                Proccess.mainPlayList.Save(Proccess.mainPlayList.namePlaylist);
            Close();
        }

        private void saveOSC()
        {
            track.oscCommand = (int)oscUpDown.Value;
            track.oscClip = (int)clipUpDown.Value;
            track.oscLayer = (int)layerUpDown.Value;
            track.oscCustom = customOSCTextBox.Text;
            track.mode = (ITrackOSCState)getCheckedButton(OSCBox).Tag;
        }

        private void sendMidiButton_Click(object sender, EventArgs e)
        {
            NAudioMidi.Send((int)midiUpDown.Value);
        }

        private void oscSendButton_Click(object sender, EventArgs e)
        {
            saveOSC();
            var checkedButton = (ITrackOSCState)getCheckedButton(OSCBox).Tag;
            checkedButton.Send(track);                                         

        }

        private void midiNoteRadio_CheckedChanged(object sender, EventArgs e)
        {
            setRadios(midiGroupBox);
        }

        private void midiFileRadio_CheckedChanged(object sender, EventArgs e)
        {
            setRadios(midiGroupBox);
        }

        private void midiFileTextBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                midiFileTextBox.Text = ofd.FileName;
            }
        }

        private void ResolumeTRACK_CheckedChanged(object sender, EventArgs e)
        {
            setRadios(OSCBox);
        }

        private void ResolumeCLIP_CheckedChanged(object sender, EventArgs e)
        {
            setRadios(OSCBox);
        }

        private void customOSCCommand_CheckedChanged(object sender, EventArgs e)
        {
            setRadios(OSCBox);
        }

        private void setRadios(GroupBox box)
        {
            RadioButton checkedButton = getCheckedButton(box);

            foreach (Control cnt in box.Controls)
            {
                if (cnt is RadioButton || cnt is Button) continue;
                if (cnt.Tag == checkedButton.Tag)
                    cnt.Enabled = true;
                else
                    cnt.Enabled = false;
            }
        }

        private RadioButton getCheckedButton(GroupBox box)
        {
            return box.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
        }
    }
}
