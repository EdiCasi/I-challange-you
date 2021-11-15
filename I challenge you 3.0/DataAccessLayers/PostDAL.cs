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
    class PostDAL
    {
        public static List<Post> getPost(int idUser)
        {
            List<Post> allPosts = new List<Post>();
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter userId = new SqlParameter("@userId", idUser);

                cmd.Parameters.Add(userId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allPosts.Add(new Post()
                    {
                        CreationDate = reader["creationDate"].ToString(),
                        Title = reader["title"].ToString(),
                        Content = reader["contentPost"].ToString(),
                        Description = reader["description"].ToString(),
                        Reactions = (int)reader["reactions"],
                        PostType = reader["postType"].ToString(),
                    });
                }
                reader.Close();
            }
            return allPosts;
        }

        public static void addPost(int userId, String creationDate, String title, String content, String description, int reactions, String postType)
        {
            using(SqlConnection con = DALHelper.Connection)
            {
                using (SqlCommand queryAddPost = new SqlCommand())
                {
                    queryAddPost.Connection = con;
                    queryAddPost.CommandType = CommandType.Text;
                    queryAddPost.CommandText ="INSERT into dbo.Post (userId, creationDate, title, contentPost, description, reactions, postType) VALUES (@idUser, @postCreationDate, @postTitle, @postContent, @postDescription, @postReactions, @postPostType)";
                    queryAddPost.Parameters.AddWithValue("@idUser", userId);
                    queryAddPost.Parameters.AddWithValue("@postCreationDate", creationDate);
                    queryAddPost.Parameters.AddWithValue("@postTitle", title);
                    queryAddPost.Parameters.AddWithValue("@postContent", content);
                    queryAddPost.Parameters.AddWithValue("@postDescription", description);
                    queryAddPost.Parameters.AddWithValue("@postReactions", reactions);
                    queryAddPost.Parameters.AddWithValue("@postPostType", postType);

                    try
                    {
                        con.Open();
                        int recordsAffected = queryAddPost.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        //error
                    }
                }
            }
        }
    }
}
