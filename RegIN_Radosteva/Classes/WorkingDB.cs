using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;

namespace RegIN_Radosteva.Classes
{
    public class WorkingDB
    {
        readonly static string connection = "server=localhost;port=3306;database=pr21;user=root;pwd=;";
        public static MySqlConnection OpenConnection() 
        {
            try 
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connection);
                mySqlConnection.Open();
                return mySqlConnection;
            } 
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection mySqlConnection) 
        {
            MySqlCommand mySqlCommand = new MySqlCommand(SQL, mySqlConnection);
            return mySqlCommand.ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection mySqlConnection) 
        {
            mySqlConnection.Close();
            MySqlConnection.ClearPool(mySqlConnection);
        }
        public static bool OpenConnection(MySqlConnection mySqlConnection) 
        {
            return mySqlConnection != null && mySqlConnection.State == System.Data.ConnectionState.Open;
        }
    }
}
