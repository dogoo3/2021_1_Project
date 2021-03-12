using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteMaker
{
    public partial class NoteInfoEditor : Form
    {
        private Form1 _parentForm;

        public NoteInfoEditor(Form1 _parentForm)
        {
            InitializeComponent();
            this._parentForm = _parentForm;
        }

        public void Init(double _activeTime, string _joint, string _activeNote = "", string _animation = "", bool _isModify = false)
        {
            _textbox_activetime.Text = _activeTime.ToString();
            _textbox_joint.Text = _joint;
            _textbox_activenote.Text = _activeNote;
            _textbox_animation.Text = _animation;

            if (_isModify)
                _button_OK.Text = "노트 수정";
            else
                _button_OK.Text = "노트 생성";

        }

        private void _button_OK_Click(object sender, EventArgs e)
        {
            _parentForm.MakeNote(Convert.ToDouble(_textbox_activetime.Text), _textbox_joint.Text, _textbox_activenote.Text, _textbox_animation.Text);
            Close();
        }

        private void _textbox_activenote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
