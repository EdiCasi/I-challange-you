using I_challenge_you_3._0.DataAccessLayer;
using I_challenge_you_3._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.DataAccessLayers
{
    class FriendshipDAL
    {
        public static void createFriendship(User user1, User user2)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("createFriendship", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user1Id", SqlDbType.Int).Value = user1.IdUser;
                cmd.Parameters.Add("@user2Id", SqlDbType.Int).Value = user2.IdUser;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void acceptRequest(int userId, int friendId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("acceptRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@friendId", SqlDbType.Int).Value = friendId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void rejectRequest(int userId, int friendId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("rejectRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@friendId", SqlDbType.Int).Value = friendId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
