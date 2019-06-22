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

namespace KhurshidSoapChemicalAndOilIndustry
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        customerdb cdb = new customerdb();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            try { 
            SqlCommand comd = conn.CreateCommand();
            comd.CommandType = CommandType.Text;
            DateTime d = Convert.ToDateTime(dateTimePicker1.Text);
                if (textBox1.Text == "")
                {
                    //MessageBox.Show("I will create new");
                    comd.CommandText = "INSERT INTO Customers (Cus_name, Cus_phone, Date_created, Cus_address) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + d.Year + "-" + d.Month + "-" + d.Day + "','" + textBox5.Text + "')";
                }
                else
                {
                    //MessageBox.Show("I will update");
                    comd.CommandText = "UPDATE Customers SET Cus_name='" + textBox2.Text + "',Cus_Phone='" + textBox3.Text + "',Cus_address='" + textBox5.Text + "',date_created='" + d.Year + "-" + d.Month + "-" + d.Day + "' where Cus_id=" + textBox1.Text;
                }
            comd.ExecuteNonQuery();
            
            dataGridView1.DataSource = cdb.selectall();
            conn.Close();

            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            reset_layout();
            this.Close();
            Customer a = new Customer();
            a.Show();


        }
        private void reset_layout()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerdb cdb = new customerdb();
            dataGridView1.DataSource = cdb.selectall();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id=(int)dataGridView1.SelectedRows[0].Cells[0].Value;
                customerdb c = new customerdb();
                DataTable dt= c.get(id);
                textBox1.Text = dt.Rows[0]["ID"].ToString().Trim();
                textBox2.Text = dt.Rows[0]["Name"].ToString().Trim();
                textBox3.Text = dt.Rows[0]["Phone"].ToString().Trim();
                textBox5.Text = dt.Rows[0]["Address"].ToString().Trim();
            }
            catch(Exception e1)
            {
               //MessageBox.Show(e1.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset_layout();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            cdb.delete(id);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
