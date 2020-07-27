using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApp
{
    public class DBConnection
    {

        public static string ConnectionString
        {
            get
            {
                return "Data Source=SQL5019.Smarterasp.net;Initial Catalog=selling;User Id =test;Password=test;";
            }
        }
    }
}