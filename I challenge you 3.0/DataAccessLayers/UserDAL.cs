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
                        IdUser=Int32.Parse(reader["userId"].ToString()),
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status=reader["statusName"].ToString()
                    };
                }
                reader.Close();

            }
            return null;
        }

        public static void changeUsername(int userId, String username)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("changeUsername", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter user = new SqlParameter("@username", username);
                SqlParameter id = new SqlParameter("@userId", userId);

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public static void changeEmail(int userId, String email)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("changeEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter mail = new SqlParameter("@email", email);
                SqlParameter id = new SqlParameter("@userId", userId);

                cmd.Parameters.Add(mail);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public static void changePassword(int userId, String password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("changePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pass = new SqlParameter("@password", password);
                SqlParameter id = new SqlParameter("@userId", userId);

                cmd.Parameters.Add(pass);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public static void changeStatus(int userId, int statusId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ChangeStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter status = new SqlParameter("@statusId", statusId);
                SqlParameter id = new SqlParameter("@userId", userId);

                cmd.Parameters.Add(status);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
