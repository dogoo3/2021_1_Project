using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteMaker
{
    enum MP3MODE
    {
        Play,
        Stop,
        Pause,
    };

    public partial class Form1 : Form
    {
        NoteInfoEditor _noteinfoEditor;

        Timer _timer;
        OpenFileDialog _ofd_music, _ofd_Getnote;
        SaveFileDialog _ofd_Savenote;
        MediaPlayer.MediaPlayerClass _mp3player;

        StreamReader _streamReader;
        StreamWriter _streamWriter;

        List<Note> _note = new List<Note>();
        Note _inputValue;

        string _temp;
        string[] _temparray;

        public Form1()
        {
            InitializeComponent();
            #region AssignOFD
            _ofd_music = new OpenFileDialog();
            _ofd_music.InitialDirectory = Application.StartupPath;
            _ofd_music.Title = "악곡 가져오기";
            _ofd_music.FileName = "*.mp3";
            _ofd_music.Filter = "그림 파일 (*.mp3) | *.mp3";

            _ofd_Getnote = new OpenFileDialog();
            _ofd_Getnote.InitialDirectory = Application.StartupPath;
            _ofd_Getnote.Title = "채보 불러오기";
            _ofd_Getnote.FileName = "*.txt";
            _ofd_Getnote.Filter = "메모장 파일 (*.txt) | *.txt";

            _ofd_Savenote = new SaveFileDialog();
            _ofd_Savenote.InitialDirectory = Application.StartupPath;
            _ofd_Savenote.Title = "채보 저장하기";
            _ofd_Savenote.FileName = "*.txt";
            _ofd_Savenote.Filter = "메모장 파일 (*.txt) | *.txt";
            #endregion
            #region AssignMP3Player
            _mp3player = new MediaPlayer.MediaPlayerClass();
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += _timer_tick;
            #endregion
            _noteinfoEditor = new NoteInfoEditor(this);
        }

        private void _timer_tick(object sender, EventArgs e)
        {
            #region Trackbar and Show time
            // 재생 이벤트가 실행되지 않으면 이 변수에는 값이 할당이 안 된다고 하는데, 재생 이벤트를 강제로 실행시키는 법을 모르겠음.
            _trackbar_musicline.Maximum = (int)_mp3player.Duration; // mp3 파일의 전체 재생 시간 설정(이걸 왜 여기서 해줘야하는지는 의문임.)
            MaxPlayTime.Text = _mp3player.Duration.ToString();
            _trackbar_musicline.Value = (int)_mp3player.CurrentPosition;

            _textbox_playtime.Text = _mp3player.CurrentPosition.ToString();

            SetJoint("Lshoulder", _mp3player.CurrentPosition, _picture_joint_Lshoulder);
            SetJoint("Rshoulder", _mp3player.CurrentPosition, _picture_joint_Rshoulder);
            SetJoint("Lhand", _mp3player.CurrentPosition, _picture_joint_Lhand);
            SetJoint("Rhand", _mp3player.CurrentPosition, _picture_joint_Rhand);
            SetJoint("Lknee", _mp3player.CurrentPosition, _picture_joint_Lknee);
            SetJoint("Rknee", _mp3player.CurrentPosition, _picture_joint_Rknee);
            SetJoint("Lfoot", _mp3player.CurrentPosition, _picture_joint_Lfoot);
            SetJoint("Rfoot", _mp3player.CurrentPosition, _picture_joint_Rfoot);
            #endregion
        }

        #region BUTTONS
        private void _button_loadmp3_Click(object sender, EventArgs e)
        {
            if(_ofd_music.ShowDialog() == DialogResult.OK)
            {
                _mp3player.FileName = _ofd_music.FileName; // mp3 플레이어에 파일 경로 저장
                _textbox_nowmusic.Text = _ofd_music.SafeFileName; // textbox에 불러온 파일 이름 표시

                _trackbar_musicline.Value = (int)_mp3player.CurrentPosition; // mp3 파일의 현재 재생 위치

                _trackbar_volume.Value = _mp3player.Volume; // 불러온 mp3 파일의 볼륨으로 초기화
                _trackbar_volume.Maximum = _mp3player.Volume + 600; // 볼륨을 기준으로 상수값을 정해 조절폭을 정함
                _trackbar_volume.Minimum = _mp3player.Volume - 600;
                
                _trackbar_volume.Enabled = true; // 볼륨 조절 트랙바 활성화
                _trackbar_musicline.Enabled = true; // 음악 재생 위치 조절 트랙바 활성화
                _button_play.Enabled = true;
                _button_stop.Enabled = true;
                ChangeState(MP3MODE.Stop);
            }
        }

        private void _button_loadnote_Click(object sender, EventArgs e) // 노트 파일 불러오기
        {
            if(_ofd_Getnote.ShowDialog() == DialogResult.OK)
            {
                _streamReader = new StreamReader(_ofd_Getnote.FileName);
                _textbox_nownote.Text = _ofd_Getnote.SafeFileName;
                while (_streamReader.Peek() != -1)
                {
                    _temp = _streamReader.ReadLine();
                    _temparray = _temp.Split('/');
                    
                    if (_temparray.Length == 3) // Animation이 작성되지 않은 경우
                        _inputValue = new Note(Convert.ToDouble(_temparray[0]), _temparray[1], _temparray[2]);
                    else // Animation이 작성된 경우
                        _inputValue = new Note(Convert.ToDouble(_temparray[0]), _temparray[1], _temparray[2], _temparray[3]);

                    _note.Add(_inputValue); // 노트에 집어넣고
                    _listbox_noteInfo.Items.Add(_note.Last()._showlist); // 리스트에 집어넣음
                }
                _streamReader.Close();
            }
        }
        private void _button_savenote_Click(object sender, EventArgs e) // 노트 파일 저장하기
        {
            if(_textbox_nownote.Text != "") // 불러온 파일이 있을 경우
            {
                SetStream(_ofd_Getnote);
                MessageBox.Show("저장되었습니다!");
            }
            else
            {
                if(_ofd_Savenote.ShowDialog() == DialogResult.OK)
                    SetStream(_ofd_Savenote);
            }
        }
        private void SetStream<T>(T _fd) where T : FileDialog
        {
            _streamWriter = new StreamWriter(_fd.FileName);

            for (int i = 0; i < _note.Count; i++)
                _streamWriter.WriteLine(_note[i]._showlist);
            _streamWriter.Close();
        }

        private void _button_play_Click(object sender, EventArgs e)
        {
            ChangeState(MP3MODE.Play);
        }
        private void _button_stop_Click(object sender, EventArgs e)
        {
            ChangeState(MP3MODE.Pause);
        }
        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e) // 메인 키 입력
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!string.IsNullOrEmpty(_mp3player.FileName))
                {
                    if (_mp3player.PlayState == MediaPlayer.MPPlayStateConstants.mpPlaying)
                        ChangeState(MP3MODE.Pause);
                    else
                        ChangeState(MP3MODE.Play);
                }
                else
                    MessageBox.Show("음악이 없습니다!","경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (_mp3player.PlayState == MediaPlayer.MPPlayStateConstants.mpPaused) // 음악이 일시정지되어있어야 타임 조작 가능
                {
                    if (Convert.ToDouble(_textbox_playtime.Text) >= 0 && Convert.ToDouble(_textbox_playtime.Text) <= _mp3player.Duration) // 음악이 노래 범위 안이어야 함
                    {
                        _mp3player.CurrentPosition = Convert.ToDouble(_textbox_playtime.Text);
                        _trackbar_musicline.Value = (int)_mp3player.CurrentPosition;

                        SetJoint("Lshoulder", _mp3player.CurrentPosition, _picture_joint_Lshoulder);
                        SetJoint("Rshoulder", _mp3player.CurrentPosition, _picture_joint_Rshoulder);
                        SetJoint("Lhand", _mp3player.CurrentPosition, _picture_joint_Lhand);
                        SetJoint("Rhand", _mp3player.CurrentPosition, _picture_joint_Rhand);
                        SetJoint("Lknee", _mp3player.CurrentPosition, _picture_joint_Lknee);
                        SetJoint("Rknee", _mp3player.CurrentPosition, _picture_joint_Rknee);
                        SetJoint("Lfoot", _mp3player.CurrentPosition, _picture_joint_Lfoot);
                        SetJoint("Rfoot", _mp3player.CurrentPosition, _picture_joint_Rfoot);
                        label1.Focus();
                    }
                    else
                        MessageBox.Show("시간은 0~" + _mp3player.Duration + " 사이로 표기해주세요!", "범위값 오류!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #region JOINTSET
        private void SetJoint(string joint, double currentPosition, PictureBox pictureBox)
        {
            if (_note.Count == 0) // 노트안에 아무것도 없으면 실행하지 않음.
                return;

            if (currentPosition >= _note[_note.Count / 2]._activeTime) // 중간 타임보다 찾으려는 시간이 크면
            {
                for(int i=_note.Count-1;i>=0;i--)
                {
                    if (CheckTime(joint, currentPosition, pictureBox, i))
                        return;
                }
            }
            else
            {
                for (int i = 0; i < _note.Count; i++)
                {
                    if (CheckTime(joint, currentPosition, pictureBox, i))
                        return;
                }
            }
            pictureBox.Image = null;
        }

        private bool CheckTime(string joint, double currentPosition, PictureBox pictureBox, int i)
        {
            if (_note[i]._activeTime >= currentPosition && _note[i]._activeTime <= currentPosition + 0.05) // 시간이 맞고(보이게 하기 위해 표현시작 시간부터 0.05초의 텀을 둠)
            {
                if (_note[i]._joint == joint) // 관절이 맞으면
                {
                    pictureBox.Image = Properties.Resources.circle;
                    return true;
                }
            }
            return false;
        }
        #endregion

        private void ChangeState(MP3MODE _mode)
        {
            switch (_mode)
            {
                case MP3MODE.Play:
                case MP3MODE.Pause:
                    if (!string.IsNullOrEmpty(_mp3player.FileName))
                    {
                        if(_mode == MP3MODE.Play)
                        {
                            _mp3player.Play();
                            _timer.Start();
                            _textbox_playtime.Enabled = false;
                        }
                        else if(_mode == MP3MODE.Pause)
                        {
                            _mp3player.Pause();
                            _timer.Stop();
                            _textbox_playtime.Enabled = true;
                            _textbox_playtime.Text = _mp3player.CurrentPosition.ToString();
                        }
                    }
                    else
                        MessageBox.Show("음악이 없습니다!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case MP3MODE.Stop:
                    _mp3player.Stop();
                    _timer.Stop();
                    break;
            }
            label1.Focus();
        }

        #region ControlVolume
        private void _trackbar_volume_Scroll(object sender, EventArgs e)
        {
            _mp3player.Volume = _trackbar_volume.Value;
            if (_mp3player.Volume <= _trackbar_volume.Minimum)
                _mp3player.Mute = true;
            else
                _mp3player.Mute = false;
        }
        #endregion

        #region MoveMusicLine
        private void _trackbar_musicline_Scroll(object sender, EventArgs e)
        {
            _mp3player.CurrentPosition = _trackbar_musicline.Value;
        }
        #endregion

        private void _listbox_noteInfo_DoubleClick(object sender, EventArgs e) // 리스트 박스를 더블클릭했을 때
        {
            // SelectedIndex == -1 -> 아무것도 선택된 것이 없음.
            MessageBox.Show(_listbox_noteInfo.SelectedIndex.ToString());
        }

        private void _listbox_noteInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 이 listbox를 클릭했을 때
        }

        private void _textbox_playtime_KeyPress(object sender, KeyPressEventArgs e) // 숫자와 소수점만 받아야하므로 별도의 처리 필요 
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }

        #region ClickJoint
        private void _picture_joint_lShoulder_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Lshoulder");
        }
        private void _picture_joint_Rshoulder_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Rshoulder");
        }

        private void _picture_joint_Lhand_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Lhand");
        }

        private void _picture_joint_Rhand_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Rhand");
        }

        private void _picture_joint_Lknee_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Lknee");
        }

        private void _picture_joint_Rknee_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Rknee");
        }

        private void _picture_joint_Lfoot_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Lfoot");
        }

        private void _picture_joint_Rfoot_Click(object sender, EventArgs e)
        {
            OpenNoteInfoEditor("Rfoot");
        }

        private void OpenNoteInfoEditor(string _joint)
        {
            if (_mp3player.PlayState == MediaPlayer.MPPlayStateConstants.mpPaused)
            {
                _noteinfoEditor.Init(_mp3player.CurrentPosition, _joint);
                _noteinfoEditor.ShowDialog();
            }
        }
        #endregion

        #region InputNote
        public bool MakeNote(double _activeTime, string _joint, string _activeNote, string _animation = "")
        {
            if (_note.Count == 0) // 노트 안에 아무것도 없으면
            {
                InsertNote(0, _activeTime, _joint, _activeNote, _animation);
                return true;
            }
            if(_note.Count == 1)
            {
                if(_note[0]._activeTime > _activeTime)
                    InsertNote(0, _activeTime, _joint, _activeNote, _animation);
                else
                    InsertNote(1, _activeTime, _joint, _activeNote, _animation);
                return true;
            }

            if (_activeTime >= _note[_note.Count / 2]._activeTime) // 중간 타임보다 넣으려는 시간이 크면
            {
                for (int i = _note.Count - 1; i >= 0; i--)
                {
                    if (_activeTime > _note[i]._activeTime) // 넣을려는 노트의 시간이 더 작으면
                    {
                        InsertNote(i+1, _activeTime, _joint, _activeNote, _animation);
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < _note.Count; i++)
                {
                    if(_activeTime < _note[i]._activeTime) // 넣을려는 노트의 시간이 더 커지면
                    {
                        InsertNote(i, _activeTime, _joint, _activeNote, _animation);
                        return true;
                    }
                }
            }
            return false;
        }

        private void InsertNote(int i, double _activeTime, string _joint, string _activeNote, string _animation)
        {
            _inputValue = new Note(_activeTime, _joint, _activeNote, _animation);
            _note.Insert(i, _inputValue); // 노트를 중간에 삽입
            _listbox_noteInfo.Items.Insert(i, _inputValue._showlist);
        }
        #endregion
    }
}
