namespace NoteMaker
{
    partial class NoteInfoEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteInfoEditor));
            this._button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._textbox_activetime = new System.Windows.Forms.TextBox();
            this._textbox_joint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._textbox_animation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._textbox_activenote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._textbox_sfxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _button_OK
            // 
            this._button_OK.Location = new System.Drawing.Point(65, 181);
            this._button_OK.Name = "_button_OK";
            this._button_OK.Size = new System.Drawing.Size(75, 23);
            this._button_OK.TabIndex = 3;
            this._button_OK.Text = "노트 설정";
            this._button_OK.UseVisualStyleBackColor = true;
            this._button_OK.Click += new System.EventHandler(this._button_OK_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 99;
            this.label1.Text = "활성화시간";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textbox_activetime
            // 
            this._textbox_activetime.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this._textbox_activetime.Location = new System.Drawing.Point(95, 6);
            this._textbox_activetime.Name = "_textbox_activetime";
            this._textbox_activetime.ReadOnly = true;
            this._textbox_activetime.Size = new System.Drawing.Size(100, 29);
            this._textbox_activetime.TabIndex = 99;
            // 
            // _textbox_joint
            // 
            this._textbox_joint.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this._textbox_joint.Location = new System.Drawing.Point(95, 41);
            this._textbox_joint.Name = "_textbox_joint";
            this._textbox_joint.Size = new System.Drawing.Size(100, 29);
            this._textbox_joint.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 99;
            this.label2.Text = "관절";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textbox_animation
            // 
            this._textbox_animation.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this._textbox_animation.Location = new System.Drawing.Point(95, 146);
            this._textbox_animation.Name = "_textbox_animation";
            this._textbox_animation.Size = new System.Drawing.Size(100, 29);
            this._textbox_animation.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(5, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 99;
            this.label3.Text = "애니메이션";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textbox_activenote
            // 
            this._textbox_activenote.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this._textbox_activenote.Location = new System.Drawing.Point(95, 76);
            this._textbox_activenote.Name = "_textbox_activenote";
            this._textbox_activenote.Size = new System.Drawing.Size(100, 29);
            this._textbox_activenote.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(5, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 99;
            this.label4.Text = "노트";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _textbox_sfxName
            // 
            this._textbox_sfxName.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this._textbox_sfxName.Location = new System.Drawing.Point(95, 111);
            this._textbox_sfxName.Name = "_textbox_sfxName";
            this._textbox_sfxName.Size = new System.Drawing.Size(100, 29);
            this._textbox_sfxName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(5, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "효과음";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NoteInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 216);
            this.Controls.Add(this._textbox_sfxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._textbox_activenote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._textbox_animation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._textbox_joint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._textbox_activetime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._button_OK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteInfoEditor";
            this.Text = "노트 정보 입력";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteInfoEditor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textbox_activetime;
        private System.Windows.Forms.TextBox _textbox_joint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textbox_animation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _textbox_activenote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _textbox_sfxName;
        private System.Windows.Forms.Label label5;
    }
}