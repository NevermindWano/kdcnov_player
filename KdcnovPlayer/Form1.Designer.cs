namespace kdcnovAutoWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TrackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Midi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listTracks = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Next = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.playlistMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlaylistItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСценарийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.настроитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stopButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HideBgTrack = new System.Windows.Forms.CheckBox();
            this.currentTrackCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scenarioList = new System.Windows.Forms.ListView();
            this.textColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trackColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrackName
            // 
            this.TrackName.Text = "Название";
            this.TrackName.Width = 214;
            // 
            // Duration
            // 
            this.Duration.Text = "Длительность";
            this.Duration.Width = 74;
            // 
            // OSC
            // 
            this.OSC.Text = "OSC";
            // 
            // Midi
            // 
            this.Midi.Text = "MIDI";
            // 
            // listTracks
            // 
            this.listTracks.AllowDrop = true;
            this.listTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.TrackName,
            this.Duration,
            this.OSC,
            this.Midi,
            this.Next});
            this.listTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTracks.FullRowSelect = true;
            this.listTracks.HideSelection = false;
            this.listTracks.Location = new System.Drawing.Point(3, 3);
            this.listTracks.MultiSelect = false;
            this.listTracks.Name = "listTracks";
            this.listTracks.ShowItemToolTips = true;
            this.listTracks.Size = new System.Drawing.Size(666, 395);
            this.listTracks.TabIndex = 0;
            this.listTracks.UseCompatibleStateImageBehavior = false;
            this.listTracks.View = System.Windows.Forms.View.Details;
            this.listTracks.ItemActivate += new System.EventHandler(this.listTracks_ItemActivate);
            this.listTracks.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listTracks_ItemDrag);
            this.listTracks.DragDrop += new System.Windows.Forms.DragEventHandler(this.listTracks_DragDrop);
            this.listTracks.DragEnter += new System.Windows.Forms.DragEventHandler(this.listTracks_DragEnter);
            this.listTracks.DoubleClick += new System.EventHandler(this.listTracks_DoubleClick);
            this.listTracks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listTracks_MouseClick);
            this.listTracks.MouseLeave += new System.EventHandler(this.listTracks_MouseLeave);
            // 
            // number
            // 
            this.number.Text = "№";
            // 
            // Next
            // 
            this.Next.Text = "След";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(986, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // playlistMenuItem
            // 
            this.playlistMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMenuItem,
            this.openPlaylistItem,
            this.savePlaylistItem,
            this.saveAsMenuItem,
            this.addFileMenuItem,
            this.добавитьСценарийToolStripMenuItem});
            this.playlistMenuItem.Name = "playlistMenuItem";
            this.playlistMenuItem.Size = new System.Drawing.Size(73, 20);
            this.playlistMenuItem.Text = "Плейлист";
            // 
            // createMenuItem
            // 
            this.createMenuItem.Name = "createMenuItem";
            this.createMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createMenuItem.Text = "Создать";
            this.createMenuItem.Click += new System.EventHandler(this.createMenuItem_Click);
            // 
            // openPlaylistItem
            // 
            this.openPlaylistItem.Name = "openPlaylistItem";
            this.openPlaylistItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openPlaylistItem.Size = new System.Drawing.Size(234, 22);
            this.openPlaylistItem.Text = "Открыть";
            this.openPlaylistItem.Click += new System.EventHandler(this.openPlaylistItem_Click);
            // 
            // savePlaylistItem
            // 
            this.savePlaylistItem.Name = "savePlaylistItem";
            this.savePlaylistItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePlaylistItem.Size = new System.Drawing.Size(234, 22);
            this.savePlaylistItem.Text = "Сохранить";
            this.savePlaylistItem.Click += new System.EventHandler(this.savePlaylistItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(234, 22);
            this.saveAsMenuItem.Text = "Сохранить как...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // addFileMenuItem
            // 
            this.addFileMenuItem.Name = "addFileMenuItem";
            this.addFileMenuItem.Size = new System.Drawing.Size(234, 22);
            this.addFileMenuItem.Text = "Добавить файл";
            this.addFileMenuItem.Click += new System.EventHandler(this.addFileMenuItem_Click);
            // 
            // добавитьСценарийToolStripMenuItem
            // 
            this.добавитьСценарийToolStripMenuItem.Name = "добавитьСценарийToolStripMenuItem";
            this.добавитьСценарийToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.добавитьСценарийToolStripMenuItem.Text = "Добавить сценарий";
            this.добавитьСценарийToolStripMenuItem.Click += new System.EventHandler(this.добавитьСценарийToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настроитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 48);
            // 
            // настроитьToolStripMenuItem
            // 
            this.настроитьToolStripMenuItem.Name = "настроитьToolStripMenuItem";
            this.настроитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.настроитьToolStripMenuItem.Text = "Настроить";
            this.настроитьToolStripMenuItem.Click += new System.EventHandler(this.настроитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playButton.Location = new System.Drawing.Point(25, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(243, 59);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "СЛЕДУЮЩИЙ ТРЕК";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLabel,
            this.trackStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(986, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "СТАТУС:";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 17);
            this.statusLabel.Text = "ПАУЗА";
            // 
            // trackStatusLabel
            // 
            this.trackStatusLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackStatusLabel.Name = "trackStatusLabel";
            this.trackStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.trackStatusLabel.Text = "trackStatus";
            this.trackStatusLabel.Visible = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.Location = new System.Drawing.Point(25, 79);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(243, 59);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "СТОП";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HideBgTrack);
            this.panel1.Controls.Add(this.currentTrackCheckBox);
            this.panel1.Controls.Add(this.playButton);
            this.panel1.Controls.Add(this.stopButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(680, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 427);
            this.panel1.TabIndex = 7;
            // 
            // HideBgTrack
            // 
            this.HideBgTrack.AutoSize = true;
            this.HideBgTrack.Location = new System.Drawing.Point(27, 181);
            this.HideBgTrack.Name = "HideBgTrack";
            this.HideBgTrack.Size = new System.Drawing.Size(145, 17);
            this.HideBgTrack.TabIndex = 8;
            this.HideBgTrack.Text = "Скрыть фоновые треки";
            this.HideBgTrack.UseVisualStyleBackColor = true;
            this.HideBgTrack.CheckedChanged += new System.EventHandler(this.hideBgTrack_CheckedChanged);
            // 
            // currentTrackCheckBox
            // 
            this.currentTrackCheckBox.AutoSize = true;
            this.currentTrackCheckBox.Location = new System.Drawing.Point(27, 158);
            this.currentTrackCheckBox.Name = "currentTrackCheckBox";
            this.currentTrackCheckBox.Size = new System.Drawing.Size(273, 17);
            this.currentTrackCheckBox.TabIndex = 7;
            this.currentTrackCheckBox.Text = "Всегда возвращать выделение на текущий трек";
            this.currentTrackCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 427);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listTracks);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ПЛЕЙЛИСТ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.scenarioList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "СЦЕНАРИЙ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // scernarioList
            // 
            this.scenarioList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.textColumn,
            this.trackColumn});
            this.scenarioList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenarioList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scenarioList.Location = new System.Drawing.Point(3, 3);
            this.scenarioList.Name = "scernarioList";
            this.scenarioList.Size = new System.Drawing.Size(666, 395);
            this.scenarioList.TabIndex = 0;
            this.scenarioList.UseCompatibleStateImageBehavior = false;
            this.scenarioList.View = System.Windows.Forms.View.Details;
            // 
            // textColumn
            // 
            this.textColumn.Width = 490;
            // 
            // trackColumn
            // 
            this.trackColumn.Width = 600;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "kdcnovAuto";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader TrackName;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.ColumnHeader OSC;
        private System.Windows.Forms.ColumnHeader Midi;
        private System.Windows.Forms.ListView listTracks;
        private System.Windows.Forms.ColumnHeader Next;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem playlistMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistItem;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настроитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel trackStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileMenuItem;
        private System.Windows.Forms.CheckBox currentTrackCheckBox;
        private System.Windows.Forms.CheckBox HideBgTrack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView scenarioList;
        private System.Windows.Forms.ColumnHeader textColumn;
        private System.Windows.Forms.ColumnHeader trackColumn;
        private System.Windows.Forms.ToolStripMenuItem добавитьСценарийToolStripMenuItem;
    }
}

