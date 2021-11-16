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
        public static List<Post> getPosts(int idUser)
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
                        IdPost = (int)reader["postId"],
                        IdUser = (int)reader["userId"],
                        CreationDate = DateTime.Parse(reader["creationDate"].ToString()),
                        Title = reader["title"].ToString(),
                        Content = Encoding.ASCII.GetBytes(reader["contentPost"].ToString()),
                        Description = reader["description"].ToString(),
                        Reactions = (int)reader["reactions"],
                        PostType = reader["postType"].ToString()
                    });
                }
                reader.Close();
            }
            return allPosts;
        }

        public static void addPost(Post post)
        {
            using(SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("createPost",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = post.IdUser;
                cmd.Parameters.Add("@creationDate", SqlDbType.Date).Value = post.CreationDate;
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = post.Title;
                cmd.Parameters.Add("@contentPost", SqlDbType.VarBinary).Value = post.Content;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = post.Description;
                cmd.Parameters.Add("@reactions", SqlDbType.Int).Value = post.Reactions;
                cmd.Parameters.Add("@postType", SqlDbType.VarChar).Value = post.PostType;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
