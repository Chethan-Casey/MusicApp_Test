using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MusicApp
{
    public static class sql
    {
        public static DataTable GetDataTable(string Query)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server = FAIMOB011; Database = Testing; Integrated Security = SSPI; ";
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    //var a = cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }

                catch (Exception e)
                {

                }
                finally
                {
                    con.Close();
                }
                return new DataTable();
            }
        }

        public static void Execute(string Query)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server = FAIMOB011; Database = Testing; Integrated Security = SSPI; ";
                try
                {
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (Exception e)
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}