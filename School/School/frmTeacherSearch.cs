using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmTeacherSearch : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");

        public frmTeacherSearch()
        {
            InitializeComponent();
        }



        private void frmTeacherSearch_Load(object sender, EventArgs e)
        {
            myconnection.Open();
            SqlDataAdapter myda = new SqlDataAdapter("SELECT TeacherID AS [کد معلم], TeacherFname AS [نام معلم], TeacherLname AS [نام خانوادگی], TeacherSubject AS درس, TeacherAddress AS آدرس , TeacherPhone AS [شماره تماس] FROM  Teachers ", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].Width = 200;
            myconnection.Close();
        }

        private void txtTeacherCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myconnection.Open();
                SqlDataAdapter myda = new SqlDataAdapter("SELECT TeacherID AS [کد معلم], TeacherFname AS [نام معلم], TeacherLname AS [نام خانوادگی], TeacherSubject AS درس, TeacherAddress AS آدرس , TeacherPhone AS [شماره تماس] FROM  Teachers  where TeacherID like '" + txtTeacherCode.Text + "%' ORDER BY TeacherID ASC", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);
                dataGridView1.DataSource = mydt;
                myconnection.Close();
            }
            catch (Exception)
            {


            }
        }

        private void txtTeacherName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myconnection.Open();
                SqlDataAdapter myda = new SqlDataAdapter("SELECT TeacherID AS [کد معلم], TeacherFname AS [نام معلم], TeacherLname AS [نام خانوادگی], TeacherSubject AS درس, TeacherAddress AS آدرس , TeacherPhone AS [شماره تماس] FROM  Teachers  where TeacherLname  like N'" + txtTeacherName.Text + "%' ORDER BY TeacherID ASC", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);
                dataGridView1.DataSource = mydt;
                myconnection.Close();
            }
            catch (Exception)
            {


            }
        }

        private void txtTeacherCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtTeacherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
