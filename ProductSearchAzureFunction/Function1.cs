using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace ProductSearchAzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string PName = req.Query["PName"];



            string SResult="Error";
            //connection string

            string strConnection = "Server=citizen.manukautech.info,6305;Database=FSNWCommon_2021;UID=FS_NW_Q1;PWD=fBit@12345;encrypt=true;trustservercertificate=true;";

            try
            {
                //create SQL connection
                using (SqlConnection SQLConn = new SqlConnection(strConnection))
                {
                    //open SQL connection
                    SQLConn.Open();

                    //Define querry for search
                    var sqlQuery = "Select * from Products where ProductName Like '" + PName + "%'";

                    var sqlCommand = new SqlCommand(sqlQuery,SQLConn);

                    //close connection if it is already open
                    if(sqlCommand.Connection.State==System.Data.ConnectionState.Open)
                    {
                        sqlCommand.Connection.Close();
                    }
                    sqlCommand.Connection.Open();// open connection for executing sql search
                    SqlDataReader SQLReader = sqlCommand.ExecuteReader(); //data should be arriving here


                    var dtProducts = new DataTable();
                    dtProducts.Load(SQLReader);
                    //load data into dataset

                    SResult=JsonConvert.SerializeObject(dtProducts);

                }

            }
            catch(Exception e)
            {
                SResult = e.Message;
            }


            return SResult;
        }
    }
}
