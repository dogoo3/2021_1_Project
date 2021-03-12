using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMaker
{
    public class Note
    {
        public string _showlist; // Listbox에 보여질 항목의 이름
        public double _activeTime; // 노트 활성화 시간
        public string _joint; // 활성화시킬 위치의 관절
        public string _activeNote; // 활성화시킬 노트의 이름
        public string _animation; // 같이 활성화시킬 애니메이션

        public Note()
        {
            _showlist = "";
            _activeTime = 0.0;
            _joint = "";
            _animation = "";
            _activeNote = "";
        }

        public Note(double _activeTime, string _joint, string _activeNote, string _animation = "")
        {
            this._activeTime = _activeTime;
            this._joint = _joint;
            this._activeNote = _activeNote;
            this._animation = _animation;

            if (_animation == "")
                _showlist = _activeTime.ToString() + "/" + _joint + "/" + _activeNote;
            else
                _showlist = _activeTime.ToString() + "/" + _joint + "/" + _activeNote + "/" + _animation;
        }
    }
}
