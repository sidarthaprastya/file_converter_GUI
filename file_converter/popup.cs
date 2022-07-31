using System;
using System.Media;
using System.Windows.Forms;

namespace file_converter
{
    public partial class popup : Form
    {
        public popup()
        {
            InitializeComponent();
            label_notify.Text = file_converter.notification;
            SystemSounds.Exclamation.Play();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
