using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System;

namespace KhurshidSoapChemicalAndOilIndustry
{
    class Ready_productsdb
    {
        public int Product_id;
        public string Product_name;
        public string Product_packing;
        public string Quantity;
        public string Price;
        public string date_created;
        public string Remarks;
        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter sda;
        public DataTable dt;

        public string connectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True";

        public Ready_productsdb()
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
        public Ready_productsdb get(int id)
        {
            sda = new SqlDataAdapter("select * from Ready_Products where Product_id=" + id,conn);
            sda.Fill(dt);
            id = Int32.Parse(dt.Rows[0]["Product_id"].ToString());
            Product_name = dt.Rows[0]["Product_name"].ToString();
            Product_packing = dt.Rows[0]["Product_packing"].ToString();
            Quantity = dt.Rows[0]["Quantity"].ToString();
            Price = dt.Rows[0]["Price"].ToString();
            date_created = dt.Rows[0]["date_created"].ToString();
            Remarks = dt.Rows[0]["Remarks"].ToString();
            return this;
        }
        public DataTable getForDropDown()
        {
            sda = new SqlDataAdapter("select Product_id as ID, Product_name as Name from Ready_Products", conn);
            sda.Fill(dt);
            return dt;
        }
        public int getPrice(int id)
        {
            sda = new SqlDataAdapter("select Price from Ready_Products where Product_id="+id, conn);
            sda.Fill(dt);
            return System.Int32.Parse(dt.Rows[0]["Price"].ToString());
        }
        public DataTable selectall()
        {
            sda = new SqlDataAdapter("select * from Ready_Products", conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable delete(int id)
        {
            sda = new SqlDataAdapter("delete Ready_Products where Product_id=" + id, conn);
            sda.Fill(dt);
            return dt;
            
        }
       
    }
}
