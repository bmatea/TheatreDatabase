using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace TheatreDatabase
{
    public class Reservation : Actions
    {
        public override decimal PerformAction(decimal x, int acc, int audit)
        {
            String connectionStr = @"Server =.\SQLEXPRESS; Database = TheatreDatabase; Trusted_Connection = True; MultipleActiveResultSets = True";


            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("Reservation", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Price", x);
            command.Parameters.AddWithValue("@userAccount", acc);
            command.Parameters.AddWithValue("@Auditorium", audit);
            SqlParameter result = command.Parameters.Add("@Result", SqlDbType.Int);

            result.Direction = ParameterDirection.Output;

            int count = command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            return Convert.ToDecimal(result.Value);
        }
    }
}
