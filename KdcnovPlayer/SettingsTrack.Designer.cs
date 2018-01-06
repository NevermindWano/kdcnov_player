namespace kdcnovAutoWinForms
{
    partial class SettingsTrack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsTrack));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.bpmLabel = new System.Windows.Forms.Label();
            this.bpmUpDown = new System.Windows.Forms.NumericUpDown();
            this.nextLabel = new System.Windows.Forms.Label();
            this.nextComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.midiUpDown = new System.Windows.Forms.NumericUpDown();
            this.sendMidiButton = new System.Windows.Forms.Button();
            this.oscSendButton = new System.Windows.Forms.Button();
            this.oscUpDown = new System.Windows.Forms.NumericUpDown();
            this.midiNoteRadio = new System.Windows.Forms.RadioButton();
            this.midiFileRadio = new System.Windows.Forms.RadioButton();
            this.midiFileTextBox = new System.Windows.Forms.TextBox();
            this.mainRadioButton = new System.Windows.Forms.RadioButton();
            this.bgRadioButton = new System.Windows.Forms.RadioButton();
            this.midiGroupBox = new System.Windows.Forms.GroupBox();
            this.OSCBox = new System.Windows.Forms.GroupBox();
            this.customOSCTextBox = new System.Windows.Forms.TextBox();
            this.customOSCCommand = new System.Windows.Forms.RadioButton();
            this.clipUpDown = new System.Windows.Forms.NumericUpDown();
            this.ResolumeCLIP = new System.Windows.Forms.RadioButton();
            this.ResolumeTRACK = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.bpmUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midiUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscUpDown)).BeginInit();
            this.midiGroupBox.SuspendLayout();
            this.OSCBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clipUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(109, 28);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(286, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(35, 31);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Название";
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(62, 97);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(30, 13);
            this.bpmLabel.TabIndex = 3;
            this.bpmLabel.Text = "BPM";
            // 
            // bpmUpDown
            // 
            this.bpmUpDown.Location = new System.Drawing.Point(108, 95);
            this.bpmUpDown.Name = "bpmUpDown";
            this.bpmUpDown.Size = new System.Drawing.Size(120, 20);
            this.bpmUpDown.TabIndex = 4;
            // 
            // nextLabel
            // 
            this.nextLabel.AutoSize = true;
            this.nextLabel.Location = new System.Drawing.Point(21, 138);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(71, 13);
            this.nextLabel.TabIndex = 5;
            this.nextLabel.Text = "После трека";
            // 
            // nextComboBox
            // 
            this.nextComboBox.FormattingEnabled = true;
            this.nextComboBox.Location = new System.Drawing.Point(108, 135);
            this.nextComboBox.Name = "nextComboBox";
            this.nextComboBox.Size = new System.Drawing.Size(362, 21);
            this.nextComboBox.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(395, 442);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // midiUpDown
            // 
            this.midiUpDown.Location = new System.Drawing.Point(24, 42);
            this.midiUpDown.Name = "midiUpDown";
            this.midiUpDown.Size = new System.Drawing.Size(120, 20);
            this.midiUpDown.TabIndex = 8;
            // 
            // sendMidiButton
            // 
            this.sendMidiButton.Location = new System.Drawing.Point(150, 40);
            this.sendMidiButton.Name = "sendMidiButton";
            this.sendMidiButton.Size = new System.Drawing.Size(75, 23);
            this.sendMidiButton.TabIndex = 10;
            this.sendMidiButton.Text = "Send";
            this.sendMidiButton.UseVisualStyleBackColor = true;
            this.sendMidiButton.Click += new System.EventHandler(this.sendMidiButton_Click);
            // 
            // oscSendButton
            // 
            this.oscSendButton.Location = new System.Drawing.Point(365, 110);
            this.oscSendButton.Name = "oscSendButton";
            this.oscSendButton.Size = new System.Drawing.Size(75, 23);
            this.oscSendButton.TabIndex = 13;
            this.oscSendButton.Text = "SEND";
            this.oscSendButton.UseVisualStyleBackColor = true;
            this.oscSendButton.Click += new System.EventHandler(this.oscSendButton_Click);
            // 
            // oscUpDown
            // 
            this.oscUpDown.Location = new System.Drawing.Point(180, 19);
            this.oscUpDown.Name = "oscUpDown";
            this.oscUpDown.Size = new System.Drawing.Size(120, 20);
            this.oscUpDown.TabIndex = 14;
            // 
            // midiNoteRadio
            // 
            this.midiNoteRadio.AutoSize = true;
            this.midiNoteRadio.Checked = true;
            this.midiNoteRadio.Location = new System.Drawing.Point(24, 19);
            this.midiNoteRadio.Name = "midiNoteRadio";
            this.midiNoteRadio.Size = new System.Drawing.Size(55, 17);
            this.midiNoteRadio.TabIndex = 15;
            this.midiNoteRadio.TabStop = true;
            this.midiNoteRadio.Text = "NOTE";
            this.midiNoteRadio.UseVisualStyleBackColor = true;
            this.midiNoteRadio.CheckedChanged += new System.EventHandler(this.midiNoteRadio_CheckedChanged);
            // 
            // midiFileRadio
            // 
            this.midiFileRadio.AutoSize = true;
            this.midiFileRadio.Location = new System.Drawing.Point(253, 19);
            this.midiFileRadio.Name = "midiFileRadio";
            this.midiFileRadio.Size = new System.Drawing.Size(47, 17);
            this.midiFileRadio.TabIndex = 16;
            this.midiFileRadio.Text = "FILE";
            this.midiFileRadio.UseVisualStyleBackColor = true;
            this.midiFileRadio.CheckedChanged += new System.EventHandler(this.midiFileRadio_CheckedChanged);
            // 
            // midiFileTextBox
            // 
            this.midiFileTextBox.Location = new System.Drawing.Point(253, 42);
            this.midiFileTextBox.Name = "midiFileTextBox";
            this.midiFileTextBox.Size = new System.Drawing.Size(181, 20);
            this.midiFileTextBox.TabIndex = 17;
            this.midiFileTextBox.DoubleClick += new System.EventHandler(this.midiFileTextBox_DoubleClick);
            // 
            // mainRadioButton
            // 
            this.mainRadioButton.AutoSize = true;
            this.mainRadioButton.Checked = true;
            this.mainRadioButton.Location = new System.Drawing.Point(109, 51);
            this.mainRadioButton.Name = "mainRadioButton";
            this.mainRadioButton.Size = new System.Drawing.Size(87, 17);
            this.mainRadioButton.TabIndex = 18;
            this.mainRadioButton.TabStop = true;
            this.mainRadioButton.Text = "ОСНОВНОЙ";
            this.mainRadioButton.UseVisualStyleBackColor = true;
            // 
            // bgRadioButton
            // 
            this.bgRadioButton.AutoSize = true;
            this.bgRadioButton.Location = new System.Drawing.Point(234, 51);
            this.bgRadioButton.Name = "bgRadioButton";
            this.bgRadioButton.Size = new System.Drawing.Size(85, 17);
            this.bgRadioButton.TabIndex = 19;
            this.bgRadioButton.Text = "ФОНОВЫЙ";
            this.bgRadioButton.UseVisualStyleBackColor = true;
            // 
            // midiGroupBox
            // 
            this.midiGroupBox.Controls.Add(this.midiNoteRadio);
            this.midiGroupBox.Controls.Add(this.midiUpDown);
            this.midiGroupBox.Controls.Add(this.midiFileTextBox);
            this.midiGroupBox.Controls.Add(this.midiFileRadio);
            this.midiGroupBox.Controls.Add(this.sendMidiButton);
            this.midiGroupBox.Location = new System.Drawing.Point(24, 161);
            this.midiGroupBox.Name = "midiGroupBox";
            this.midiGroupBox.Size = new System.Drawing.Size(446, 83);
            this.midiGroupBox.TabIndex = 20;
            this.midiGroupBox.TabStop = false;
            this.midiGroupBox.Text = "MIDI";
            // 
            // OSCBox
            // 
            this.OSCBox.Controls.Add(this.numericUpDown1);
            this.OSCBox.Controls.Add(this.label1);
            this.OSCBox.Controls.Add(this.customOSCTextBox);
            this.OSCBox.Controls.Add(this.customOSCCommand);
            this.OSCBox.Controls.Add(this.clipUpDown);
            this.OSCBox.Controls.Add(this.ResolumeCLIP);
            this.OSCBox.Controls.Add(this.ResolumeTRACK);
            this.OSCBox.Controls.Add(this.oscUpDown);
            this.OSCBox.Controls.Add(this.oscSendButton);
            this.OSCBox.Location = new System.Drawing.Point(24, 271);
            this.OSCBox.Name = "OSCBox";
            this.OSCBox.Size = new System.Drawing.Size(446, 139);
            this.OSCBox.TabIndex = 21;
            this.OSCBox.TabStop = false;
            this.OSCBox.Text = "OSC";
            // 
            // customOSCTextBox
            // 
            this.customOSCTextBox.Location = new System.Drawing.Point(180, 72);
            this.customOSCTextBox.Name = "customOSCTextBox";
            this.customOSCTextBox.Size = new System.Drawing.Size(260, 20);
            this.customOSCTextBox.TabIndex = 19;
            // 
            // customOSCCommand
            // 
            this.customOSCCommand.AutoSize = true;
            this.customOSCCommand.Location = new System.Drawing.Point(24, 73);
            this.customOSCCommand.Name = "customOSCCommand";
            this.customOSCCommand.Size = new System.Drawing.Size(146, 17);
            this.customOSCCommand.TabIndex = 18;
            this.customOSCCommand.Text = "Произвольная команда";
            this.customOSCCommand.UseVisualStyleBackColor = true;
            // 
            // clipUpDown
            // 
            this.clipUpDown.Location = new System.Drawing.Point(180, 45);
            this.clipUpDown.Name = "clipUpDown";
            this.clipUpDown.Size = new System.Drawing.Size(120, 20);
            this.clipUpDown.TabIndex = 17;
            // 
            // ResolumeCLIP
            // 
            this.ResolumeCLIP.AutoSize = true;
            this.ResolumeCLIP.Location = new System.Drawing.Point(24, 46);
            this.ResolumeCLIP.Name = "ResolumeCLIP";
            this.ResolumeCLIP.Size = new System.Drawing.Size(98, 17);
            this.ResolumeCLIP.TabIndex = 16;
            this.ResolumeCLIP.Text = "Resolume CLIP";
            this.ResolumeCLIP.UseVisualStyleBackColor = true;
            // 
            // ResolumeTRACK
            // 
            this.ResolumeTRACK.AutoSize = true;
            this.ResolumeTRACK.Checked = true;
            this.ResolumeTRACK.Location = new System.Drawing.Point(24, 22);
            this.ResolumeTRACK.Name = "ResolumeTRACK";
            this.ResolumeTRACK.Size = new System.Drawing.Size(111, 17);
            this.ResolumeTRACK.TabIndex = 15;
            this.ResolumeTRACK.TabStop = true;
            this.ResolumeTRACK.Text = "Resolume TRACK";
            this.ResolumeTRACK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "LAYER";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(354, 46);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown1.TabIndex = 21;
            // 
            // SettingsTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 477);
            this.Controls.Add(this.OSCBox);
            this.Controls.Add(this.midiGroupBox);
            this.Controls.Add(this.bgRadioButton);
            this.Controls.Add(this.mainRadioButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nextComboBox);
            this.Controls.Add(this.nextLabel);
            this.Controls.Add(this.bpmUpDown);
            this.Controls.Add(this.bpmLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsTrack";
            this.Text = "SetiingsTrack";
            ((System.ComponentModel.ISupportInitialize)(this.bpmUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midiUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscUpDown)).EndInit();
            this.midiGroupBox.ResumeLayout(false);
            this.midiGroupBox.PerformLayout();
            this.OSCBox.ResumeLayout(false);
            this.OSCBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clipUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label bpmLabel;
        private System.Windows.Forms.NumericUpDown bpmUpDown;
        private System.Windows.Forms.Label nextLabel;
        private System.Windows.Forms.ComboBox nextComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown midiUpDown;
        private System.Windows.Forms.Button sendMidiButton;
        private System.Windows.Forms.Button oscSendButton;
        private System.Windows.Forms.NumericUpDown oscUpDown;
        private System.Windows.Forms.RadioButton midiNoteRadio;
        private System.Windows.Forms.RadioButton midiFileRadio;
        private System.Windows.Forms.TextBox midiFileTextBox;
        private System.Windows.Forms.RadioButton mainRadioButton;
        private System.Windows.Forms.RadioButton bgRadioButton;
        private System.Windows.Forms.GroupBox midiGroupBox;
        private System.Windows.Forms.GroupBox OSCBox;
        private System.Windows.Forms.TextBox customOSCTextBox;
        private System.Windows.Forms.RadioButton customOSCCommand;
        private System.Windows.Forms.NumericUpDown clipUpDown;
        private System.Windows.Forms.RadioButton ResolumeCLIP;
        private System.Windows.Forms.RadioButton ResolumeTRACK;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}