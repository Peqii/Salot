using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using EmailSender._365;
using Salot.Helpers;
using Salot.Data;

namespace EmailSender
{
    class SQLHandler
    {       
        public SQLHandler()
        {
          
        }

        public static List<Salot.Data.Website> GetWebsites()
        {
            string sqlCommand = "Select * From dbo.Websites";
   
            List<Salot.Data.Website> websiteList = new List<Salot.Data.Website>();
            string connectionString = Properties.Settings1.Default.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand selectRows = new SqlCommand(sqlCommand, conn))
                    {
                        using (SqlDataReader reader = selectRows.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Salot.Data.Website website = new Salot.Data.Website();
                                object[] values = new object[reader.FieldCount];
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    values[i] = reader.GetValue(i);
                                };
                                website = Salot.Helpers.WebsiteHelper.ConverToWebsite(values);
                                websiteList.Add(website);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteToErrorLog(ex.Message, Properties.Settings1.Default.Logdir, Properties.Settings1.Default.LogFile);
                    Console.WriteLine(string.Format("SQL haku epäonnistui: {0}", ex.ToString()));
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }
           
            return websiteList;
        }

        internal static string GetUserEmail(Guid userID)
        {
            string sqlCommand = $@"Select Email From dbo.[User] where ID = '{userID}'";

            string email = string.Empty;
            string connectionString = Properties.Settings1.Default.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand selectRows = new SqlCommand(sqlCommand, conn))
                    {
                        using (SqlDataReader reader = selectRows.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                object[] values = new object[reader.FieldCount];
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    values[i] = reader.GetValue(i);
                                };
                                email = (string)values[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteToErrorLog(ex.Message, Properties.Settings1.Default.Logdir, Properties.Settings1.Default.LogFile);
                    Console.WriteLine(string.Format("SQL haku epäonnistui: {0}", ex.ToString()));
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }

            return email;
        }
        internal static EWSAuthenticationInfo GetExchangeInformation()
        {
            string sqlCommand = $@"Select * From dbo.[ExchangeInformation]";

            EWSAuthenticationInfo eWSAuthenticationInfo = new EWSAuthenticationInfo();
            string connectionString = Properties.Settings1.Default.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand selectRows = new SqlCommand(sqlCommand, conn))
                    {
                        using (SqlDataReader reader = selectRows.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                object[] values = new object[reader.FieldCount];
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    values[i] = reader.GetValue(i);
                                };
                                eWSAuthenticationInfo = OutlookHandler.InitEWSAuthenticationInfo(values);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteToErrorLog(ex.Message, Properties.Settings1.Default.Logdir, Properties.Settings1.Default.LogFile);
                    Console.WriteLine(string.Format("SQL haku epäonnistui: {0}", ex.ToString()));
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }

            return eWSAuthenticationInfo;
        }
    }
}
