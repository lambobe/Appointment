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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Appointment;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = usertxt.Text;
            user_password = passtxt.Text;
            try
            {

                String querry = "SELECT * FROM login_new WHERE username = '" + usertxt.Text + "' AND pass = '" + passtxt.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = usertxt.Text;
                    user_password = passtxt.Text;

                    Customer form2 = new Customer();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usertxt.Clear();
                    passtxt.Clear();

                    usertxt.Focus();
                }


            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registercs cr = new Registercs();
            cr.Show();
            this.Hide();
        }
    }
}
