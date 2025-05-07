using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace School
{
    public partial class frmTeacherEdit : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        Boolean mychekCode = false;
        public frmTeacherEdit()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void frmTeacherEdit_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter(" SELECT  TeacherID AS [کد معلم], TeacherFname AS [نام ], TeacherLname AS [نام خانوادگی], TeacherSubject AS [درس معلم],TeacherAddress AS [آدرس معلم] from Teachers order by TeacherID desc", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void txtTeacherCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT  TeacherFname , TeacherLname , TeacherSubject , TeacherAddress , TeacherPhone  from Teachers where TeacherID='" + Convert.ToInt32(txtTeacherCode.Text) + "'", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                txtTeacherName.Text = mydt.Rows[0].ItemArray[0].ToString();
                txtTeacherLname.Text = mydt.Rows[0].ItemArray[1].ToString();
                txtSubjectCode.Text = mydt.Rows[0].ItemArray[2].ToString();
                txtAddress.Text = mydt.Rows[0].ItemArray[3].ToString();
                txtPhone.Text = mydt.Rows[0].ItemArray[4].ToString();

            }
            catch (Exception)
            {
                txtTeacherName.Clear();
                txtTeacherLname.Clear();
                txtSubjectCode.Clear();
                txtAddress.Clear();
                txtPhone.Clear();
                mychekCode = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (mychekCode == false)
            {
                txtTeacherCode.Focus();
                MessageBox.Show("کد معلم نا معتبر");

            }
            else if (string.IsNullOrEmpty(txtTeacherCode.Text))
            {
                txtTeacherCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtTeacherName.Text))
            {
                txtTeacherName.Focus();
            }
            else if (string.IsNullOrEmpty(txtTeacherLname.Text))
            {
                txtTeacherLname.Focus();

            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Focus();

            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                txtAddress.Focus();

            }


            else
            {          //CustomerID = @CustomerID    CustomerCellphone

                try
                {
                    myconnection.Open();
                    SqlCommand myupdatecommand = new SqlCommand("UPDATE Teachers SET  TeacherFname = @TeacherFname, Teacherlname = @Teacherlname, TeacherSubject = @TeacherSubject, TeacherAddress = @TeacherAddress, TeacherPhone = @TeacherPhone" +
                     " WHERE (TeacherID = @TeacherID)", myconnection);
                    myupdatecommand.Parameters.AddWithValue("@TeacherFname", txtTeacherName.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherLname", txtTeacherLname.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherSubject", txtSubjectCode.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherAddress", txtAddress.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherPhone", txtPhone.Text);
                    myupdatecommand.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(txtTeacherCode.Text));
                    myupdatecommand.ExecuteNonQuery();
                    myconnection.Close();
                    frmTeacherEdit_Load(sender, e);
                }
                catch (Exception ex)
                {


                    MessageBox.Show("خطا: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTeacherCode.Text))          
            {
                txtTeacherCode.Focus();
            }
            else if (mychekCode == false)
            {
                txtTeacherCode.Focus();
                MessageBox.Show("کد معلم نامعتبر است");


            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand mydelete = new SqlCommand("delete from Teachers where TeacherID=@TeacherID", myconnection);
                    mydelete.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(txtTeacherCode.Text));
                    mydelete.ExecuteNonQuery();
                    myconnection.Close();

                    MessageBox.Show("اطلاعات معلم حذف گردید");
                    txtTeacherName.Clear();
                    txtTeacherLname.Clear();
                    txtSubjectCode.Clear();
                    txtAddress.Clear();
                    txtPhone.Clear();

                    frmTeacherEdit_Load(sender, e);
                }
                catch (SqlException)
                {

                     MessageBox.Show("خطا در حذف اطلاعات");

                }
            }
        }
    }
}
