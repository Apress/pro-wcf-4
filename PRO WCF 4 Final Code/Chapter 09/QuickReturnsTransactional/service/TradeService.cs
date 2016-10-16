using System;
using System.Globalization;
using System.ServiceModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;

namespace QuickReturns
{
    // Define the service contract.
    [ServiceContract(Namespace = "QuickReturns")]
    public interface ITradeService
    {
        [OperationContract]
        //Ensure that trasnactions are flowed
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int CalculateTradeValue(int qty, int price);
         
    }

    // Service class which implements the service contract.
    [ServiceBehavior(TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable)]
    public class TradeService : ITradeService
    {
        //Set the transaction scope
        [OperationBehavior(TransactionScopeRequired = true)]
        
        //Calculate the Trade Value
         public int CalculateTradeValue(int qty, int price)
        {
            //Write the trade to the Database
            RecordToTradeLog(String.Format(CultureInfo.CurrentCulture, "Recording Trade ACN Value {0} with Price {1}", qty,price ));
            return qty * price;
        }
        //Record to the DB Persistent Log will also do the DB Transaction
        private static void RecordToTradeLog(string tradeText)
        {
            // Record the trade performed
            if (ConfigurationManager.AppSettings["usingSql"] == "true")
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    conn.Open();

                    SqlCommand cmdLog = new SqlCommand("INSERT into TradeLog (Trade) Values (@Trade)", conn);
                    cmdLog.Parameters.AddWithValue("@Trade", tradeText);
                    cmdLog.ExecuteNonQuery();
                    cmdLog.Dispose();

                    Console.WriteLine("  Logging Trade to database: {0}", tradeText);

                    conn.Close();
                }
            }
            else
                Console.WriteLine("  Noting row: {0}", tradeText);
        }
    }
}