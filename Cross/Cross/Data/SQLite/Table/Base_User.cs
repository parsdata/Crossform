﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Data.SQLite.Table
{
    public class Base_User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string UserID { get; set; }

        public string AppID { get; set; }

        public string ActivationCode { get; set; }
    }
}
