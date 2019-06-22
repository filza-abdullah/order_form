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
    public partial class Expenditures : Form
    {
        public Expenditures()
        {
            InitializeComponent();
        }
        Expendituresdb edb = new Expendituresdb();
        private void Expenditures_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nGOIdatabaseDataSet.expenditure_type' table. You can move, or remove it, as needed.
            this.expenditure_typeTableAdapter.Fill(this.nGOIdatabaseDataSet.expenditure_type);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Expendituresdb edb = new Expendituresdb();
            dataGridView1.DataSource = edb.selectall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand comd = conn.CreateCommand();
                comd.CommandType = CommandType.Text;
                DateTime d = Convert.ToDateTime(dateTimePicker1.Text);
                if (textBox3.Text == "")
                {
                    //MessageBox.Show("I will create new");
                    comd.CommandText = "INSERT INTO Expenditures (expenditure_type_id, Total_amount, Month_date , date_created) values ('" + comboBox2.Text + "','" + textBox1.Text + "','" + monthCalendar1.Text + "','" + d.Year + "-" + d.Month + "-" + d.Day + "')";
                }
                else
                {
                    //MessageBox.Show("I will update");
                    comd.CommandText = "UPDATE Expenditures SET expenditure_type_id='" + comboBox2.Text + "',Total_amount='" + textBox1.Text + "',Month_date='" + monthCalendar1.Text + "',date_created='" + d.Year + "-" + d.Month + "-" + d.Day + "' where expenditure_id=" + textBox3.Text;
                }
                //SqlCommand comd = conn.CreateCommand();
               // comd.CommandType = CommandType.Text;

                comd.ExecuteNonQuery();
                Expendituresdb edb = new Expendituresdb();
                dataGridView1.DataSource = edb.selectall();
                conn.Close();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            reset_layout();
            this.Close();
            Expenditures ex = new Expenditures();
            ex.Show();
        }
        private void reset_layout()
        {
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            monthCalendar1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            SqlCommand comd = conn.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "delete from Expenditures where Expenditures_id= '" + textBox3.Text + "'";
            comd.ExecuteNonQuery();
            //Salesdb sdb = new Salesdb();
            //dataGridView2.DataSource = sdb.selectall();
            conn.Close();
            this.Close();
            Expenditures exp  =new Expenditures();
            exp.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
