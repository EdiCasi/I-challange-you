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
        public static User getUser(String username,String password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter user = new SqlParameter("@username", username);
                SqlParameter pass = new SqlParameter("@password", password);

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(pass);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User()
                    {
                        IdUser = (int)reader["userId"],
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
