using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class Blog
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public string status { get; set; }
        public string create_date { get; set; }
        public string publish_date { get; set; }

    }

    public class UserBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string Mobilenumber { get; set; }

    }
}
