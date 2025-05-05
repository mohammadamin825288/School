using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School
{
    public partial class frmSearchStudent : Form
    {
        SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=Madrese;Integrated Security=True");

        public frmSearchStudent()
        {
            InitializeComponent();
        }

        private void frmSearchStudent_Load(object sender, EventArgs e)
        {
            myconnection.Open();
            SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentID AS [کد دانش آموز], StudentFname AS [نام دانش آموز], StudentLname AS [نام خانوادگی], StudentPhone AS تلفن, StudentAddress AS آدرس , StudentClassID AS [کد کلاس ] FROM  Students", myconnection);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            dataGridView1.DataSource = mydt;
            myconnection.Close();
        }

        private void txtStudentCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myconnection.Open();
                SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentID AS [کد دانش آموز], StudentFname AS [نام دانش آموز], StudentLname AS [نام خانوادگی], StudentPhone AS تلفن, StudentAddress AS آدرس , StudentClassID AS [کد کلاس ] FROM Students where StudentID like '" + txtStudentCode.Text + "%' ORDER BY StudentID ASC", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);
                dataGridView1.DataSource = mydt;
                myconnection.Close();
            }
            catch (Exception)
            {


            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myconnection.Open();
                SqlDataAdapter myda = new SqlDataAdapter("SELECT StudentID AS [کد دانش آموز], StudentFname AS [نام دانش آموز], StudentLname AS [نام خانوادگی], StudentPhone AS تلفن, StudentAddress AS آدرس , StudentClassID AS [کد کلاس ] from Students  where StudentLname like '" + txtStudentName.Text + "%' ORDER BY StudentID ASC", myconnection);
                DataTable mydt = new DataTable();
                myda.Fill(mydt);
                dataGridView1.DataSource = mydt;
                myconnection.Close();
            }
            catch (Exception)
            {


            }
        }
    }
}
