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
    public partial class Neelumoil : Form
    {
        public Neelumoil()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new Expenditures();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
              Ready_Product f1 = new Ready_Product();
              f1.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Form f = new Customer();
                f.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                Form f = new Expenditure_Type();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Form f = new Sales();
                f.Show();
            }
        }

           
       

        private void Neelumoil_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new Receipt();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new Reports();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f = new Employees();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Neelumoil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void label7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f = new Orders();
            f.Show();
        }
    }
}
