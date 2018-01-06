using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using kdcnovAutoWinForms;
using DataProvider;
using Audio;
using Scenario;
using PlaylistLib;

namespace kdcnovAutoWinForms
{
    public delegate void statusHandler(int code, string name = null);

    public partial class MainForm : Form
    {
        internal string playlistFileName;
        private int codeStatus;

        public MainForm()
        {

            InitializeComponent();

            // Инициализация цветовой схемы
            InitColors();

            InitFonts();

            // Получаем из реестра путь к файлу плейлиста, и если 
            // такой путь получен - открываем плейлист
            Data readSettings = new Data();
            playlistFileName = readSettings.Read<string>("playlistFilePath");

            if (playlistFileName != null && playlistFileName != "")
            {
                openPlaylist();
                FillListView();
                listTracks.Items[0].Selected = true;
            }
            else
                createPlaylist();

            // Подключение контекстного меню к списку треков
            listTracks.ContextMenuStrip = contextMenuStrip1;

            // Слушатель событий
            statusEvents();

        }
        /// <summary>
        /// Инициализация цветовой схемы
        /// </summary>
        internal void InitColors()
        {
            readColors();
            setColors();
        }

        internal void InitFonts()
        {
            Fonts.ReadFromRegistry();
        }

        /// <summary>
        /// Заполнение списка треков
        /// </summary>
        internal void FillListView()
        {
            listTracks.Items.Clear();
            string[] items = new string[8];

            bool isPrev = false;

            int key = 1;

            foreach (KeyValuePair<int, Track> track in Proccess.mainPlayList.tracks)
            {
                if (HideBgTrack.Checked && track.Value.bg) continue;
                // Номер трека по порядку
                items[0] = key.ToString();
                // Имя трека
                items[1] = track.Value.name;
                // Длительность трека
                items[2] = NAudioPlayer.GetDuration(track.Value.audioFilePath);
                // Номер OSC трека
                items[3] = track.Value.oscCommand.ToString();
                // MIDI - нота или MIDI - файл
                items[4] = (track.Value.isMidiNote) ? track.Value.midiNote.ToString() : track.Value.midiFile;

                /// Получает описание из enum
                #region GetEnumDescripton
                var enumType = typeof(nextTrack);
                var memberData = enumType.GetMember(track.Value.next.ToString());
                var Description = (memberData[0].GetCustomAttributes(typeof(DescriptionAttribute),
    false).FirstOrDefault() as DescriptionAttribute).Description;
                #endregion

                items[5] = Description.ToString();

                // Ставим метку, что трек находится в плейлисте
                track.Value.isPlaylistTrack = true;

                // Тегом элемента ListView является объект трека
                ListViewItem item = new ListViewItem(items)
                { Tag = track.Value };

                /// --------- УПРАВЛЕНИЕ ЦВЕТОМ ----------------
                #region COLOR AND FONTS MANAGED


                // Если предыдущий трек с параметром "ИГРАТЬ СЛЕД. ТРЕК",
                // то текущий трек выделяем тем же цветом и шрифтами
                if (isPrev)
                {
                    isPrev = false;
                    item.BackColor = Colors.Get("nextTrackColor");
                }

                switch (track.Value.next)
                {
                    case nextTrack.next:
                        item.BackColor = Colors.Get("nextTrackColor");
                        isPrev = true;
                        break;
                    case nextTrack.pause:
                        item.BackColor = (isPrev) ? Colors.Get("nextTrackColor") : Color.Pink;
                        break;
                    case nextTrack.bgConcrete:
                        item.BackColor = (isPrev) ? Colors.Get("nextTrackColor") : Colors.Get("concreteBgColor");
                        break;
                }


                if (Fonts.Get("mainFont") != null)
                    item.Font = Fonts.Get("mainFont");

                if (Fonts.Get("bgFont") != null)
                    item.Font = (track.Value.bg) ? Fonts.Get("bgFont") : item.Font;

                if (Colors.Get("bgTrackFontColor") != null)
                    item.ForeColor = (track.Value.bg) ? Colors.Get("bgTrackFontColor") : item.ForeColor;

                #endregion

                // добавляем элемент в ListView
                listTracks.Items.Add(item);
                key++;
            }
        }

