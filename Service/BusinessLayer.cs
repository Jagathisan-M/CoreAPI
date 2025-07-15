using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest.Service
{
    public class BusinessLayer
    {
        public int input = 10;

        public void Add(int a = 10, int b = 10)
        {
            Add(a: 11);
        }

        public void sub(int b, int a = 10) {
            sub(10);
       }

        public void GetData()
        {
            SqlConnection connection = new SqlConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand("", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(new System.Data.DataSet());

            cmd.ExecuteNonQuery();

            cmd.ExecuteScalar();

            DataSet objset = new DataSet();

            foreach (DataTable tableitem in objset.Tables)
            {
                foreach (DataRow item in tableitem.Rows)
                {

                }
            }

            objset.Tables[0].AsEnumerable().Select(x => new { aa = x[""] }).ToList();

        }
    }
}
