using System.Diagnostics;

namespace Strict_Time
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = comboBox1.Text != "";
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            button1.Enabled = comboBox1.Text != "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            tmr.Start();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (Math.Floor(((TimeSpan)dtp.Value.TimeOfDay - DateTime.Now.TimeOfDay).TotalSeconds) == 0)
            {
                switch (comboBox1.Text)
                {
                    case "Log Out":
                        Process.Start(@"C:\Windows\System32\cmd.exe", "/C shutdown /l");
                        break;
                    case "Hibernate":
                        Process.Start(@"C:\Windows\System32\cmd.exe", "/C shutdown /h");
                        break;
                    case "Sleep":
                        Process.Start(@"C:\Windows\System32\cmd.exe", "/C rundll32.exe powrprof.dll, SetSuspendState Sleep");
                        break;
                    case "Shut Down":
                        Process.Start(@"C:\Windows\System32\cmd.exe", "/C shutdown /s");
                        break;
                    case "Shut Down (No Warning)":
                        Process.Start(@"C:\Windows\System32\cmd.exe", " /C shutdown /p");
                        break;
                }
                tmr.Stop();

            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void scnds_Tick(object sender, EventArgs e)
        {
            
        }
    }
}