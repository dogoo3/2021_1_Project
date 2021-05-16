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
            this.label5 = new System.Windows.Forms.Label();
            this._textbox_lineTocircle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._textbox_reducevalue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._textbox_longNotespeed = new System.Windows.Forms.TextBox();
            this._picture_Floor_L = new System.Windows.Forms.PictureBox();
            this._picture_joint_stomach = new System.Windows.Forms.PictureBox();
            this._picture_joint_Relbow = new System.Windows.Forms.PictureBox();
            this._picture_joint_Lelbow = new System.Windows.Forms.PictureBox();
            this._picture_joint_Rfoot = new System.Windows.Forms.PictureBox();
            this._picture_joint_Lfoot = new System.Windows.Forms.PictureBox();
            this._picture_joint_Rknee = new System.Windows.Forms.PictureBox();
            this._picture_joint_Lknee = new System.Windows.Forms.PictureBox();
            this._picture_joint_Rhand = new System.Windows.Forms.PictureBox();
            this._picture_joint_Lhand = new System.Windows.Forms.PictureBox();
            this._picture_joint_Rshoulder = new System.Windows.Forms.PictureBox();
            this._picture_joint_Lshoulder = new System.Windows.Forms.PictureBox();
            this._picturebox_Character = new System.Windows.Forms.PictureBox();
            this._picture_Floor_R = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_musicline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_Floor_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_stomach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Relbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lelbow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rfoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lfoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rknee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lknee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rhand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lhand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rshoulder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lshoulder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picturebox_Character)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_Floor_R)).BeginInit();
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
            this._textbox_nownote.Location = new System.Drawing.Point(511, 10);
            this._textbox_nownote.Name = "_textbox_nownote";
            this._textbox_nownote.ReadOnly = true;
            this._textbox_nownote.Size = new System.Drawing.Size(261, 21);
            this._textbox_nownote.TabIndex = 9;
            this._textbox_nownote.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 14);
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
            this._trackbar_musicline.Maximum = 999;
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
            this._textbox_playtime.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this._textbox_playtime.Location = new System.Drawing.Point(90, 92);
            this._textbox_playtime.Name = "_textbox_playtime";
            this._textbox_playtime.Size = new System.Drawing.Size(134, 21);
            this._textbox_playtime.TabIndex = 0;
            this._textbox_playtime.TabStop = false;
            this._textbox_playtime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textbox_playtime_KeyPress);
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
            this._listbox_noteInfo.Location = new System.Drawing.Point(403, 133);
            this._listbox_noteInfo.Name = "_listbox_noteInfo";
            this._listbox_noteInfo.Size = new System.Drawing.Size(369, 436);
            this._listbox_noteInfo.TabIndex = 15;
            this._listbox_noteInfo.DoubleClick += new System.EventHandler(this._listbox_noteInfo_DoubleClick);
            this._listbox_noteInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this._listbox_noteInfo_KeyDown);
            this._listbox_noteInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this._listbox_noteInfo_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "재생시간 / 관절 / 노트 / 효과음 / 애니메이션";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "판정선 거리";
            // 
            // _textbox_lineTocircle
            // 
            this._textbox_lineTocircle.Enabled = false;
            this._textbox_lineTocircle.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this._textbox_lineTocircle.Location = new System.Drawing.Point(494, 40);
            this._textbox_lineTocircle.Name = "_textbox_lineTocircle";
            this._textbox_lineTocircle.Size = new System.Drawing.Size(47, 21);
            this._textbox_lineTocircle.TabIndex = 25;
            this._textbox_lineTocircle.TabStop = false;
            this._textbox_lineTocircle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textbox_lineTocircle_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "판정선감소속도";
            // 
            // _textbox_reducevalue
            // 
            this._textbox_reducevalue.Enabled = false;
            this._textbox_reducevalue.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this._textbox_reducevalue.Location = new System.Drawing.Point(494, 67);
            this._textbox_reducevalue.Name = "_textbox_reducevalue";
            this._textbox_reducevalue.Size = new System.Drawing.Size(47, 21);
            this._textbox_reducevalue.TabIndex = 27;
            this._textbox_reducevalue.TabStop = false;
            this._textbox_reducevalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textbox_reducevalue_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "롱노트이동속도";
            // 
            // _textbox_longNotespeed
            // 
            this._textbox_longNotespeed.Enabled = false;
            this._textbox_longNotespeed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this._textbox_longNotespeed.Location = new System.Drawing.Point(494, 95);
            this._textbox_longNotespeed.Name = "_textbox_longNotespeed";
            this._textbox_longNotespeed.Size = new System.Drawing.Size(47, 21);
            this._textbox_longNotespeed.TabIndex = 29;
            this._textbox_longNotespeed.TabStop = false;
            this._textbox_longNotespeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textbox_longNotespeed_KeyPress);
            // 
            // _picture_Floor_L
            // 
            this._picture_Floor_L.BackColor = System.Drawing.Color.Transparent;
            this._picture_Floor_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_Floor_L.BackgroundImage")));
            this._picture_Floor_L.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_Floor_L.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_Floor_L.Location = new System.Drawing.Point(28, 538);
            this._picture_Floor_L.Name = "_picture_Floor_L";
            this._picture_Floor_L.Size = new System.Drawing.Size(65, 30);
            this._picture_Floor_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_Floor_L.TabIndex = 34;
            this._picture_Floor_L.TabStop = false;
            // 
            // _picture_joint_stomach
            // 
            this._picture_joint_stomach.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_stomach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_stomach.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_stomach.Location = new System.Drawing.Point(145, 337);
            this._picture_joint_stomach.Name = "_picture_joint_stomach";
            this._picture_joint_stomach.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_stomach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_stomach.TabIndex = 33;
            this._picture_joint_stomach.TabStop = false;
            this._picture_joint_stomach.Click += new System.EventHandler(this._picture_joint_stomach_Click);
            // 
            // _picture_joint_Relbow
            // 
            this._picture_joint_Relbow.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Relbow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Relbow.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Relbow.Location = new System.Drawing.Point(184, 337);
            this._picture_joint_Relbow.Name = "_picture_joint_Relbow";
            this._picture_joint_Relbow.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Relbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Relbow.TabIndex = 32;
            this._picture_joint_Relbow.TabStop = false;
            this._picture_joint_Relbow.Click += new System.EventHandler(this._picture_joint_Relbow_Click);
            // 
            // _picture_joint_Lelbow
            // 
            this._picture_joint_Lelbow.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Lelbow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Lelbow.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Lelbow.Location = new System.Drawing.Point(106, 337);
            this._picture_joint_Lelbow.Name = "_picture_joint_Lelbow";
            this._picture_joint_Lelbow.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Lelbow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Lelbow.TabIndex = 31;
            this._picture_joint_Lelbow.TabStop = false;
            this._picture_joint_Lelbow.Click += new System.EventHandler(this._picture_joint_Lelbow_Click);
            // 
            // _picture_joint_Rfoot
            // 
            this._picture_joint_Rfoot.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Rfoot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Rfoot.BackgroundImage")));
            this._picture_joint_Rfoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Rfoot.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Rfoot.Location = new System.Drawing.Point(184, 522);
            this._picture_joint_Rfoot.Name = "_picture_joint_Rfoot";
            this._picture_joint_Rfoot.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Rfoot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Rfoot.TabIndex = 24;
            this._picture_joint_Rfoot.TabStop = false;
            this._picture_joint_Rfoot.Click += new System.EventHandler(this._picture_joint_Rfoot_Click);
            // 
            // _picture_joint_Lfoot
            // 
            this._picture_joint_Lfoot.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Lfoot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Lfoot.BackgroundImage")));
            this._picture_joint_Lfoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Lfoot.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Lfoot.Location = new System.Drawing.Point(117, 522);
            this._picture_joint_Lfoot.Name = "_picture_joint_Lfoot";
            this._picture_joint_Lfoot.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Lfoot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Lfoot.TabIndex = 23;
            this._picture_joint_Lfoot.TabStop = false;
            this._picture_joint_Lfoot.Click += new System.EventHandler(this._picture_joint_Lfoot_Click);
            // 
            // _picture_joint_Rknee
            // 
            this._picture_joint_Rknee.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Rknee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Rknee.BackgroundImage")));
            this._picture_joint_Rknee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Rknee.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Rknee.Location = new System.Drawing.Point(172, 453);
            this._picture_joint_Rknee.Name = "_picture_joint_Rknee";
            this._picture_joint_Rknee.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Rknee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Rknee.TabIndex = 22;
            this._picture_joint_Rknee.TabStop = false;
            this._picture_joint_Rknee.Click += new System.EventHandler(this._picture_joint_Rknee_Click);
            // 
            // _picture_joint_Lknee
            // 
            this._picture_joint_Lknee.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Lknee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Lknee.BackgroundImage")));
            this._picture_joint_Lknee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Lknee.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Lknee.Location = new System.Drawing.Point(126, 453);
            this._picture_joint_Lknee.Name = "_picture_joint_Lknee";
            this._picture_joint_Lknee.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Lknee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Lknee.TabIndex = 21;
            this._picture_joint_Lknee.TabStop = false;
            this._picture_joint_Lknee.Click += new System.EventHandler(this._picture_joint_Lknee_Click);
            // 
            // _picture_joint_Rhand
            // 
            this._picture_joint_Rhand.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Rhand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Rhand.BackgroundImage")));
            this._picture_joint_Rhand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Rhand.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Rhand.Location = new System.Drawing.Point(184, 401);
            this._picture_joint_Rhand.Name = "_picture_joint_Rhand";
            this._picture_joint_Rhand.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Rhand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Rhand.TabIndex = 20;
            this._picture_joint_Rhand.TabStop = false;
            this._picture_joint_Rhand.Click += new System.EventHandler(this._picture_joint_Rhand_Click);
            // 
            // _picture_joint_Lhand
            // 
            this._picture_joint_Lhand.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Lhand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_joint_Lhand.BackgroundImage")));
            this._picture_joint_Lhand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Lhand.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Lhand.Location = new System.Drawing.Point(106, 401);
            this._picture_joint_Lhand.Name = "_picture_joint_Lhand";
            this._picture_joint_Lhand.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Lhand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Lhand.TabIndex = 19;
            this._picture_joint_Lhand.TabStop = false;
            this._picture_joint_Lhand.Click += new System.EventHandler(this._picture_joint_Lhand_Click);
            // 
            // _picture_joint_Rshoulder
            // 
            this._picture_joint_Rshoulder.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Rshoulder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Rshoulder.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Rshoulder.Location = new System.Drawing.Point(184, 277);
            this._picture_joint_Rshoulder.Name = "_picture_joint_Rshoulder";
            this._picture_joint_Rshoulder.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Rshoulder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Rshoulder.TabIndex = 18;
            this._picture_joint_Rshoulder.TabStop = false;
            this._picture_joint_Rshoulder.Click += new System.EventHandler(this._picture_joint_Rshoulder_Click);
            // 
            // _picture_joint_Lshoulder
            // 
            this._picture_joint_Lshoulder.BackColor = System.Drawing.Color.Transparent;
            this._picture_joint_Lshoulder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_joint_Lshoulder.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_joint_Lshoulder.Location = new System.Drawing.Point(106, 277);
            this._picture_joint_Lshoulder.Name = "_picture_joint_Lshoulder";
            this._picture_joint_Lshoulder.Size = new System.Drawing.Size(30, 30);
            this._picture_joint_Lshoulder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_joint_Lshoulder.TabIndex = 17;
            this._picture_joint_Lshoulder.TabStop = false;
            this._picture_joint_Lshoulder.Click += new System.EventHandler(this._picture_joint_lShoulder_Click);
            // 
            // _picturebox_Character
            // 
            this._picturebox_Character.Image = global::NoteMaker.Properties.Resources.Test;
            this._picturebox_Character.Location = new System.Drawing.Point(15, 170);
            this._picturebox_Character.Name = "_picturebox_Character";
            this._picturebox_Character.Size = new System.Drawing.Size(297, 398);
            this._picturebox_Character.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picturebox_Character.TabIndex = 6;
            this._picturebox_Character.TabStop = false;
            // 
            // _picture_Floor_R
            // 
            this._picture_Floor_R.BackColor = System.Drawing.Color.Transparent;
            this._picture_Floor_R.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_picture_Floor_R.BackgroundImage")));
            this._picture_Floor_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture_Floor_R.Cursor = System.Windows.Forms.Cursors.Default;
            this._picture_Floor_R.Location = new System.Drawing.Point(230, 538);
            this._picture_Floor_R.Name = "_picture_Floor_R";
            this._picture_Floor_R.Size = new System.Drawing.Size(65, 30);
            this._picture_Floor_R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture_Floor_R.TabIndex = 35;
            this._picture_Floor_R.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 580);
            this.Controls.Add(this._picture_Floor_R);
            this.Controls.Add(this._picture_Floor_L);
            this.Controls.Add(this._picture_joint_stomach);
            this.Controls.Add(this._picture_joint_Relbow);
            this.Controls.Add(this._picture_joint_Lelbow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._textbox_longNotespeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._textbox_reducevalue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._textbox_lineTocircle);
            this.Controls.Add(this._picture_joint_Rfoot);
            this.Controls.Add(this._picture_joint_Lfoot);
            this.Controls.Add(this._picture_joint_Rknee);
            this.Controls.Add(this._picture_joint_Lknee);
            this.Controls.Add(this._picture_joint_Rhand);
            this.Controls.Add(this._picture_joint_Lhand);
            this.Controls.Add(this._picture_joint_Rshoulder);
            this.Controls.Add(this._picture_joint_Lshoulder);
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
            this.Controls.Add(this._picturebox_Character);
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
            this.Text = "마왕성에서 춤춰요! 채보메이커 ver 1.6";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_musicline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackbar_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_Floor_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_stomach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Relbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lelbow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rfoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lfoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rknee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lknee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rhand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lhand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Rshoulder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_joint_Lshoulder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picturebox_Character)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picture_Floor_R)).EndInit();
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
        private System.Windows.Forms.PictureBox _picturebox_Character;
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
        private System.Windows.Forms.PictureBox _picture_joint_Lshoulder;
        private System.Windows.Forms.PictureBox _picture_joint_Rshoulder;
        private System.Windows.Forms.PictureBox _picture_joint_Lhand;
        private System.Windows.Forms.PictureBox _picture_joint_Rhand;
        private System.Windows.Forms.PictureBox _picture_joint_Lknee;
        private System.Windows.Forms.PictureBox _picture_joint_Rknee;
        private System.Windows.Forms.PictureBox _picture_joint_Lfoot;
        private System.Windows.Forms.PictureBox _picture_joint_Rfoot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _textbox_lineTocircle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _textbox_reducevalue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _textbox_longNotespeed;
        private System.Windows.Forms.PictureBox _picture_joint_Relbow;
        private System.Windows.Forms.PictureBox _picture_joint_Lelbow;
        private System.Windows.Forms.PictureBox _picture_joint_stomach;
        private System.Windows.Forms.PictureBox _picture_Floor_L;
        private System.Windows.Forms.PictureBox _picture_Floor_R;
    }
}

