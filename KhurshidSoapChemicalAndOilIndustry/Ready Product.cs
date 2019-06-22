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
    public partial class Ready_Product : Form
    {
        public Ready_Product()
        {
            InitializeComponent();

        }
        Ready_productsdb rdb = new Ready_productsdb();
        DataTable dt = new DataTable();
        private void Ready_Product_Load(object sender, EventArgs e)
        {

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Ready_productsdb rdb= new Ready_productsdb();
            dataGridView1.DataSource = rdb.selectall();
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
                if (textBox1.Text == "")
                {
                    //MessageBox.Show("I will create new");
                    Ready_Product r = new Ready_Product();
                    int abc = Int32.Parse(textBox4.Text);
                    int id;
                    //SqlDataAdapter sda = new SqlDataAdapter ( "Select Product_id from Ready_products where product_name=" +comboBox1, conn);
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Ready_Products where Product_name=" + comboBox1, conn);
                    sda.Fill(dt);
                    id = Int32.Parse(dt.Rows[0]["Product_id"].ToString());
                   // r.get(id);
                   // abc = abc + r.Quantity;
                    comd.CommandText = "Update Ready_products SET Quantity='" + abc + "'where Product_id = " + textBox1.Text;
                    this.Close();
                    r.Show();
                }

                else
                {
                    //MessageBox.Show("I will update");
                    comd.CommandText = "UPDATE Ready_products SET Prooduct_name='" + comboBox1.Text + "',Product_packing'" + comboBox2.Text + "',Quantity='" + textBox3.Text + "',Price='" + textBox4.Text + "',date_created='"  + d.Year + "-" + d.Month + "-" + d.Day+ "',Remarks='" + textBox5.Text + "' where Product_id=" + textBox1.Text;
                }
                //comd.CommandText = "INSERT INTO Ready_products (Product_name, Product_packing, Quantity, Price, date_created, Remarks) values ('" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + "')";
                comd.ExecuteNonQuery();
                Ready_productsdb rdb = new Ready_productsdb();
                dataGridView1.DataSource = rdb.selectall();
                conn.Close();
               // Ready_productsdb rdb = new Ready_productsdb;
                rdb.selectall();
            }


            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            reset_layout();
        }
        private void reset_layout()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            reset_layout();
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            rdb.delete(id);
            this.Close();
            Form f = new Ready_Product();
            f.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
              try
                {
                    string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Ready_productsdb rdp = new Ready_productsdb();
                    rdp.get(Int32.Parse(id));
                    
                    comboBox1.Text = rdp.Product_name;
                    comboBox2.Text = rdp.Product_packing;
                    textBox3.Text = rdp.Quantity;
                    textBox4.Text = rdp.Price;
                    dateTimePicker1.Text = rdp.date_created;
                    textBox5.Text = rdp.Remarks;

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            
        }

       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
