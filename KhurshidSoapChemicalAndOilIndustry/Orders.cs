using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhurshidSoapChemicalAndOilIndustry
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Orderdb odb = new Orderdb();
            dataGridView1.DataSource = odb.selectall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //*private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{

        //try
        //{
        // int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        // customerdb c = new customerdb();
        // DataTable dt = c.get(id);
        // textBox1.Text = dt.Rows[0]["ID"].ToString().Trim();
        //   textBox2.Text = dt.Rows[0]["Name"].ToString().Trim();
        //     textBox3.Text = dt.Rows[0]["Phone"].ToString().Trim();
        //       textBox5.Text = dt.Rows[0]["Address"].ToString().Trim();
        //     }
        //     catch (Exception e1)
        //       {
        //MessageBox.Show(e1.Message);
        //       }
        //
    }//*
    }
//}
