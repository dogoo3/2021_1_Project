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
            _noteinfoEditor = new NoteInfoEditor();
        }

        private void _timer_tick(object sender, EventArgs e)
        {
            #region Trackbar and Show time
            // 재생 이벤트가 실행되지 않으면 이 변수에는 값이 할당이 안 된다고 하는데, 재생 이벤트를 강제로 실행시키는 법을 모르겠음.
            _trackbar_musicline.Maximum = (int)_mp3player.Duration; // mp3 파일의 전체 재생 시간 설정(이걸 왜 여기서 해줘야하는지는 의문임.)
            MaxPlayTime.Text = _mp3player.Duration.ToString();
            _trackbar_musicline.Value = (int)_mp3player.CurrentPosition;

            _textbox_playtime.Text = _mp3player.CurrentPosition.ToString();
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
            if(_ofd_Savenote.ShowDialog() == DialogResult.OK)
            {
                _streamWriter = new StreamWriter(_ofd_Savenote.FileName);

                for (int i = 0; i < _note.Count; i++)
                    _streamWriter.WriteLine(_note[i]);
                _streamWriter.Close();
            }
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
                if (_mp3player.PlayState == MediaPlayer.MPPlayStateConstants.mpPaused)
                {
                    if (Convert.ToDouble(_textbox_playtime.Text) >= 0 && Convert.ToDouble(_textbox_playtime.Text) <= _mp3player.Duration)
                    {
                        _mp3player.CurrentPosition = Convert.ToDouble(_textbox_playtime.Text);
                        _trackbar_musicline.Value = (int)_mp3player.CurrentPosition;
                        label1.Focus();
                    }
                    else
                        MessageBox.Show("시간은 0~" + _mp3player.Duration + " 사이로 표기해주세요!", "범위값 오류!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

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

        private void _picture_joint_lShoulder_Click(object sender, EventArgs e)
        {
            if(_mp3player.PlayState == MediaPlayer.MPPlayStateConstants.mpPaused)
            {
                // note._activeTime == _mp3Player.CurretnPosition && note._joint == "LShoulder"
                _noteinfoEditor.Init(_mp3player.CurrentPosition);
                _noteinfoEditor.ShowDialog();
            }
        }
    }
}
