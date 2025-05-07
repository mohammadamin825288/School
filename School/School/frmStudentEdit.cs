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
    public partial class frmStudentEdit : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        Boolean mychekCode = false;
        public frmStudentEdit()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmStudentEdit_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentID AS [کد دانش آموز], StudentFname AS [نام], StudentLname AS [نام خانوادگی], StudentClassID AS [کلاس], StudentAddress AS [آدرس] FROM Students ORDER BY StudentID DESC", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                txtStudentID.Focus();
            }
            else if (mychekCode == false)
            {
                txtStudentID.Focus();
                MessageBox.Show("کد دانش آموز نامعتبر است");


            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand mydelete = new SqlCommand("delete from Students where StudentID=@StudentID", myconnection);
                    mydelete.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudentID.Text));
                    mydelete.ExecuteNonQuery();
                    myconnection.Close();

                    MessageBox.Show("اطلاعات دانش آموز حذف گردید");
                    txtStudentFname.Clear();
                    txtStudentLname.Clear();
                    txtStudentPhone.Clear();
                    txtStudentAddress.Clear();
                    txtStudentClassID.Clear();

                    frmStudentEdit_Load(sender, e);
                }
                catch (SqlException)
                {

                    MessageBox.Show("خطا در حذف اطلاعات");

                }
            }
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT   StudentFname, StudentLname , StudentClassID ,StudentPhone,StudentAddress  from Students" +
              " where StudentID='" + Convert.ToInt32(txtStudentID.Text) + "'", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                txtStudentFname.Text = mydt.Rows[0].ItemArray[0].ToString();
                txtStudentLname.Text = mydt.Rows[0].ItemArray[1].ToString();
                txtStudentClassID.Text = mydt.Rows[0].ItemArray[2].ToString();
                txtStudentPhone.Text = mydt.Rows[0].ItemArray[3].ToString();
                txtStudentAddress.Text = mydt.Rows[0].ItemArray[3].ToString();
                mychekCode = true;
            }
            catch (Exception)
            {
                txtStudentFname.Clear();
                txtStudentLname.Clear();
                txtStudentClassID.Clear();
                txtStudentPhone.Clear();
                txtStudentAddress.Clear();
                mychekCode = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!mychekCode)
            {
                MessageBox.Show("کد دانش‌آموز نامعتبر است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStudentFname.Text) ||
                string.IsNullOrWhiteSpace(txtStudentLname.Text) ||
                string.IsNullOrWhiteSpace(txtStudentPhone.Text) ||
                string.IsNullOrWhiteSpace(txtStudentAddress.Text))
            {
                MessageBox.Show("لطفاً تمام اطلاعات را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                myconnection.Open();
                SqlCommand myupdatecommand = new SqlCommand(@"UPDATE Students 
            SET StudentFname = @StudentFname, 
                StudentLname = @StudentLname, 
                StudentClassID = @StudentClassID, 
                StudentAddress = @StudentAddress, 
                StudentPhone = @StudentPhone 
            WHERE StudentID = @StudentID", myconnection);

                myupdatecommand.Parameters.AddWithValue("@StudentFname", txtStudentFname.Text);
                myupdatecommand.Parameters.AddWithValue("@StudentLname", txtStudentLname.Text);
                myupdatecommand.Parameters.AddWithValue("@StudentClassID", txtStudentClassID.Text);
                myupdatecommand.Parameters.AddWithValue("@StudentAddress", txtStudentAddress.Text);
                myupdatecommand.Parameters.AddWithValue("@StudentPhone", txtStudentPhone.Text);
                myupdatecommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudentID.Text));
                myupdatecommand.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStudentEdit_Load(sender, e);
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

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtStudentFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void txtStudentLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtStudentClassID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtStudentPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtStudentAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
    }
}
