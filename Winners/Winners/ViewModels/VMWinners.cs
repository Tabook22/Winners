using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winners.ViewModels
{
    public class VMWinners
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> g_date { get; set; }
        public string g_name { get; set; }
        public string g_email { get; set; }
        public string g_tel { get; set; }
        public Nullable<int> q_no { get; set; }
        public Nullable<int> q_ans { get; set; }
    }
}