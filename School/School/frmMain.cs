using System;
using System.Windows.Forms;

namespace School
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ثبتدانشآموزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent mystudent = new frmStudent();
            mystudent.ShowDialog();
        }

        private void ثبتاطلاعاتمعلمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeachers myfrmteachers = new frmTeachers();
            myfrmteachers.ShowDialog();
        }

        private void ثبتاطلاعتدرسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject mysubjects = new frmSubject();
            mysubjects.ShowDialog();
        }

        private void اطلاعاتمعلمToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTeacherSearch myfrmsearchTeacher = new frmTeacherSearch();
            myfrmsearchTeacher.ShowDialog();
        }

        private void اطلاعاتدانشآموزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchStudent mystudent = new frmSearchStudent();
            mystudent.ShowDialog();
        }

        private void ویرایشاطلاعاتمعلمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeacherEdit myTeacherEdit = new frmTeacherEdit();
            myTeacherEdit.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = ClassName.username;
            toolStripStatusLabel2.Text = ShamsiDate.ConvertToShamsi(DateTime.Now);
            toolStripStatusLabel5.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        private void ثبتاطلاعاتکاربرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser myuser = new frmUser();
            myuser.ShowDialog();

        }

        private void ویرایشاطلاعاتدانشآموزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentEdit myfrmStudentEdit = new frmStudentEdit();
            myfrmStudentEdit.ShowDialog();

        }

        private void ویرایشاطلاعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectEdit mysubjectedit = new frmSubjectEdit();
            mysubjectedit.ShowDialog();
        }
    }
}
