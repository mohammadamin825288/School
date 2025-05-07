using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmStudent : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        public frmStudent()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SqlDataAdapter myda = new SqlDataAdapter(" SELECT StudentID AS [ کد دانش آموز], StudentFname AS [نام دانش آموز],StudentLname AS [نام خانوادگی], StudentPhone AS [تلفن],StudentAddress AS [آدرس] from Students order by StudentID desc", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
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
            else if (string.IsNullOrEmpty(txtClassID.Text))
            {
                txtClassID.Focus();

            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand mycommand = new SqlCommand("INSERT INTO Students(StudentFname,StudentLname,StudentPhone,StudentAddress,StudentClassID)Values(@StudentFname,@StudentLname,@StudentPhone,@StudentAddress,@StudentClassID)", myconnection);
                    mycommand.Parameters.AddWithValue("@StudentFname", txtFname.Text);
                    mycommand.Parameters.AddWithValue("@StudentLname", txtLname.Text);
                    mycommand.Parameters.AddWithValue("@StudentPhone", txtPhone.Text);
                    mycommand.Parameters.AddWithValue("@StudentAddress", txtAddress.Text);
                    mycommand.Parameters.AddWithValue("@StudentClassID", Convert.ToInt32(txtClassID.Text));
                    mycommand.ExecuteNonQuery();
                    myconnection.Close();
                    MessageBox.Show("دانش آموز جدید با موفقیت ثبت گردید ");
                    Form1_Load(sender, e);
                }
                catch (Exception ex)
                {


                    MessageBox.Show("خطا: " + ex.Message);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
