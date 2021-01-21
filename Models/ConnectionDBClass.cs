using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace test4.Models
{
    public class ConnectionDBClass:DbContext
    {
        SqlConnection con;

        public ConnectionDBClass()
        {
            con = new SqlConnection(Startup._configuration.GetConnectionString("DefaultConnection"));
        }
        public ConnectionDBClass(DbContextOptions<ConnectionDBClass> options) : base(options)
        {

        }
        /* public ConnectionDBClass()
         {
         }
         public ConnectionDBClass(DbContextOptions<ConnectionDBClass> options) : base(options)
         {

         }
         SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Survey;Integrated Security=True");
 */
      /*  public int LoginCheck(Ad_Login ad)
        {
            SqlCommand com = new SqlCommand("Srv_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", ad.UserName);
            com.Parameters.AddWithValue("@PassWord", ad.PassWord);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@IsValid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }*/
    }
}
