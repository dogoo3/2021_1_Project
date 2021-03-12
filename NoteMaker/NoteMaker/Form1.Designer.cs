namespace NoteMaker
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._button_loadmp3 = new System.Windows.Forms.Button();
            this._button_savenote = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._textbox_nowmusic = new System.Windows.Forms.TextBox();
            this._button_play = new System.Windows.Forms.Button();
            this._button_stop = new System.Windows.Forms.Button();
            this._button_loadnote = new System.Windows.Forms.Button();
            this._textbox_nownote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._trackbar_musicline = new System.Windows.Forms.TrackBar();
            this._textbox_playtime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._trackbar_volume = new System.Windows.Forms.TrackBar();
            this.MaxPlayTime = new System.Windows.Forms.Label();
            this._listbox_noteInfo = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this._picture_joint_lShoulder = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_musicline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_lShoulder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _button_loadmp3
            // 
            this._button_loadmp3.Location = new System.Drawing.Point(13, 40);
            this._button_loadmp3.Name = "_button_loadmp3";
            this._button_loadmp3.Size = new System.Drawing.Size(71, 43);
            this._button_loadmp3.TabIndex = 0;
            this._button_loadmp3.TabStop = false;
            this._button_loadmp3.Text = "mp3파일 불러오기";
            this._button_loadmp3.UseVisualStyleBackColor = true;
            this._button_loadmp3.Click += new System.EventHandler(this._button_loadmp3_Click);
            // 
            // _button_savenote
            // 
            this._button_savenote.Location = new System.Drawing.Point(90, 40);
            this._button_savenote.Name = "_button_savenote";
            this._button_savenote.Size = new System.Drawing.Size(71, 43);
            this._button_savenote.TabIndex = 0;
            this._button_savenote.TabStop = false;
            this._button_savenote.Text = "채보 저장하기";
            this._button_savenote.UseVisualStyleBackColor = true;
            this._button_savenote.Click += new System.EventHandler(this._button_savenote_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "load Music : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _textbox_nowmusic
            // 
            this._textbox_nowmusic.Location = new System.Drawing.Point(95, 10);
            this._textbox_nowmusic.Name = "_textbox_nowmusic";
            this._textbox_nowmusic.ReadOnly = true;
            this._textbox_nowmusic.Size = new System.Drawing.Size(307, 21);
            this._textbox_nowmusic.TabIndex = 3;
            this._textbox_nowmusic.TabStop = false;
            // 
            // _button_play
            // 
            this._button_play.Enabled = false;
            this._button_play.Location = new System.Drawing.Point(260, 90);
            this._button_play.Name = "_button_play";
            this._button_play.Size = new System.Drawing.Size(23, 23);
            this._button_play.TabIndex = 0;
            this._button_play.TabStop = false;
            this._button_play.Text = "▶";
            this._button_play.UseVisualStyleBackColor = true;
            this._button_play.Click += new System.EventHandler(this._button_play_Click);
            // 
            // _button_stop
            // 
            this._button_stop.Enabled = false;
            this._button_stop.Location = new System.Drawing.Point(289, 89);
            this._button_stop.Name = "_button_stop";
            this._button_stop.Size = new System.Drawing.Size(23, 23);
            this._button_stop.TabIndex = 0;
            this._button_stop.TabStop = false;
            this._button_stop.Text = "∥";
            this._button_stop.UseVisualStyleBackColor = true;
            this._button_stop.Click += new System.EventHandler(this._button_stop_Click);
            // 
            // _button_loadnote
            // 
            this._button_loadnote.Location = new System.Drawing.Point(167, 40);
            this._button_loadnote.Name = "_button_loadnote";
            this._button_loadnote.Size = new System.Drawing.Size(71, 43);
            this._button_loadnote.TabIndex = 0;
            this._button_loadnote.TabStop = false;
            this._button_loadnote.Text = "채보 불러오기";
            this._button_loadnote.UseVisualStyleBackColor = true;
            this._button_loadnote.Click += new System.EventHandler(this._button_loadnote_Click);
            // 
            // _textbox_nownote
            // 
            this._textbox_nownote.Location = new System.Drawing.Point(517, 10);
            this._textbox_nownote.Name = "_textbox_nownote";
            this._textbox_nownote.ReadOnly = true;
            this._textbox_nownote.Size = new System.Drawing.Size(134, 21);
            this._textbox_nownote.TabIndex = 9;
            this._textbox_nownote.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Load File : ";
            // 
            // _trackbar_musicline
            // 
            this._trackbar_musicline.AutoSize = false;
            this._trackbar_musicline.Enabled = false;
            this._trackbar_musicline.LargeChange = 20;
            this._trackbar_musicline.Location = new System.Drawing.Point(13, 119);
            this._trackbar_musicline.Margin = new System.Windows.Forms.Padding(0);
            this._trackbar_musicline.Name = "_trackbar_musicline";
            this._trackbar_musicline.Size = new System.Drawing.Size(305, 26);
            this._trackbar_musicline.TabIndex = 0;
            this._trackbar_musicline.TabStop = false;
            this._trackbar_musicline.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackbar_musicline.Scroll += new System.EventHandler(this._trackbar_musicline_Scroll);
            // 
            // _textbox_playtime
            // 
            this._textbox_playtime.Enabled = false;
            this._textbox_playtime.Location = new System.Drawing.Point(90, 92);
            this._textbox_playtime.Name = "_textbox_playtime";
            this._textbox_playtime.Size = new System.Drawing.Size(134, 21);
            this._textbox_playtime.TabIndex = 0;
            this._textbox_playtime.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "재생시간(s)";
            // 
            // _trackbar_volume
            // 
            this._trackbar_volume.Enabled = false;
            this._trackbar_volume.Location = new System.Drawing.Point(260, 40);
            this._trackbar_volume.Maximum = 0;
            this._trackbar_volume.Minimum = -1200;
            this._trackbar_volume.Name = "_trackbar_volume";
            this._trackbar_volume.Size = new System.Drawing.Size(104, 45);
            this._trackbar_volume.TabIndex = 13;
            this._trackbar_volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trackbar_volume.Value = -600;
            this._trackbar_volume.Scroll += new System.EventHandler(this._trackbar_volume_Scroll);
            // 
            // MaxPlayTime
            // 
            this.MaxPlayTime.AutoSize = true;
            this.MaxPlayTime.Location = new System.Drawing.Point(319, 123);
            this.MaxPlayTime.Name = "MaxPlayTime";
            this.MaxPlayTime.Size = new System.Drawing.Size(0, 12);
            this.MaxPlayTime.TabIndex = 14;
            // 
            // _listbox_noteInfo
            // 
            this._listbox_noteInfo.FormattingEnabled = true;
            this._listbox_noteInfo.ItemHeight = 12;
            this._listbox_noteInfo.Location = new System.Drawing.Point(403, 73);
            this._listbox_noteInfo.Name = "_listbox_noteInfo";
            this._listbox_noteInfo.Size = new System.Drawing.Size(248, 496);
            this._listbox_noteInfo.TabIndex = 15;
            this._listbox_noteInfo.SelectedIndexChanged += new System.EventHandler(this._listbox_noteInfo_SelectedIndexChanged);
            this._listbox_noteInfo.DoubleClick += new System.EventHandler(this._listbox_noteInfo_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "재생시간 / 관절 / 노트 / 애니메이션";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox8.Location = new System.Drawing.Point(184, 522);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(30, 30);
            this.pictureBox8.TabIndex = 24;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox7.Location = new System.Drawing.Point(117, 522);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox6.Location = new System.Drawing.Point(172, 453);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.TabIndex = 22;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox5.Location = new System.Drawing.Point(126, 453);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.TabIndex = 21;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox4.Location = new System.Drawing.Point(184, 401);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox3.Location = new System.Drawing.Point(106, 401);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Location = new System.Drawing.Point(184, 277);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // _picture_joint_lShoulder
            // 
            this._picture_joint_lShoulder.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_lShoulder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_lShoulder.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_lShoulder.Location = new System.Drawing.Point(106, 277);
            this._picture_joint_lShoulder.Name = "_picture_joint_lShoulder";
            this._picture_joint_lShoulder.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_lShoulder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_lShoulder.TabIndex = 17;
            this._picture_joint_lShoulder.TabStop = false;
            this._picture_joint_lShoulder.Click += new System.EventHandler(this._picture_joint_lShoulder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NoteMaker.Properties.Resources.Test;
            this.pictureBox1.Location = new System.Drawing.Point(15, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 580);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._picture_joint_lShoulder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._listbox_noteInfo);
            this.Controls.Add(this.MaxPlayTime);
            this.Controls.Add(this._trackbar_volume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._textbox_playtime);
            this.Controls.Add(this._trackbar_musicline);
            this.Controls.Add(this._textbox_nownote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._button_loadnote);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._button_stop);
            this.Controls.Add(this._button_play);
            this.Controls.Add(this._textbox_nowmusic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._button_savenote);
            this.Controls.Add(this._button_loadmp3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "마왕성에서 춤춰요! 채보메이커";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_musicline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_lShoulder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _button_loadmp3;
        private System.Windows.Forms.Button _button_savenote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textbox_nowmusic;
        private System.Windows.Forms.Button _button_play;
        private System.Windows.Forms.Button _button_stop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _button_loadnote;
        private System.Windows.Forms.TextBox _textbox_nownote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar _trackbar_musicline;
        private System.Windows.Forms.TextBox _textbox_playtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar _trackbar_volume;
        private System.Windows.Forms.Label MaxPlayTime;
        private System.Windows.Forms.ListBox _listbox_noteInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox _picture_joint_lShoulder;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}

