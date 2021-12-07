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
    class ReactionDAL
    {
        public static void addReaction(int IdUser, int IdPost, string reactionType)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("addReaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = IdUser;
                cmd.Parameters.Add("@postId", SqlDbType.VarChar).Value = IdPost;
                cmd.Parameters.Add("@reactionType", SqlDbType.VarChar).Value = reactionType;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static Int32 getNumberOfReactions(int postID, string reactionType)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getNumberOfReactions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter PostID = new SqlParameter("@postId", postID);
                SqlParameter ReactionType = new SqlParameter("@reactionType", reactionType);

                cmd.Parameters.Add(PostID);
                cmd.Parameters.Add(ReactionType);
                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static Int32 verifyUserReaction(int userId, int postId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("verifyUserReaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter UserId = new SqlParameter("@userId", userId);
                SqlParameter PostId = new SqlParameter("@postId", postId);

                cmd.Parameters.Add(UserId);
                cmd.Parameters.Add(PostId);
                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static void modifyUserReaction(int userId, int postId, string reactionType)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("modifyUserReaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("@postId", SqlDbType.VarChar).Value = postId;
                cmd.Parameters.Add("@reactionType", SqlDbType.VarChar).Value = reactionType;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
