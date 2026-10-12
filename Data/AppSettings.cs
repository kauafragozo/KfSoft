using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KfSoft.EFCore
{
    public static class AppSettings
    {
        public static string GetConnectionString()
        {
            return "Data Source=localhost;Initial Catalog=KfSoftDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
        }
    }
}
