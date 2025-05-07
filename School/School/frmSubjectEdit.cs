using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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
            SqlDataAdapter myda = new SqlDataAdapter("SELECT SubjectID AS [کد درس], SubjectName AS [نام درس], TeacherID AS [نام معلم] FROM Subjects ORDER BY SubjectID DESC", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void txtSubjectID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT   SubjectName, TeacherID   from Subjects" +
              " where SubjectID='" + Convert.ToInt32(txtSubjectID.Text) + "'", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                txtSubjectName.Text = mydt.Rows[0].ItemArray[0].ToString();
                txtTeacherID.Text = mydt.Rows[0].ItemArray[1].ToString();
     
                mychekCode = true;
            }
            catch (Exception)
            {
                txtSubjectName.Clear();
                txtTeacherID.Clear();
           
                mychekCode = false;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
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
                        txtSubjectName.Clear();
                        txtTeacherID.Clear();
                        txtSubjectID.Clear();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!mychekCode)
            {
                MessageBox.Show("کد درس نامعتبر است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) || string.IsNullOrWhiteSpace(txtTeacherID.Text))
            {
                MessageBox.Show("لطفاً تمام اطلاعات را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                myconnection.Open();
                SqlCommand myupdatecommand = new SqlCommand(@"UPDATE Subjects 
                SET SubjectName = @SubjectName, 
                    TeacherID = @TeacherID 
                WHERE SubjectID = @SubjectID", myconnection);

                myupdatecommand.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                myupdatecommand.Parameters.AddWithValue("@TeacherID", txtTeacherID.Text);
                myupdatecommand.Parameters.AddWithValue("@SubjectID", Convert.ToInt32(txtSubjectID.Text));
                myupdatecommand.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmSubjectEdit_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا: " + ex.Message);
            }
            finally
            {
                myconnection.Close();
            }
        }

        private void txtSubjectID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtSubjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtTeacherID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
