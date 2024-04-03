using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Reshetilov_IKM722a_Course_project
{
    public partial class Form1 : Form
    {

        private bool Mode; // ����� ������� / �������� �������� �����

        private MajorWork MajorObject; // ��������� ��'���� ����� MajorWork

        public Form1()
        {
            InitializeComponent();
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show("������ 25 ������", "�����");// ��������� ����������� "������ 25 ������" �� �����
            tClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MajorObject = new MajorWork();
            MajorObject.SetTime();
            About A = new About(); // ��������� ����� About
            A.tAbout.Start();
            A.ShowDialog(); // ����������� ���������� ���� About
            this.Mode = true;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                if (Mode)
                    tbInput.Enabled = true;// ����� ������� �������� tbInput.Focus();
                tClock.Start();
                bStart.Text = "����"; // ���� ������ �� ������ �� "����"
                this.Mode = false;
                ����ToolStripMenuItem.Text = "����";
            }
            else
            {
                tbInput.Enabled = false;
                tClock.Stop();
                bStart.Text = "����";// ���� ������ �� ������ �� "����"
                this.Mode = true;
                MajorObject.Write(tbInput.Text);// ����� ����� � ��'���
                MajorObject.Task();// ������� �����
                label1.Text = MajorObject.Read();// ³���������� ����������
                ����ToolStripMenuItem.Text = "�����";
            }
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            tClock.Stop();
            tClock.Start();
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("������������ ������", "�������");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string s;
            s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
            MessageBox.Show(s, "��� ������ ��������"); // ��������� ���� ������ �������� � ����������� "��� ������ ��������" �� �����
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)// ������ ���������� ���� ���������� �����
            {
                MessageBox.Show(sfdSave.FileName);
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK) // ������ ���������� ���� �������� �����
            {
                MessageBox.Show(ofdOpen.FileName);
            }
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] disks = System.IO.Directory.GetLogicalDrives(); // ��������� ����� � ������ �����
            string disk = "";
            for (int i = 0; i < disks.Length; i++)
            {
                try
                {
                    System.IO.DriveInfo D = new System.IO.DriveInfo(disks[i]);
                    double totalSizeGB = D.TotalSize / (1024.0 * 1024.0 * 1024.0);
                    double totalFreeSpaceGB = D.TotalFreeSpace / (1024.0 * 1024.0 * 1024.0);
                    disk += D.Name + "-" + totalSizeGB.ToString("F2") + "GB -" + totalFreeSpaceGB.ToString("F2") + "GB" + (char)13;
                }
                catch
                {
                    disk += disks[i] + "- �� �������" + (char)13; // ���� ������� �� �������, �� ��������� �� ����� ��� �������� � ����������� ��� �������
                }
            }

            MessageBox.Show(disk, "������������");
        }
    }
}
