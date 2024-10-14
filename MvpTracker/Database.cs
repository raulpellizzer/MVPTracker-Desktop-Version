using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MvpTracker
{
    public class Database
    {
        public Database()
        {
            DatabaseName = ConfigurationManager.AppSettings["database"];
            ServerName = ConfigurationManager.AppSettings["server"];
            ConnectionString = $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True";
        }

        private string ServerName { get; set; }
        private string DatabaseName { get; set; }
        private string ConnectionString { get; set; }
        private SqlConnection Conn { get; set; }

        /*
         * Opens connection to SQL server
         * 
         */
        public void OpenSqlConnection() 
        {
            try
            {
                Conn = new SqlConnection(ConnectionString);
                Conn.Open();
            }
            catch (Exception ex)
            {
                Conn = null;
                MessageBox.Show($"An error has occured in OpenSqlConnection: {ex.Message}");
            }
        }

        /*
         * Closes connection to SQL server
         * 
         */
        public void CloseSqlConnection()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in CloseSqlConnection: {ex.Message}");
            }
        }

        /*
         * Sets MVP as killed in MvpTracking table
         * 
         */
        public void RegisterMvpAsKilled(Mvp mvp)
        {
            OpenSqlConnection();
            int mvpId = GetMvpId(mvp.Name);
            int mvpKilledCount = GetMvpKilledCount(mvpId);

            string updateQuery = $"UPDATE MvpTracking SET killed_time = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', next_respawn_time= '{mvp.RespawnDate}', is_mvp_dead = 1, killed_count = {++mvpKilledCount} ";
            updateQuery += $"WHERE id = {mvpId}";

            try
            {
                SqlCommand command = new SqlCommand(updateQuery, Conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in RegisterMvpAsKilled: {ex.Message}");
            }
            
            CloseSqlConnection();
        }

        /*
         * Sets MVP as alive in MvpTracking table (whenever they spawn)
         * 
         */
        public void RegisterMvpAsAlive(List<Mvp> mvps, CultureInfo cultureInfo)
        {
            string updateQuery = "";
            OpenSqlConnection();

            try
            {
                foreach (var mvp in mvps)
                {
                    if (DateTime.Now > Convert.ToDateTime(mvp.RespawnDate)) // if MVP has spawned, update it to alive
                    {
                        updateQuery = $"UPDATE MvpTracking SET killed_time = NULL, next_respawn_time= NULL, is_mvp_dead = 0 ";
                        updateQuery += $"WHERE id = {mvp.Id}";

                        SqlCommand command = new SqlCommand(updateQuery, Conn);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in RegisterMvpAsAlive: {ex.Message}");
            }

            CloseSqlConnection();
        }

        public int GetMvpId(string mvpName)
        {
            int mvpId = -1;
            try
            {
                SqlCommand command = new SqlCommand($"SELECT id FROM Mvp WHERE name = '{mvpName}'", Conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mvpId = Convert.ToInt32(reader["id"]);
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in GetMvpId: {ex.Message}");
            }

            return mvpId;
        }

        public int GetMvpKilledCount(int mvpId)
        {
            int mvpKilledCount = -1;
            try
            {
                SqlCommand command = new SqlCommand($"SELECT killed_count FROM MvpTracking WHERE id = '{mvpId}'", Conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mvpKilledCount = Convert.ToInt32(reader["killed_count"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in GetMvpKilledCount: {ex.Message}");
            }

            return mvpKilledCount;
        }

        /*
         * Returns the list of all MVPs for the specific need
         * 
         */
        public List<Mvp> GetMvpList(string mvp_status)
        {
            OpenSqlConnection();
            List<Mvp> mvpsKilled = new List<Mvp>();
            SqlCommand command = null;
            string sqlQuery = "";

            try
            {
                if (mvp_status == "dead")
                {
                    sqlQuery = "SELECT m.name, mt.id, mt.killed_time, mt.next_respawn_time FROM MvpTracking as mt ";
                    sqlQuery += "INNER JOIN Mvp as m on mt.id = m.id ";
                    sqlQuery += "WHERE is_mvp_dead = 1";
                    command = new SqlCommand(sqlQuery, Conn);
                }
                else if (mvp_status == "alive")
                {
                    sqlQuery = "SELECT m.name, mt.id, mt.killed_time, mt.next_respawn_time FROM MvpTracking as mt ";
                    sqlQuery += "INNER JOIN Mvp as m on mt.id = m.id ";
                    sqlQuery += "WHERE is_mvp_dead = 0";
                    command = new SqlCommand(sqlQuery, Conn);
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mvpsKilled.Add(new Mvp()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            KilledTime = reader["killed_time"].ToString(),
                            RespawnDate = reader["next_respawn_time"].ToString(),
                            buttonControl = null // THINK OF HOW TO LINK BUTTON HERE!
                        });
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured in GetMvpList: {ex.Message}");
            }

            CloseSqlConnection();
            return mvpsKilled;
        }


    }
}
