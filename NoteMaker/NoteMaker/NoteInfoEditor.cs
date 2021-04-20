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

namespace NoteMaker
{
    public partial class NoteInfoEditor : Form
    {
        private Form1 _parentForm;
        private StreamReader _streamReader;

        private bool _isModify;
        private int _getIndex;

        private string _temp;
        private string[] _noteTemp;

        public NoteInfoEditor(Form1 _parentForm)
        {
            InitializeComponent();
            this._parentForm = _parentForm;
            _combobox_joint.Items.Add("Lshoulder");
            _combobox_joint.Items.Add("Rshoulder");
            _combobox_joint.Items.Add("Lelbow");
            _combobox_joint.Items.Add("Relbow");
            _combobox_joint.Items.Add("stomach");
            _combobox_joint.Items.Add("Lhand");
            _combobox_joint.Items.Add("Rhand");
            _combobox_joint.Items.Add("Lknee");
            _combobox_joint.Items.Add("Rknee");
            _combobox_joint.Items.Add("Lfoot");
            _combobox_joint.Items.Add("Rfoot");
            
            FileInfo _fInfo = new FileInfo(Application.StartupPath + "\\comboboxInfo.txt");
            if (_fInfo.Exists)
            {
                _streamReader = new StreamReader(Application.StartupPath + "\\comboboxInfo.txt");
                // 노트 정보
                _temp = _streamReader.ReadLine();
                _noteTemp = _temp.Split(',');
                for (int i = 0; i < _noteTemp.Length; i++)
                    _combobox_activenote.Items.Add(_noteTemp[i]);
                // 효과음 정보
                _temp = _streamReader.ReadLine();
                _noteTemp = _temp.Split(',');
                for (int i = 0; i < _noteTemp.Length; i++)
                    _combobox_sfxName.Items.Add(_noteTemp[i]);
                // 애니메이션 정보
                _temp = _streamReader.ReadLine();
                _noteTemp = _temp.Split(',');
                for (int i = 0; i < _noteTemp.Length; i++)
                    _combobox_animation.Items.Add(_noteTemp[i]);
            }
            else
                MessageBox.Show("comboboxInfo.txt 파일이 존재하지 않습니다!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void Init(double _activeTime, string _joint) // 노트를 새로 생성할 때 전처리를 위해 사용하는 함수
        {
            _textbox_activetime.Text = _activeTime.ToString();
            _combobox_joint.SelectedItem = _joint;

            _button_OK.Text = "노트 생성";
            _isModify = false;
        }

        public void Init(Note _note, int _index) // 기존 노트를 수정할 때 전처리를 위해 사용하는 함수
        {
            _textbox_activetime.Text = _note._activeTime.ToString();
            _combobox_joint.SelectedItem = _note._joint;
            _combobox_activenote.Text = _note._activeNote;
            _combobox_sfxName.Text = _note._SFXname;
            _combobox_animation.Text = _note._animation;
            _getIndex = _index;

            _button_OK.Text = "노트 수정";
            _isModify = true;
        }

        private void _button_OK_Click(object sender, EventArgs e)
        {
            if (_isModify) // 수정상태
                _parentForm.ModifyNote(_getIndex, Convert.ToDouble(_textbox_activetime.Text), _combobox_joint.Text, _combobox_activenote.Text, _combobox_sfxName.Text, _combobox_animation.Text);
            else // 생성상태
                _parentForm.MakeNote(Convert.ToDouble(_textbox_activetime.Text), _combobox_joint.Text, _combobox_activenote.Text, _combobox_sfxName.Text, _combobox_animation.Text);
            Close();
        }

        private void NoteInfoEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (_isModify) // 수정상태
                    _parentForm.ModifyNote(_getIndex, Convert.ToDouble(_textbox_activetime.Text), _combobox_joint.Text, _combobox_activenote.Text, _combobox_sfxName.Text, _combobox_animation.Text);
                else // 생성상태
                    _parentForm.MakeNote(Convert.ToDouble(_textbox_activetime.Text), _combobox_joint.Text, _combobox_activenote.Text, _combobox_sfxName.Text, _combobox_animation.Text);
                Close();
            }
        }

        private void _textbox_activenote_TextChanged(object sender, EventArgs e)
        {

        }

        private void _textbox_animation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
