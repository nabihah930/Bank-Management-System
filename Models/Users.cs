using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace k181297_k180326.Models
{
    public class Users
    {
        public string user_id { get; set; }
        public string CNIC { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string account_num { get; set; }
        public float current_balance { get; set; }
    }
}