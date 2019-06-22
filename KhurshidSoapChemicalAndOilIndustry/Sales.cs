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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.SelectedValue+"");
            int total;
            String a, b;
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            SqlCommand comd = conn.CreateCommand();
            comd.CommandType = CommandType.Text;
            //int a = int.Parse
           // a = textBox1.Text;
           // b = textBox4.Text;
           // int x = int.Parse(a);
           // int y = int.Parse(b);
            //total = x*y ;
            comd.CommandText = "INSERT INTO Sales (Cus_name, Balance, Remarks) values ('" + comboBox2.SelectedValue.ToString() + "','" + textBox8.Text + "','" + textBox6.Text +  "')";
            comd.ExecuteNonQuery();
            Salesdb sdb = new Salesdb();
            dataGridView2.DataSource = sdb.selectall();
            conn.Close();
            /*textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";*/
            //textBox9.Text = "";
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Salesdb sdb = new Salesdb();
            dataGridView2.DataSource = sdb.selectall();
            customerdb c = new customerdb();
            comboBox2.DataSource = c.getForDropDown();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void DELETE_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            SqlCommand comd = conn.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "delete from sales where Cus_name= '" + comboBox2.Text + "'";
            comd.ExecuteNonQuery();
            Salesdb sdb = new Salesdb();
            dataGridView2.DataSource = sdb.selectall();
            conn.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddProductToOrder form = new AddProductToOrder();
            form.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                Salesdb s = new Salesdb();
                DataTable dt = s.get(id);
                //textBox8.Text = dt.Rows[0]["Sales_id"].ToString().Trim();
                comboBox2.Text = dt.Rows[0]["Cus_name"].ToString().Trim();
                textBox8.Text = dt.Rows[0]["Balance"].ToString().Trim();
                textBox6.Text = dt.Rows[0]["Remarks"].ToString().Trim();
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }
    }
}
