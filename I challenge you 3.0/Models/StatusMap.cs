using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace I_challenge_you_3._0.Models
{
    static class StatusMap
    {
        private static Dictionary<int, String> statusMap = new Dictionary<int,String>();

        public static List<String> Statuses { 
            get
            {
                List<String> statuses = new List<String>();
                foreach (KeyValuePair<int,String> entry in statusMap)
                {
                    statuses.Add(entry.Value);
                }
                return statuses;
            } 
        }

        public static void addStatus(int id,String status)
        {
            statusMap.Add(id, status);
        }

        public static int getStatusId(String value)
        {
            return statusMap.FirstOrDefault(x => x.Value == value).Key;
        }
    }
}
