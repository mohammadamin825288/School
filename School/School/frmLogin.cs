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
    public partial class frmLogin : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.Focus();

            }else if (string.IsNullOrEmpty(txtPass.Text))
            {
                txtPass.Focus();

            }
            else
            {
                try
                {
                    myconnection.Open();
                    SqlDataAdapter myda = new SqlDataAdapter("select UserPassword,UserType from Users where UserName='" + txtUser.Text + "'", myconnection);
                    DataTable mydt = new DataTable();
                    myda.Fill(mydt);
                    //پسورد

                    string password = mydt.Rows[0].ItemArray[0].ToString();

                    
                   

                    if (txtPass.Text==password)
                    {
                        //مشخص کردن نام در لیبل FRMMAIN
                        ClassName.username = txtUser.Text;

                        SqlCommand mycommand = new SqlCommand("update Users set LoginQTY=LoginQTY+1,LastDate=@LastDate where UserName=@UserName", myconnection);
                        mycommand.Parameters.AddWithValue("@LastDate", ShamsiDate.ConvertToShamsi(DateTime.Now));
                        mycommand.Parameters.AddWithValue("@UserName", txtUser.Text);
                        mycommand.ExecuteNonQuery();
                        myconnection.Close();
                        frmMain mymain = new frmMain();
                        mymain.ShowDialog();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("کلمه عبور اشتباه است");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("نام کاربری نادرست است");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtUser.Focus();
            }
        }
    }
}
