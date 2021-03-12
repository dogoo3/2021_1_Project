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
        public NoteInfoEditor()
        {
            InitializeComponent();
        }

        public void Init(double _activeTime, string _joint = "", string _activeNote = "", string _animation = "")
        {
            _textbox_activetime.Text = _activeTime.ToString();
            _textbox_joint.Text = _joint;
            _textbox_activenote.Text = _activeNote;
            _textbox_animation.Text = _animation;
        }
    }
}
