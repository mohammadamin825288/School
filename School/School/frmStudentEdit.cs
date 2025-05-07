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
        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                ClearFields();
                mychekCode = false;
                return;
            }

            try
            {
                var da = new SqlDataAdapter(
                    "SELECT StudentFname, StudentLname, StudentClass, StudentAddress, StudentPhone FROM Students WHERE StudentID = @id",
                    myconnection);
                da.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(txtStudentID.Text));

                var dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtStudentFname.Text = dt.Rows[0]["StudentFname"].ToString();
                    txtStudentLname.Text = dt.Rows[0]["StudentLname"].ToString();
                    txtStudentClassID.Text = dt.Rows[0]["StudentClass"].ToString();
                    txtStudentAddress.Text = dt.Rows[0]["StudentAddress"].ToString();
                    txtStudentPhone.Text = dt.Rows[0]["StudentPhone"].ToString();
                    mychekCode = true;
                }
                else
                {
                    ClearFields();
                    mychekCode = false;
                }
            }
            catch
            {
                ClearFields();
                mychekCode = false;
            }
        }

        private void ClearFields()
        {
            txtStudentFname.Clear();
            txtStudentLname.Clear();
            txtStudentClassID.Clear();
            txtStudentAddress.Clear();
            txtStudentPhone.Clear();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
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
                StudentClass = @StudentClassID, 
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

    

