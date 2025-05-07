using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmSubjectEdit : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        Boolean mychekCode = false;

        public frmSubjectEdit()
        {
            InitializeComponent();
        }

        private void frmSubjectEdit_Load(object sender, EventArgs e)
        {
            // Load all subjects into the DataGridView
            SqlDataAdapter myda = new SqlDataAdapter("SELECT SubjectID AS [کد درس], SubjectName AS [نام درس], TeacherID AS [کد معلم ] FROM Subjects ORDER BY SubjectID DESC", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void txtSubjectCode_TextChanged(object sender, EventArgs e)
        {
            // Load subject details when the subject code changes
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT SubjectName, TeacherID FROM Subjects WHERE SubjectID='" + Convert.ToInt32(txtSubjectID.Text) + "'", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                txtSubjectName.Text = mydt.Rows[0].ItemArray[0].ToString();
                txtSubjectTeacher.Text = mydt.Rows[0].ItemArray[1].ToString();
            }
            catch (Exception)
            {
                txtSubjectName.Clear();
                txtSubjectTeacher.Clear();
                mychekCode = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Update subject information
            if (mychekCode == false)
            {
                txtSubjectID.Focus();
                MessageBox.Show("کد درس نامعتبر است");
            }
            else if (string.IsNullOrEmpty(txtSubjectID.Text))
            {
                txtSubjectID.Focus();
            }
            else if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                txtSubjectName.Focus();
            }
            else if (string.IsNullOrEmpty(txtSubjectTeacher.Text))
            {
                txtSubjectTeacher.Focus();
            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand myupdatecommand = new SqlCommand("UPDATE Subjects SET SubjectName = @SubjectName, TeacherID = @TeacherID WHERE (SubjectID = @SubjectID)", myconnection);
                    myupdatecommand.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherID", txtSubjectTeacher.Text);
                    myupdatecommand.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubjectID.Text));
                    myupdatecommand.ExecuteNonQuery();
                    myconnection.Close();
                    frmSubjectEdit_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete subject information
            if (string.IsNullOrEmpty(txtSubjectID.Text))
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
                    SqlCommand mydeletecommand = new SqlCommand("DELETE FROM Subjects WHERE SubjectID = @SubjectID", myconnection);
                    mydeletecommand.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubjectID.Text));
                    int rowsAffected = mydeletecommand.ExecuteNonQuery();
                    myconnection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("درس با موفقیت حذف شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmSubjectEdit_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("درسی با این کد یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در حذف: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    myconnection.Close();
                }
            }
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }
    }
}