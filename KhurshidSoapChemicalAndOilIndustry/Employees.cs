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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        Employeesdb edb = new Employeesdb();

        private void Employees_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Employeesdb edb = new Employeesdb();
            dataGridView1.DataSource = edb.selectall();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand comd = conn.CreateCommand();
                comd.CommandType = CommandType.Text;
                if (textBox2.Text == "")
                {
                    //MessageBox.Show("I will create new");
                    comd.CommandText = "INSERT INTO Employees (Name, father_name, Phone_num, Address, Designation, emp_salary) values ('" + textBox1.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "','" +  textBox5.Text + "')";
                }
                else
                {
                    //MessageBox.Show("I will update");
                    comd.CommandText = "UPDATE Employees SET Name='" + textBox1.Text + "',father_name='" + textBox6.Text + "',Phone_num='" + textBox3.Text + "',Address='" + textBox4.Text  + "',Designation='" + textBox7.Text + "',Emp_salary='" + textBox5.Text + "' where Emp_id=" + textBox2.Text;
                }
                comd.ExecuteNonQuery();
                comd.CommandType = CommandType.Text;
                dataGridView1.DataSource = edb.selectall();
                conn.Close();
            }
            catch (Exception e2)
            {
                //MessageBox.Show(e2.Message);
            }
            reset_layout();
            this.Close();
            Employees a = new Employees();
            a.Show();

        }
        public void reset_layout()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Employeesdb edb = new Employeesdb();
                DataTable dt = edb.get(id);
                textBox2.Text = dt.Rows[0]["ID"].ToString().Trim();
                textBox1.Text = dt.Rows[0]["Name"].ToString().Trim();
                textBox6.Text = dt.Rows[0]["Father Name"].ToString().Trim();
                textBox3.Text = dt.Rows[0]["Phone Number"].ToString().Trim();
                textBox4.Text = dt.Rows[0]["Address"].ToString().Trim();
                textBox7.Text = dt.Rows[0]["Designation"].ToString().Trim();
                textBox5.Text = dt.Rows[0]["Salary"].ToString().Trim();
            }
            catch (Exception e1)
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
            edb.delete(id);
            this.Close();
            Form f = new Employees();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Employeesdb edb = new Employeesdb();
                DataTable dt = edb.get(id);
                textBox2.Text = dt.Rows[0]["Emp_id"].ToString().Trim();
                textBox1.Text = dt.Rows[0]["Name"].ToString().Trim();
                textBox6.Text = dt.Rows[0]["father_name"].ToString().Trim();
                textBox3.Text = dt.Rows[0]["Phone_num"].ToString().Trim();
                textBox4.Text = dt.Rows[0]["Address"].ToString().Trim();
                textBox7.Text = dt.Rows[0]["Designation"].ToString().Trim();
                textBox5.Text = dt.Rows[0]["emp_salary"].ToString().Trim();

            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }
    }
}
