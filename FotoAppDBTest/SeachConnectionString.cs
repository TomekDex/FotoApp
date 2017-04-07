using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDBTest
{
    public class SeachConnectionString
    {
        public string connectionString {  get; private set; }
        public SeachConnectionString()
        {
            SqlConnectionStringBuilder aaa = new SqlConnectionStringBuilder();
            aaa.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string[] s = Directory.GetDirectories("../../../FotoAppDB");
            int i = 0;
            do
            {
                if (s[i].EndsWith("FotoAppDB\\DB")) aaa.Add("AttachDbFilename", Path.GetFullPath(s[i]) + "\\FotoApp.mdf");
            }
            while (s[i].EndsWith("FotoAppDB\\DB") && s.Count() > i);
            connectionString= aaa.ConnectionString;
        }
    }
}
