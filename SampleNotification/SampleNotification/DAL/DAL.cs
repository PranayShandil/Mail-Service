using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace SampleNotification
{
    class Dal
    {

        DataSet l_DataSetResult;
        readonly SqlConnection l_objSqlConnection;
        public Dal()
        {
            l_objSqlConnection = new SqlConnection(Constants.ConnectionString);
        }

        public List<ChannelDetails> GetChannels()
        {
            List<ChannelDetails> ChannelDetailsList = new List<ChannelDetails>();
            ChannelDetails channeldetails;
            l_DataSetResult = new DataSet();
            try
            {
                //SqlDataAdapter sda = new SqlDataAdapter(CreateQuery(), l_objSqlConnection);
                //sda.Fill(l_DataSetResult);
                //if (l_DataSetResult.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow channelDataRow in l_DataSetResult.Tables[0].Rows)
                //    {
                //        channeldetails = new ChannelDetails();
                //        channeldetails.ChannelName = Convert.ToString(channelDataRow["ChannelName"]);
                //        channeldetails.Status = Convert.ToString(channelDataRow["Status"]);
                //        ChannelDetailsList.Add(channeldetails);
                //    }
                //}
                channeldetails = new ChannelDetails();
                channeldetails.ChannelName = "Test";
                channeldetails.Status = "Failed";
                ChannelDetailsList.Add(channeldetails);
                return ChannelDetailsList;
            }
            catch (Exception ex)
            {
                LogData errorLog = new LogData();
                errorLog.WriteToLog("\r\nError Description : " + ex.ToString());
                errorLog.WriteToEventLog(ex.ToString(), "Dal", System.Diagnostics.EventLogEntryType.Error);
                return null;
            }
        }

        private string CreateQuery()
        {
            //can have a stored procedure. But if database change permission is not available then sql query
            string query = "select ChannelName, Status from ChannelDetails where Status='Failed' or Status='Stopped'";
            return query;
        }

    }
}
