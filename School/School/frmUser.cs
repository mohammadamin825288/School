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
    public partial class frmUser : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            SqlDataAdapter myda = new SqlDataAdapter("SELECT Users.UserName AS [نام کاربری], Users.LoginQTY AS [تعداد ورود], Users.LastDate AS [تاریخ آخرین ورود] FROM   Users  ", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
           dataGridView1.DataSource = mydt;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();

            }
            else if (string.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                txtRepeatPassword.Focus();

            }
            else
            {
                if (txtRepeatPassword.Text==txtPassword.Text)
                {
                    try
                    {

                        myconnection.Open();
                        SqlCommand mycommand = new SqlCommand("INSERT INTO Users(UserName,UserPassword,LoginQTY)VALUES(@UserName, @UserPassword,@LoginQTY)", myconnection);
                        mycommand.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        mycommand.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
                      
                        mycommand.Parameters.AddWithValue("@LoginQTY", 0);
                        mycommand.ExecuteNonQuery();
                        myconnection.Close();

                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtRepeatPassword.Clear();
                        txtUsername.Focus();
                        MessageBox.Show("کاربر جدید با موفقیت ثبت گردید ");

                        frmUser_Load(sender, e);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("نام تکراری وارد شده است");
                    }
                }
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                //MessageBox.Show("کاربر '" + txtUsername.Text + "' حذف گردید.", "توجه",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning ) ;
                myconnection.Open();
                SqlCommand mydelete = new SqlCommand("delete from Users where UserName=@UserName ", myconnection);
                mydelete.Parameters.AddWithValue("@UserName",txtUsername.Text);
                mydelete.ExecuteNonQuery();
                myconnection.Close();

                MessageBox.Show("اطلاعات مشتری حذف گردید");
                txtUsername.Clear();
                frmUser_Load(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
