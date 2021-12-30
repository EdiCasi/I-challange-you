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
    class MessageDAL
    {
        public static void createMessage(Message message)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("createMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@senderId", SqlDbType.Int).Value = message.Sender.IdUser;
                cmd.Parameters.Add("@receiverId", SqlDbType.Int).Value = message.Receiver.IdUser;
                cmd.Parameters.Add("@text", SqlDbType.VarChar).Value = message.Text;
                cmd.Parameters.Add("@creationDate", SqlDbType.Date).Value = message.CreationDate;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Notification notif = NotificationDAL.GetNotificationByMessageFrom(message.Receiver.IdUser, message.Sender.IdUser);
            if (notif != null)
            {
                notif.Seen = false;
                notif.CreationDate = DateTime.UtcNow;
                NotificationDAL.UpdateMessageNotification(notif);
            }
            else
            {
                notif = new Notification()
                {
                    IdUser = message.Receiver.IdUser,
                    Type = "message",
                    IdPost = null,
                    MessageFrom = message.Sender.IdUser,
                    CreationDate = DateTime.UtcNow,
                    Seen = false
                };
                NotificationDAL.CreateNotification(notif);
            }
        }

        public static List<Message> getMessages(User user1, User user2)
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("getMessages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user1Id", SqlDbType.Int).Value = user1.IdUser;
                cmd.Parameters.Add("@user2Id", SqlDbType.Int).Value = user2.IdUser;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User sender;
                    User receiver;

                    if((int)reader["senderId"] == user1.IdUser)
                    {
                        sender = user1;
                        receiver = user2;
                    }
                    else
                    {
                        sender = user2;
                        receiver = user1;
                    }

                    messages.Add(new Message()
                    {
                        IdMessage = (int)reader["messageId"],
                        Sender = sender,
                        Receiver = receiver,
                        Text = reader["text"].ToString(),
                        CreationDate = DateTime.Parse(reader["creationDate"].ToString())
                    });
                }
                reader.Close();
            }
            return messages;
        }
    }
}
