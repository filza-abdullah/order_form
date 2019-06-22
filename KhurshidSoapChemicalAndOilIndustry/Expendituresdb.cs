using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace KhurshidSoapChemicalAndOilIndustry
{
    class Expendituresdb
    {
        int Expenditures_id;
        int expenditure_type_id;
        int Total_amount;
        int Month_date;
        int date_created;
        public SqlConnection conn;
        public SqlCommand comd;
        public SqlDataAdapter sda;
        public DataTable dt;



        public Expendituresdb()
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
            sda = new SqlDataAdapter("select *  from Expenditures", conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable delete(int id)
        {
            sda = new SqlDataAdapter("delete Expenditures where Expenditures_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }
        public DataTable get(int id)
        {
            sda = new SqlDataAdapter("select * from Expenditures where Expenditure_id=" + id, conn);
            sda.Fill(dt);
            return dt;
        }





        /*public Salesdb get(int id)
        {
            sda = new SqlDataAdapter("Select * from Expenditures where Expenditure_id = " +  id, conn);
            sda.Fill(dt);


            id = Int32.Parse(dt.Rows[0]["Expenditures_id"].ToString());
            expenditure_type_id = Int64.Parse(dt.Rows[0]["expenditure_type_id"].ToString());
            Total_amount = Int64.Parse(dt.Rows[0]["Total_amount"].ToString());
            Month_date = Int64.Parse(dt.Rows[0]["Month_date"].ToString());
            date_created = Int64.Parse(dt.Rows[0]["date_created"].ToString());
            return this;


        }*/
    }
}
