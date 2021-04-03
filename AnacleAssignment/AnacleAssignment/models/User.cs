using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnacleAssignment.models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public double temp { get; set; }
        public DateTime date { get; set; }
    }
}
