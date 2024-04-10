using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customList;

namespace customList.DAL
{
    internal class Connection
    {
        #region Db Connection
        public SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\customList\\Database3.mdf;Integrated Security=True");

        #endregion    
    }
}
