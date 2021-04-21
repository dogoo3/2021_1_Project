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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._combobox_joint = new System.Windows.Forms.ComboBox();
            this._combobox_activenote = new System.Windows.Forms.ComboBox();
            this._combobox_sfxName = new System.Windows.Forms.ComboBox();
            this._combobox_animation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _button_OK
            // 
            this._button_OK.Location = new System.Drawing.Point(95, 181);
            this._button_OK.Name = "_button_OK";
            this._button_OK.Size = new System.Drawing.Size(75, 23);
            this._button_OK.TabIndex = 5;
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
            this._textbox_activetime.Size = new System.Drawing.Size(173, 29);
            this._textbox_activetime.TabIndex = 99;
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
            // _combobox_joint
            // 
            this._combobox_joint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._combobox_joint.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._combobox_joint.FormattingEnabled = true;
            this._combobox_joint.Location = new System.Drawing.Point(95, 41);
            this._combobox_joint.Name = "_combobox_joint";
            this._combobox_joint.Size = new System.Drawing.Size(173, 29);
            this._combobox_joint.TabIndex = 1;
            // 
            // _combobox_activenote
            // 
            this._combobox_activenote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._combobox_activenote.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._combobox_activenote.FormattingEnabled = true;
            this._combobox_activenote.Location = new System.Drawing.Point(95, 76);
            this._combobox_activenote.Name = "_combobox_activenote";
            this._combobox_activenote.Size = new System.Drawing.Size(173, 29);
            this._combobox_activenote.TabIndex = 2;
            // 
            // _combobox_sfxName
            // 
            this._combobox_sfxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._combobox_sfxName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._combobox_sfxName.FormattingEnabled = true;
            this._combobox_sfxName.Location = new System.Drawing.Point(95, 111);
            this._combobox_sfxName.Name = "_combobox_sfxName";
            this._combobox_sfxName.Size = new System.Drawing.Size(173, 29);
            this._combobox_sfxName.TabIndex = 3;
            // 
            // _combobox_animation
            // 
            this._combobox_animation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._combobox_animation.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._combobox_animation.FormattingEnabled = true;
            this._combobox_animation.Location = new System.Drawing.Point(95, 146);
            this._combobox_animation.Name = "_combobox_animation";
            this._combobox_animation.Size = new System.Drawing.Size(173, 29);
            this._combobox_animation.TabIndex = 4;
            // 
            // NoteInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 216);
            this.Controls.Add(this._combobox_animation);
            this.Controls.Add(this._combobox_sfxName);
            this.Controls.Add(this._combobox_activenote);
            this.Controls.Add(this._combobox_joint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _combobox_joint;
        private System.Windows.Forms.ComboBox _combobox_activenote;
        private System.Windows.Forms.ComboBox _combobox_sfxName;
        private System.Windows.Forms.ComboBox _combobox_animation;
    }
}