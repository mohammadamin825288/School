using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmTeachers : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");

        public frmTeachers()
        {
            InitializeComponent();
        }

        private void frmTeachers_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter(" SELECT  TeacherID AS [کد معلم], TeacherFname AS [نام ], TeacherLname AS [نام خانوادگی], TeacherSubject AS [درس معلم],TeacherAddress AS [آدرس معلم] from Teachers order by TeacherID desc", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFname.Text))
            {
                txtFname.Focus();
            }
            else if (string.IsNullOrEmpty(txtLname.Text))
            {
                txtLname.Focus();
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Focus();

            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                txtAddress.Focus();

            }
            else if (string.IsNullOrEmpty(txtSubject.Text))
            {
                txtSubject.Focus();

            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand mycommand = new SqlCommand("INSERT INTO Teachers(TeacherFname,TeacherLname,TeacherSubject,TeacherAddress,TeacherPhone)Values(@TeacherFname,@TeacherLname,@TeacherSubject,@TeacherAddress,@TeacherPhone)", myconnection);
                    mycommand.Parameters.AddWithValue("@TeacherFname", txtFname.Text);
                    mycommand.Parameters.AddWithValue("@TeacherLname", txtLname.Text);
                    mycommand.Parameters.AddWithValue("@TeacherSubject", Convert.ToInt32(txtSubject.Text));
                    mycommand.Parameters.AddWithValue("@TeacherAddress", txtAddress.Text);
                    mycommand.Parameters.AddWithValue("@TeacherPhone", txtPhone.Text);
                    mycommand.ExecuteNonQuery();
                    myconnection.Close();
                    MessageBox.Show("معلم   جدید با موفقیت ثبت گردید ");
                    frmTeachers_Load(sender, e);
                }
                catch (Exception ex)
                {


                    MessageBox.Show("خطا: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
