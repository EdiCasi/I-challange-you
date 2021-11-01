using I_challenge_you_3._0.DataAccessLayer;
using I_challenge_you_3._0.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.DataAccessLayers
{
    class UserDAL
    {
        public static User getUser()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User()
                    {
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                    };
                }
                reader.Close();

            }
            return null;
        }

    }
}
