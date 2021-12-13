using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayer;
using I_challenge_you_3._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ? 
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) : 
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    return new User()
                    {
                        IdUser = (int)reader["userId"],
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src
                    };
                }
                reader.Close();

            }
            return null;
        }
      
      public static User getUserById(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUserById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter userId = new SqlParameter("@userId", id);

                cmd.Parameters.Add(userId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ?
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) :
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    return new User()
                    {
                        IdUser = (int)reader["userId"],
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src
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

        public static void createUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("createUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user.Username;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.Email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Pass;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static Int32 verifyEmail(String email)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("verifyEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Email = new SqlParameter("@email", email);

                cmd.Parameters.Add(Email);
                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        
        public static List<User> searchUsers(String username)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("searchUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user = new SqlParameter("@username", username);
                cmd.Parameters.Add(user);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> foundUsers = new List<User>();
                while (reader.Read())
                {
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ?
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) :
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    User foudUser = new User()
                    {
                        IdUser = (int)reader["userId"],
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src
                    };

                    foundUsers.Add(foudUser);
                }

                reader.Close();
                return foundUsers;
            }
        }

        public static List<User> getCertainFriends(String searchedName, int loggedUserId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getCertainFriends", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@friendName", searchedName);
                SqlParameter userId = new SqlParameter("@loggedUserId", loggedUserId);
                cmd.Parameters.Add(userId);
                cmd.Parameters.Add(username);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> foundUsers = new List<User>();
                while (reader.Read())
                {
                    int friendId = (int)reader["friend1Id"] == loggedUserId ? (int)reader["friend2Id"] : (int)reader["friend1Id"];
                    User foudUser = new User()
                    {
                        IdUser = friendId,
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusId"].ToString()
                    };

                    foundUsers.Add(foudUser);
                }

                reader.Close();
                return foundUsers;
            }
        }

        public static List<User> getUserFriends(int userId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getUserFriends", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userIdParameter = new SqlParameter("@userId", userId);
                cmd.Parameters.Add(userIdParameter);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> foundUsers = new List<User>();
                while (reader.Read())
                {
                    int friendId = (int)reader["friend1Id"] == userId ? (int)reader["friend2Id"] : (int)reader["friend1Id"];
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ?
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) :
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    User foudUser = new User()
                    {
                        IdUser = friendId,
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src
                    };

                    foundUsers.Add(foudUser);
                }

                reader.Close();
                return foundUsers;
            }
        }

        public static void changeUserImage(int userId, byte[] imageBytes)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("changeProfilePicture", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter image = new SqlParameter("@image", imageBytes);
                SqlParameter id = new SqlParameter("@userId", userId);

                cmd.Parameters.Add(image);
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<User> getUserPendingFriends(int userId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getPendingFriends", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userIdParameter = new SqlParameter("@userId", userId);
                cmd.Parameters.Add(userIdParameter);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> foundUsers = new List<User>();
                while (reader.Read())
                {
                    int friendId = (int)reader["friend1Id"] == userId ? (int)reader["friend2Id"] : (int)reader["friend1Id"];
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ?
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) :
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    User foudUser = new User()
                    {
                        IdUser = friendId,
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src,
                    };

                    foundUsers.Add(foudUser);
                }

                reader.Close();
                return foundUsers;
            }
        }
    public static List<User> getUserOutboundRequests(int userId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getOutBoundRequests", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userIdParameter = new SqlParameter("@userId", userId);
                cmd.Parameters.Add(userIdParameter);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<User> foundUsers = new List<User>();
                while (reader.Read())
                {
                    int friendId = (int)reader["friend1Id"] == userId ? (int)reader["friend2Id"] : (int)reader["friend1Id"];
                    ImageSource src = DBNull.Value.Equals(reader["userImage"]) ?
                        new BitmapImage(new Uri("pack://application:,,,/Resources/Images/Default Image.png", UriKind.Absolute)) :
                        ByteImageConverter.ConvertByteArrayToImageSource((byte[])reader["userImage"]);
                    User foudUser = new User()
                    {
                        IdUser = friendId,
                        Email = reader["email"].ToString(),
                        Username = reader["username"].ToString(),
                        Status = reader["statusName"].ToString(),
                        Image = src,
                    };

                    foundUsers.Add(foudUser);
                }

                reader.Close();
                return foundUsers;
            }
        }
    }
}