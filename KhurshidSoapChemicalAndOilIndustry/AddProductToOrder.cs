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
    public partial class AddProductToOrder : Form
    {
        public AddProductToOrder()
        {
            InitializeComponent();
            Ready_productsdb r = new Ready_productsdb();
            comboBox1.DataSource = r.getForDropDown();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }
        Orderdb odb = new Orderdb();
        private void AddProductToOrder_Load(object sender, EventArgs e)
        {
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Orderdb odb = new Orderdb();
            //dataGridView1.DataSource = odb.selectall();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ready_productsdb r = new Ready_productsdb();
            DataRowView dvr = (DataRowView)comboBox1.SelectedItem;
            textBox2.Text= r.getPrice((int)dvr.Row["ID"])+"";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
            textBox5.Text = Int32.Parse(textBox2.Text) * Int32.Parse(textBox1.Text)+"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SqlConnection conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand comd = conn.CreateCommand();
                comd.CommandType = CommandType.Text;

                if (textBox3.Text == "")
                {
                    //MessageBox.Show("I will create new");
                    comd.CommandText = "INSERT INTO Order (Product, Quantity, Unit_Price, Sub_total) values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "')";
                }
                else
                {
                    //MessageBox.Show("I will update");
                    comd.CommandText = "UPDATE Order SET Product='" + comboBox1.Text + "',Quantity='" + textBox1.Text + "',Unit_price='" + textBox2.Text + "',Sub_total='" + textBox5 + "' where Product_id=" + textBox3.Text;
                }
                comd.ExecuteNonQuery();
                //          dataGridView1.DataSource = odb.selectall();
                conn.Close();

            }
            catch (Exception e2)
            {
                //MessageBox.Show(e2.Message);
            }
            reset_layout();
            this.Close();
            Orders o = new Orders();
            o.Show();


        }
        

      
        private void reset_layout()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

        }

    }
    }
    
