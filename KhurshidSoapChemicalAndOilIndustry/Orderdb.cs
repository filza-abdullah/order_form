using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhurshidSoapChemicalAndOilIndustry
{
    class Orderdb
    {
        int Product_id;
        public string Product;
        int Quantity;
        int Unit_Price;
        int Sub_total;

        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter sda;
        public DataTable dt;

        public string connectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True";

        public Orderdb()
        {
            conn = new SqlConnection(connectionString);
            comd = new SqlCommand();
            comd.Connection = conn;
            sda = new SqlDataAdapter();
            dt = new DataTable();
            conn.Open();

        }
        public void SqlQuery(string queryText)
        {
            comd = new SqlCommand(queryText, conn);
        }
        public DataTable QueryEx()
        {
            sda = new SqlDataAdapter(comd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable get(int id)
        {
            sda = new SqlDataAdapter("select Poduct_id as ID, Product as Product, Quantity as Quantity, Unit_Price as Unit Price, Sub_total as Sub Total from Order where Product_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable delete(int id)
        {
            sda = new SqlDataAdapter("delete Order where Product_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable selectall()
        {
            sda = new SqlDataAdapter("select * from Order", conn);
            sda.Fill(dt);
            return dt;
        }
    }
}
