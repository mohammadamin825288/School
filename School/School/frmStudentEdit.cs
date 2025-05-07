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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmStudentEdit_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentID AS [کد دانش آموز], StudentFname AS [نام], StudentLname AS [نام خانوادگی], StudentClassID AS [کلاس], StudentAddress AS [آدرس] FROM Students ORDER BY StudentID DESC", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
        }
        private void txtStudentCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentFname, StudentLname, StudentClass, StudentAddress, StudentPhone FROM Students WHERE StudentID='" + Convert.ToInt32(txtStudentID.Text) + "'", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);

                txtStudentFname.Text = mydt.Rows[0].ItemArray[0].ToString();
                txtStudentLname.Text = mydt.Rows[0].ItemArray[1].ToString();
                txtStudentClassID.Text = mydt.Rows[0].ItemArray[2].ToString();
                txtStudentAddress.Text = mydt.Rows[0].ItemArray[3].ToString();
                txtStudentPhone.Text = mydt.Rows[0].ItemArray[4].ToString();
            }
            catch (Exception)
            {
                txtStudentFname.Clear();
                txtStudentLname.Clear();
                txtStudentClassID.Clear();
                txtStudentAddress.Clear();
                txtStudentPhone.Clear();
                mychekCode = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (mychekCode == false)
            {
                txtStudentID.Focus();
                MessageBox.Show("کد دانش آموز نامعتبر است");
            }
            else if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                txtStudentID.Focus();
            }
            else if (string.IsNullOrEmpty(txtStudentFname.Text))
            {
                txtStudentFname.Focus();
            }
            else if (string.IsNullOrEmpty(txtStudentLname.Text))
            {
                txtStudentLname.Focus();
            }
            else if (string.IsNullOrEmpty(txtStudentPhone.Text))
            {
                txtStudentPhone.Focus();
            }
            else if (string.IsNullOrEmpty(txtStudentAddress.Text))
            {
                txtStudentAddress.Focus();
            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlCommand myupdatecommand = new SqlCommand("UPDATE Students SET StudentFname = @StudentFname, StudentLname = @StudentLname, StudentClass = @StudentClassID, StudentAddress = @StudentAddress, StudentPhone = @StudentPhone WHERE (StudentID = @StudentID)", myconnection);
                    myupdatecommand.Parameters.AddWithValue("@StudentFname", txtStudentFname.Text);
                    myupdatecommand.Parameters.AddWithValue("@StudentLname", txtStudentLname.Text);
                    myupdatecommand.Parameters.AddWithValue("@StudentClassID", txtStudentClassID.Text);
                    myupdatecommand.Parameters.AddWithValue("@StudentAddress", txtStudentAddress.Text);
                    myupdatecommand.Parameters.AddWithValue("@StudentPhone", txtStudentPhone.Text);
                    myupdatecommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudentID.Text));
                    myupdatecommand.ExecuteNonQuery();
                    myconnection.Close();
                    frmStudentEdit_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا: " + ex.Message);
                }
            }
        }
                private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("لطفاً کد دانش‌آموز را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentID.Focus();
                return;
            }

            DialogResult result = MessageBox.Show("آیا از حذف این دانش‌آموز مطمئن هستید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    myconnection.Open();
                    SqlCommand mydeletecommand = new SqlCommand("DELETE FROM Students WHERE StudentID = @StudentID", myconnection);
                    mydeletecommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(txtStudentID.Text));
                    int rowsAffected = mydeletecommand.ExecuteNonQuery();
                    myconnection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("دانش‌آموز با موفقیت حذف شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmStudentEdit_Load(sender, e); // به‌روزرسانی گرید
                    }
                    else
                    {
                        MessageBox.Show("دانش‌آموزی با این کد یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
        }

    

