using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmSubjectEdit : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        bool myCheckCode = false;

        public frmSubjectEdit()
        {
            InitializeComponent();
        }

        private void frmSubjectEdit_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            SqlDataAdapter myda = new SqlDataAdapter(
                "SELECT SubjectID AS [کد درس], SubjectName AS [نام درس], TeacherID AS [کد معلم] FROM Subjects ORDER BY SubjectID DESC",
                myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectID.Text))
            {
                ClearFields();
                myCheckCode = false;
                return;
            }

            try
            {
                SqlDataAdapter myda = new SqlDataAdapter(
                    "SELECT SubjectName, TeacherID FROM Subjects WHERE SubjectID = @id",
                    myconnection);
                myda.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(txtSubjectID.Text));

                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                if (mydt.Rows.Count > 0)
                {
                    txtSubjectName.Text = mydt.Rows[0]["SubjectName"].ToString();
                    txtSubjectTeacher.Text = mydt.Rows[0]["TeacherID"].ToString();
                    myCheckCode = true;
                }
                else
                {
                    ClearFields();
                    myCheckCode = false;
                }
            }
            catch
            {
                ClearFields();
                myCheckCode = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!myCheckCode)
            {
                MessageBox.Show("کد درس نامعتبر است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) ||
                string.IsNullOrWhiteSpace(txtSubjectTeacher.Text))
            {
                MessageBox.Show("لطفاً همه فیلدها را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                myconnection.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Subjects SET SubjectName = @name, TeacherID = @teacher WHERE SubjectID = @id",
                    myconnection);
                cmd.Parameters.AddWithValue("@name", txtSubjectName.Text);
                cmd.Parameters.AddWithValue("@teacher", txtSubjectTeacher.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtSubjectID.Text));
                cmd.ExecuteNonQuery();
                myconnection.Close();

                MessageBox.Show("اطلاعات با موفقیت به‌روزرسانی شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در به‌روزرسانی: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myconnection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectID.Text))
            {
                MessageBox.Show("لطفاً کد درس را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubjectID.Focus();
                return;
            }

            DialogResult result = MessageBox.Show("آیا از حذف این درس مطمئن هستید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    myconnection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Subjects WHERE SubjectID = @id", myconnection);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtSubjectID.Text));
                    int rows = cmd.ExecuteNonQuery();
                    myconnection.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("درس با موفقیت حذف شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSubjects();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("درسی با این کد یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در حذف: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myconnection.Close();
                }
            }
        }

        private void ClearFields()
        {
            txtSubjectName.Clear();
            txtSubjectTeacher.Clear();
        }
    }
}
