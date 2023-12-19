using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Login
{
    public partial class Customer : Form
    {
     
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        public Customer()
        {
            InitializeComponent();
    
           
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Appointment;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                DayOfWeek selectedDay = dateTimePicker1.Value.DayOfWeek;
                DateTime selectedDate = dateTimePicker1.Value;
                DateTime currentDate = DateTime.Now;
                if (selectedDate < currentDate)
                {
                    MessageBox.Show("You selected a previous date. Please select another date");

                }




                else if (technician.Text == "Michael Johnson" && selectedDay == DayOfWeek.Saturday)
                {

                    MessageBox.Show("Sorry. Michael is not available on Saturday");


                }
                else if (technician.Text == "Michael Johnson" && selectedDay == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Sorry. Michael is not available on Sunday");


                }
                else if (technician.Text == "Bryan Stoophed" && selectedDay == DayOfWeek.Monday)
                {
                    MessageBox.Show("Sorry. Bryan is not available on Monday");


                }
                else if (technician.Text == "Bryan Stoophed" && selectedDay == DayOfWeek.Tuesday)
                {
                    MessageBox.Show("Sorry. Bryan is not available on Tuesday");



                }
                else if (technician.Text == "Roadri Go Dzutirti" && selectedDay == DayOfWeek.Wednesday)
                {
                    MessageBox.Show("Sorry. Roadri is not available on Wednesday");

                }
                else if (technician.Text == "Roadri Go Dzutirti" && selectedDay == DayOfWeek.Thursday)
                {
                    MessageBox.Show("Sorry. Roadri is not available on Thursday");


                }
                else if (technician.Text == "Jun Weck" && selectedDay == DayOfWeek.Friday)
                {
                    MessageBox.Show("Sorry. Jun is not available on Friday");


                }
                else if (technician.Text == "Jun Weck" && selectedDay == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Sorry. Jun is not available on Saturday");


                }


                else if (cbpayment.SelectedItem == null)
                {
                    MessageBox.Show("Please select a payment method");


                }
                else if (string.IsNullOrEmpty(name.Text))
                {
                    MessageBox.Show("Please type your name ");


                }
                else if (string.IsNullOrEmpty(contact.Text))
                {
                    MessageBox.Show("Please type your contact number ");


                }
                else if (string.IsNullOrEmpty(street.Text))
                {
                    MessageBox.Show("Please type your home address ");


                }
                else if (string.IsNullOrEmpty(street.Text))
                {
                    MessageBox.Show("Please type your email address ");


                }
                else if (technician.SelectedItem == null)
                {
                    MessageBox.Show("Please select a technician");
                }
                else if (cbIssue.SelectedItem == null)
                {
                    MessageBox.Show("Please select type of issue");
                }

                else
                {
                    MessageBox.Show("Successful Appointment!", "Save new appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Customer_Load(sender, e);
                   

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[appointmentform]
           ([AppointmentID]
           ,[fullname]
           ,[contactNo]
           ,[email]
           ,[homeadd]
           ,[issue]
           ,[charge]
           ,[addinfo]
           ,[technician]
           ,[schedule]
           ,[method])
     VALUES
           ('" + custid.Text + "','" + name.Text + "','" + contact.Text + "','" + email.Text + "','" + street.Text + "','" + cbIssue.SelectedItem.ToString() + "','" + serv.Text + "','" + addinfo.Text + "','" + technician.Text + "','" + dateTimePicker1.Value.Date + "','" + cbpayment.Text + "') ", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                 
                   



                    SqlCommand command = new SqlCommand(@"INSERT INTO [dbo].[cash]
                     ([AppointmentID],
                        [cashamount]
                        ,[cashfee]
                        ,[cashchange])
                    VALUES('"+custid.Text+"','" + cashamount.Text + "','" + cashfee.Text + "','" + cashchange.Text + "') ", conn);
                   
                    command.ExecuteNonQuery();
                  
               


                       SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [dbo].[bank]
                        ([AppointmentID],
                        [bankfee]
                      ,[banknumber]
                     ,[bankname])
                     VALUES ('" +custid.Text+"','"+ amounttxt.Text + "','" + accountnum.Text + "','" + paymentname.Text + "') ", conn);
                 
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your appointment was successful!");
                    clearfields();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     
        }
        public void clearfields()
        {
            custid.Clear();
            name.Clear();
            contact.Clear();
            email.Clear();
            street.Clear();
            cashamount.Clear();
            cashchange.Clear();
            cashfee.Clear();
            amounttxt.Clear();
            paymentname.Clear();
            accountnum.Clear();
            addinfo.Clear();
            serv.Clear();

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         

            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE appointmentform set fullname=@fullname, contactNo = @contactNo, email=@email, homeadd=@homeadd,issue=@issue, charge=@charge, addinfo=@addinfo, technician=@technician, schedule=@schedule where AppointmentID = @AppointmentID",conn);
           
            cmd.Parameters.AddWithValue("@AppointmentID", int.Parse(custid.Text));
            cmd.Parameters.AddWithValue("@fullname",name.Text); cmd.Parameters.AddWithValue("@contactNo",int.Parse(contact.Text));
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@homeadd", street.Text);
            cmd.Parameters.AddWithValue("@issue", cbIssue.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@charge", serv.Text);
            cmd.Parameters.AddWithValue("@addinfo", addinfo.Text);
            cmd.Parameters.AddWithValue("@technician", technician.Text);
            cmd.Parameters.AddWithValue("@schedule", dateTimePicker1.Value.Date);
            cmd.ExecuteNonQuery();




            conn.Close();
            MessageBox.Show("Successfully Updated!");
            clearfields();
        }

        private void cbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIssue.Text == "Intermittent Conection/Slow Connection")
            {
                var charge = MessageBox.Show("There is a service charge fee for 500 Pesos for this issue. Would you like to continue?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (charge == DialogResult.Yes)
                {
                    serv.Text = "Php 500.00";
                    cashfee.Text = "500.00";

                    amounttxt.Text = "500.00";

                }
                else
                {
                    this.Hide();
                }
            }


            if (cbIssue.Text == "No Internet Connection/Router/Modem is not turning ON")
            {
                var ch = MessageBox.Show("There is a service charge fee for 300 Pesos for this issue. Would you like to continue?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ch == DialogResult.Yes)
                {
                    serv.Text = "Php 300.00";
                    cashfee.Text = "300.00";

                    amounttxt.Text = "300.00";


                }
                else
                {
                    this.Hide();
                }

            }


            if (cbIssue.Text == "Assembling/Repairing Computer Hardware")
            {
                var cha = MessageBox.Show("There is a service charge fee for 800 Pesos for this issue. Would you like to continue?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cha == DialogResult.Yes)
                {
                    serv.Text = "Php 800.00";
                    cashfee.Text = "800.00";

                    amounttxt.Text = "800.00";

                }
                else
                {
                    this.Hide();
                }
            }

            if (cbIssue.Text == "Excessive Pop-ups/Virus Threats")
            {
                var cha = MessageBox.Show("There is a service charge fee for 1,000 Pesos for this issue. Would you like to continue?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cha == DialogResult.Yes)
                {
                    serv.Text = "Php 1,000.00";
                    cashfee.Text = "1,000.00";

                    amounttxt.Text = "1,000.00";

                }
                else
                {
                    this.Hide();
                }
            }
            if (cbIssue.Text == "Loss Data Recovery")
            {
                var cha = MessageBox.Show("There is a service charge fee for 5,000 Pesos for this issue. Would you like to continue?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cha == DialogResult.Yes)
                {
                    serv.Text = "Php 5,000.00";
                    cashfee.Text = "5,000.00";

                    amounttxt.Text = "5,000.00";

                }
                else
                {
                    this.Hide();
                }
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE appointmentform where AppointmentID = @AppointmentID", conn);
            SqlCommand cmd1 = new SqlCommand("DELETE bank where AppointmentID = @AppointmentId", conn);

            cmd1.Parameters.AddWithValue("@AppointmentId", int.Parse(custid.Text));
            cmd.Parameters.AddWithValue("@AppointmentID", int.Parse(custid.Text));
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
          
            conn.Close();
            MessageBox.Show("Appointment Deleted","Successful",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            clearfields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            custid.Text = dataGridView1[0, e.ColumnIndex].Value.ToString();
            name.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            contact.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            email.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            street.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            cbIssue.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            serv.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            addinfo.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            technician.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            dateTimePicker1.Text = dataGridView1[9, e.RowIndex].Value.ToString();
            cbpayment.Text = dataGridView1[10, e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }
        private int GetLastAppointmentIdFromDatabase()
        {
            int lastAppointmentId = 0;

            string query = "SELECT MAX(AppointmentID) FROM AppointmentForm";

           
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        lastAppointmentId = Convert.ToInt32(result);
                    }
                }

                conn.Close();
            }

            return lastAppointmentId;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            int lastAppointmentId = GetLastAppointmentIdFromDatabase();
            int newAppointmentId = lastAppointmentId + 1; 

            custid.Text = newAppointmentId.ToString();
            gridview_data();
            gridview_data2();
            gridview_data3();


        }
        public void gridview_data()
        {
            string query = "SELECT * FROM appointmentform"; // Replace "YourTable" with the actual table name

            dataAdapter = new SqlDataAdapter(query, conn);
            dataSet = new DataSet();

       
            dataAdapter.Fill(dataSet, "appointmentform");
            conn.Close();

            dataGridView1.DataSource = dataSet.Tables["appointmentform"];
       
        }
        public void gridview_data2()
        {
        
            string query = "SELECT * FROM cash"; 

            dataAdapter = new SqlDataAdapter(query, conn);
         
            dataSet = new DataSet();

            conn.Open();
            dataAdapter.Fill(dataSet, "cash");
      
            conn.Close();

            dataGridView2.DataSource = dataSet.Tables["cash"];

        }
        public void gridview_data3()
        {
            string query = "SELECT * FROM bank"; 

            dataAdapter = new SqlDataAdapter(query, conn);
            dataSet = new DataSet();

            conn.Open();
            dataAdapter.Fill(dataSet, "bank");
            conn.Close();

            dataGridView3.DataSource = dataSet.Tables["bank"];

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            gridview_data();
           gridview_data2();
            gridview_data3();
            
        }

        private void cbpayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbpayment.Text == "BDO")
            {

                paymentpanel.Visible = true;

                cashpanel.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;





            }
            else if (cbpayment.Text == "PAYMAYA")
            {
                paymentpanel.Visible = true;

                cashpanel.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;



            }
            else if (cbpayment.Text == "GCASH")
            {

                paymentpanel.Visible = true;
                cashpanel.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;



            }
            else if (cbpayment.Text == "CASH")
            {

                cashpanel.Visible = true;
                paymentpanel.Visible = false;
                dataGridView2.Visible = true;
                dataGridView3.Visible = false;



            }
            else
            {
                MessageBox.Show("Please select a payment method");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cashamount.Text = dataGridView2[0, e.ColumnIndex].Value.ToString();
            cashamount.Text = dataGridView2[1, e.ColumnIndex].Value.ToString();
            cashfee.Text = dataGridView2[2, e.ColumnIndex].Value.ToString();
            cashchange.Text = dataGridView2[3, e.ColumnIndex].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {




                double total = Convert.ToDouble(cashfee.Text);
                double payment = Convert.ToDouble(cashamount.Text);



                if (total >= payment)
                {
                    MessageBox.Show("Not enough amount of money");
                }
                else
                {


                    cashchange.Text = (payment - total).ToString("N2");
                    Customer_Load(sender, e);
                    MessageBox.Show("Your payment was successful!");


                }

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            amounttxt.Text = dataGridView3[0, e.ColumnIndex].Value.ToString();
            accountnum.Text = dataGridView3[1, e.ColumnIndex].Value.ToString();
            paymentname.Text = dataGridView3[2, e.ColumnIndex].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Your payment was successful!");
        }
    }
    }

