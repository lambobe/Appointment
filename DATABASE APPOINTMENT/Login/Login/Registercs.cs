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


namespace Login
{
    public partial class Registercs : Form
    {
        public Registercs()
        {
            InitializeComponent();
        }

        private void createe_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Appointment;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[login_new]
           ,[fullname]
           ,[contactNo]
           ,[email]
           ,[homeaddress]
           ,[username]
           ,[pass])
             VALUES
                ('" + Fullname.Text + "','" + ContactNo.Text + "','" + Email.Text + "'," +
                "'" + Address.Text + "','" + usernametxt.Text + "','" + passwordtxt.Text + "')");




            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registered Successfully");
           
        }

    }
}
