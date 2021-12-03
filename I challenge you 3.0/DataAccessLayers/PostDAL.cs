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
                    Post newPost = new Post()
                    {
                        IdPost = (int)reader["postId"],
                        IdUser = (int)reader["userId"],
                        CreationDate = DateTime.Parse(reader["creationDate"].ToString()),
                        Title = reader["title"].ToString(),
                        Content = (byte[])reader["contentPost"],
                        ContentType = reader["contentType"].ToString(),
                        Description = reader["description"].ToString(),
                        Reactions = (int)reader["reactions"]
                    };

                    if (reader["challengedPerson"] != DBNull.Value)
                    {
                        newPost.ChallengedPerson = (int)reader["challengedPerson"];
                    }
                    else
                    {
                        newPost.ChallengedPerson = null;
                    }


                    allPosts.Add(newPost);
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
                cmd.Parameters.Add("@contentType", SqlDbType.VarChar).Value = post.ContentType;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = post.Description;
                cmd.Parameters.Add("@reactions", SqlDbType.Int).Value = post.Reactions;
                
                if(post.ChallengedPerson != null)
                {
                    cmd.Parameters.Add("@challengedPerson", SqlDbType.VarChar).Value = post.ChallengedPerson;
                }
                else
                {
                    cmd.Parameters.Add("@challengedPerson", SqlDbType.VarChar).Value = DBNull.Value;
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
