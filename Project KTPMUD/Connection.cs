﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Project_KTPMUD
{
    internal class Connection
    {
        private static string Stringconnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\TGDD\Source\Repos\Quan-ly-ve-sinh-moi-truong-nong-thon\Project KTPMUD\DatabaseDKTK.mdf"";Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(Stringconnection);
        }
    }
}