        /// <summary>
        /// Рункт меню "Сохранить как"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savePlaylist = new SaveFileDialog()
            {
                Filter = "Playlist file (*.pls)|*.pls"
            };

            if (savePlaylist.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = savePlaylist.FileName;

            Proccess.mainPlayList.Save(filename);
            new Data().Save("playlistFilePath", filename);
        }

        /// <summary>
        /// Пункт меню "Открыть плейлист"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPlaylistItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPlaylistFile = new OpenFileDialog
            {
                Filter = "Playlist File (*.pls)|*.pls"
            }; 

            if (openPlaylistFile.ShowDialog() == DialogResult.Cancel)
                return;

            playlistFileName = openPlaylistFile.FileName;

            openPlaylist();

            new Data().Save("playlistFilePath", playlistFileName);
        }

        /// <summary>
        /// Открывает плейлист
        /// </summary>
        private void openPlaylist()
        {
            try
            {
                Proccess.mainPlayList = Playlist.Open(playlistFileName);

                if (Proccess.mainPlayList != null)
                {
                    Proccess.mainPlayList.namePlaylist = playlistFileName;
                    FillListView();
                }
            }
            catch
            {
                MessageBox.Show("Плейлист не найден! откройте файл плейлиста или создайте новый", "Файл плейлиста не найден!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                createPlaylist();
            }

        }

        private void createMenuItem_Click(object sender, EventArgs e)
        {
            createPlaylist();
        }

        private void createPlaylist()
        {
            DialogResult result = MessageBox.Show("Сформировать плейлист из файлов в папке? Иначе создаётся пустой плейлист", "Создать плейлист", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] fileList = Directory.GetFiles(fbd.SelectedPath, "*.mp3", SearchOption.TopDirectoryOnly);

                    Proccess.mainPlayList = new Playlist(fileList);

                    FillListView();
                }
            }
            else
            {
                Proccess.mainPlayList = new Playlist();
                FillListView();
            }
        }

        /// <summary>
        /// Открывает контекстное меню в списке треков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTracks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listTracks.FocusedItem.Bounds.Contains(e.Location) == true)
                    contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void настроитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var selectedItem = (Track)listTracks.SelectedItems[0].Tag;

            SettingsTrack settings = new SettingsTrack(selectedItem, this);
            settings.Show();           
        }

        private void savePlaylistItem_Click(object sender, EventArgs e)
        {
            if (Proccess.mainPlayList.namePlaylist == null || Proccess.mainPlayList.namePlaylist == "")
            {
                SaveAsMenuItem_Click(sender, e);
                return;
            }
            Proccess.mainPlayList.Save(playlistFileName);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            int selected = 0;
            try
            {
                selected = listTracks.SelectedItems[0].Index;
            }catch { MessageBox.Show("Выберите трек для воспроизведения", "НЕ ВЫБРАН ТРЕК", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            Track track = (Track)listTracks.SelectedItems[0].Tag;
            Proccess.Play(track, selected);
            selectCurrentTrack();
            listTracks.Select();

        }

        private void stopButton_Click(object sender, EventArgs e)
        {

            if (Proccess.currentTrack != null && !Proccess.currentTrack.bg)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите остановить трек?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Proccess.Stop();
                return;
            }
            Proccess.Stop();

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }

        /// <summary>
        /// Статус воспроизведения транслируется в statusBar
        /// </summary>
        private void statusEvents()
        {
            Proccess.status += (int code, string name) =>
            {
                switch (code)
                {
                    case Proccess.STOP:
                        statusLabel.Text = "ОСТАНОВЛЕНО";
                        statusLabel.ForeColor = Color.DarkRed;
                        trackStatusLabel.Visible = false;
                        break;
                    case Proccess.PLAY_MAIN_TRACK:
                        statusLabel.Text = "ИГРАЕТ ОСНОВНОЙ ТРЕК";
                        trackStatusLabel.Text = name;
                        trackStatusLabel.Visible = true;
                        statusLabel.ForeColor = Color.Green;
                        selectCurrentTrack();
                        break;
                    case Proccess.PLAY_BG_TRACK:
                        statusLabel.Text = "ИГРАЕТ ФОНОВЫЙ ТРЕК";
                        trackStatusLabel.Text = name;
                        trackStatusLabel.Visible = true;
                        statusLabel.ForeColor = Color.BlueViolet;
                        break;
                    case Proccess.TRACK_STOPPED:
                        selectCurrentTrack();
                        break;
                    default:
                        statusLabel.Text = "ПАУЗА";
                        break;
                }
                codeStatus = code;

            };
        }

        #region ListViewDragAndDrop
        private void listTracks_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Begins a drag-and-drop operation in the ListView
            listTracks.DoDragDrop(listTracks.SelectedItems, DragDropEffects.Move);
        }

        private void listTracks_DragEnter(object sender, DragEventArgs e)
        {


            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
                return;
            }

            int len = e.Data.GetFormats().Length - 1; int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void listTracks_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null)
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".wav")
                    {
                        Proccess.mainPlayList.Add(file);
                        FillListView();
                    }
                    else MessageBox.Show("Данный тип фалйа не поддерживается. Добавьте файл mp3 или wav", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (Proccess.player.GetState() == 1)
                return;
            
            //Return if the items are not selected in the ListView 
            if (listTracks.SelectedItems.Count==0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = listTracks.PointToClient(new Point(e.X, e.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = listTracks.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[listTracks.SelectedItems.Count];
            for (int i = 0; i <= listTracks.SelectedItems.Count - 1; i++)
            {
                sel[i] = listTracks.SelectedItems[i];
            }
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                //Obtain the ListViewItem to be dragged to the target location.
                ListViewItem dragItem = sel[i];
                int itemIndex = dragIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = dragIndex + i;
                //Insert the item at the mouse pointer.
                ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                listTracks.Items.Insert(itemIndex, insertItem);
                //Removes the item from the initial location while 
                //the item is moved to the new location.
                listTracks.Items.Remove(dragItem);
            }

            Proccess.mainPlayList.Reorder(listTracks.Items);
            FillListView();
        }
        #endregion

        private void listTracks_ItemActivate(object sender, EventArgs e)
        {
            Proccess.currentKey = listTracks.SelectedItems[0].Index;
        }

        private void настройкиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }

        private void addFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Music files (*.mp3;*.wav)|*.mp3;*.wav|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            Proccess.mainPlayList.Add(ofd.FileName);

            FillListView();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected = listTracks.SelectedItems[0].Index;
            listTracks.SelectedItems[0].Remove();
            Proccess.mainPlayList.Remove(selected);
            Proccess.mainPlayList.Reorder(listTracks.Items);
            FillListView();
        }

        private void listTracks_MouseLeave(object sender, EventArgs e)
        {
            if (Proccess.player.GetState() == 1 && currentTrackCheckBox.Checked)
                selectCurrentTrack();
        }

        private void selectCurrentTrack()
        {
            if (Proccess.currentKey < listTracks.Items.Count)
                listTracks.Items[Proccess.currentKey].Selected = true;
        }

        private void hideBgTrack_CheckedChanged(object sender, EventArgs e)
        {
            FillListView();
        }

        /// <summary>
        /// Читает все пареметры из реестра, которые связаны с цветами
        /// </summary>
        private void readColors()
        {
            Colors.ReadFromRegistry();
        }

        /// <summary>
        /// Устанавливает нужные цвета на элементы
        /// </summary>
        private void setColors()
        {
            Colors.SetBackColor<Button>(playButton, "nextButtonColor");
            Colors.SetBackColor<Button>(stopButton, "stopButtonColor");
        }


        private void добавитьСценарийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Word files (*.docx;*.doc)|*.docx;*.doc|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            // TEST
            List<string> test = ScenarioReader.ReadDocx(ofd.FileName);
            string[] items = new string[8];
            foreach (string stroka in test)
            {
                addStringToScenarioList(items, stroka);
            }
        }

        private void trimString(string[] items, string stroka)
        {

        }

        private void addStringToScenarioList(string[] items, string stroka)
        {
            items[0] = stroka;
            ListViewItem item = new ListViewItem(items);
            scenarioList.Items.Add(item);
        }

        private void listTracks_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = (Track)listTracks.SelectedItems[0].Tag;

            SettingsTrack settings = new SettingsTrack(selectedItem, this);
            settings.Show();
        }
    }
}
