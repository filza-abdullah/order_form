using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace KhurshidSoapChemicalAndOilIndustry
{
    class ExpenditureTypedb
    {
        int expenditure_type_id;
        public string expenditure_name;
        string Desciption;
        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter sda;
        public DataTable dt;

        public string connectionString = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=NGOIdatabase;Integrated Security=True";

        public ExpenditureTypedb()
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
        public DataTable selectall()
        {
            sda = new SqlDataAdapter("select * from expenditure_type", conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable delete(int id)
        {
            sda = new SqlDataAdapter("delete expenditure_type where expenditure_type_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable get(int id)
        {
            sda = new SqlDataAdapter("select * from expenditure_type where expenditure_type_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }
        /*public Salesdb get(int id)
        {
            sda = new SqlDataAdapter("Select * from Customers where Cus_id = " + Customer ID, conn);
            sda.Fill(dt);


            Cus_id = Int64.Parse(dt.Rows[0]["Customer ID"].ToString());
            Cus_name = Int64.Parse(dt.Rows[0]["Customer Name"].ToString());
            Cus_phone = Int64.Parse(dt.Rows[0]["Customer Phone"].ToString());
            Date_created = Int64.Parse(dt.Rows[0]["Date Created"].ToString());
            Cus_address = Int64.Parse(dt.Rows[0]["Address"].ToString());


        }*/
    }
}

