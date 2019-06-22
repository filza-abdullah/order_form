using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace KhurshidSoapChemicalAndOilIndustry
{
    class Salesdb
    {
        int sales_id;
        int cus_id;
        int Bill_no;
        int product_id;
        int unit_price;
        int quantity;
        int sub_total;
        int Balance;
        string Remarks;
       
        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter sda;
        public DataTable dt;



        public Salesdb()
        {
            conn = new SqlConnection("Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True");
            //conn = new SqlConnection(connectionString);
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
        public DataTable selectall()
        {
            sda = new SqlDataAdapter("select *  from Sales", conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable get(int id)
        {
            sda = new SqlDataAdapter("Select * from Sales where Sales_id = " +  id, conn);
            sda.Fill(dt);
            return dt;
        }

    }
}
