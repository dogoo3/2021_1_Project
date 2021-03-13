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

        private bool _isModify;
        private int _getIndex;

        public NoteInfoEditor(Form1 _parentForm)
        {
            InitializeComponent();
            this._parentForm = _parentForm;
        }

        public void Init(double _activeTime, string _joint) // 노트를 새로 생성할 때 전처리를 위해 사용하는 함수
        {
            _textbox_activetime.Text = _activeTime.ToString();
            _textbox_joint.Text = _joint;

            _button_OK.Text = "노트 생성";
            _isModify = false;
        }

        public void Init(Note _note, int _index) // 기존 노트를 수정할 때 전처리를 위해 사용하는 함수
        {
            _textbox_activetime.Text = _note._activeTime.ToString();
            _textbox_joint.Text = _note._joint;
            _textbox_activenote.Text = _note._activeNote;
            _textbox_animation.Text = _note._animation;
            _getIndex = _index;

            _button_OK.Text = "노트 수정";
            _isModify = true;
        }

        private void _button_OK_Click(object sender, EventArgs e)
        {
            if (_isModify) // 수정상태
                _parentForm.ModifyNote(_getIndex, Convert.ToDouble(_textbox_activetime.Text), _textbox_joint.Text, _textbox_activenote.Text, _textbox_animation.Text);
            else // 생성상태
                _parentForm.MakeNote(Convert.ToDouble(_textbox_activetime.Text), _textbox_joint.Text, _textbox_activenote.Text, _textbox_animation.Text);
            Close();
        }

        private void NoteInfoEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (_isModify) // 수정상태
                    _parentForm.ModifyNote(_getIndex, Convert.ToDouble(_textbox_activetime.Text), _textbox_joint.Text, _textbox_activenote.Text, _textbox_animation.Text);
                else // 생성상태
                    _parentForm.MakeNote(Convert.ToDouble(_textbox_activetime.Text), _textbox_joint.Text, _textbox_activenote.Text, _textbox_animation.Text);
                Close();
            }
        }
    }
}
