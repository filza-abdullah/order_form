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
    public partial class Expenditure_Type : Form
    {
        public Expenditure_Type()
        {
            InitializeComponent();
        }
        ExpenditureTypedb exdb = new ExpenditureTypedb();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Expenditure_Type_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExpenditureTypedb extdb = new ExpenditureTypedb();
            dataGridView1.DataSource = extdb.selectall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            SqlCommand comd = conn.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "INSERT INTO expenditure_type ( Description, expenditure_name) values ('" + textBox2.Text + "','" +comboBox2.Text + "')";
            comd.ExecuteNonQuery();
            ExpenditureTypedb extdb = new ExpenditureTypedb();
            dataGridView1.DataSource = extdb.selectall();
            conn.Close();
           // textBox5.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            String ids = textBox5.Text;
            int id = int.Parse(ids);
            exdb.delete(id);
            exdb.selectall();
            this.Close();
            Form f = new Expenditure_Type();
            f.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset_layout();
        }
        private void reset_layout()
        {
            textBox5.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                ExpenditureTypedb exdb = new ExpenditureTypedb();
                DataTable dt = exdb.get(id);
                textBox5.Text = dt.Rows[0]["expenditure_type_id"].ToString().Trim();
                comboBox2.Text = dt.Rows[0]["expenditure_name"].ToString().Trim();
                textBox2.Text = dt.Rows[0]["Description"].ToString().Trim();
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
