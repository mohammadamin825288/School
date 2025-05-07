using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace School
{
    public partial class frmSubject : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");

        public frmSubject()
        {
            InitializeComponent();
        }

        private void frmSubject_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter(" SELECT  SubjectID AS [کد درس], SubjectName AS [نام درس ], TeacherID AS [کد معلم]from Subjects order by SubjectID desc", myconnection);
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

            if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                txtSubjectName.Focus();
            }
            else if (string.IsNullOrEmpty(txtTeacherID.Text))
            {
                txtTeacherID.Focus();
            }
            else
            {

                try
                {
                    myconnection.Open();
                    SqlCommand mycommand = new SqlCommand("INSERT INTO Subjects(SubjectName,TeacherID)Values(@SubjectName,@TeacherID)", myconnection);
                    mycommand.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                    mycommand.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(txtTeacherID.Text));
                    mycommand.ExecuteNonQuery();
                    myconnection.Close();
                    MessageBox.Show("معلم جدید با موفقیت ثبت گردید ");
                    frmSubject_Load(sender, e);
                }
                catch (Exception ex)
                {


                    MessageBox.Show("خطا: " + ex.Message);
                }
            }
        }

        private void txtSubjectName_TextChanged(object sender, EventArgs e)
        {

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
