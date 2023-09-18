using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace k181297_k180326.Models
{
    public class Transfers
    {
        public string user_id { get; set; }
        public string account_from { get; set; }
        public string account_to { get; set; }
        public float amount_transfered { get; set; }
        public string transfer_id { get; set; }
    }
}