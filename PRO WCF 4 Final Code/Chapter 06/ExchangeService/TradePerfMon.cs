using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;

namespace ExchangeService
{
    [ServiceContract(
        Namespace = "http://PracticalWcf/Exchange/TradeService",
        Name = "TradeService")
    ]

    public interface ITradePerfMonService
    {
        [OperationContract]
        double TradeSecurity(string ticker, int quantity);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TradePerfMon : ITradePerfMonService
    {
        private double totalValue = 0;
        private double microsoftVolume = 0;
        private const string CounterCategoryName = "Trade Service PerfMon";
        private const string TotalCounterName = "Trade Total Value";
        private const string MicrosoftCounterName = "Microsoft Trade Volume";
        private PerformanceCounterCategory counterCategory = null;
        private PerformanceCounter totalCounter = null;
        private PerformanceCounter microsoftCounter = null;
        const double IBM_Price = 80.50D;
        const double MSFT_Price = 30.25D;

        public TradePerfMon()
        {
            if (PerformanceCounterCategory.Exists(CounterCategoryName))
            {
                PerformanceCounterCategory.Delete(CounterCategoryName);
            }

            CounterCreationData totalCounter = new CounterCreationData(TotalCounterName, "Total Dollar value of Trade Service transactions.", PerformanceCounterType.NumberOfItemsHEX32);
            CounterCreationData microsoftCounter = new CounterCreationData(MicrosoftCounterName, "Total Microsoft securities being traded", PerformanceCounterType.NumberOfItemsHEX32);
            CounterCreationDataCollection counterCollection = new CounterCreationDataCollection(new CounterCreationData[] { totalCounter, microsoftCounter });


            this.counterCategory = PerformanceCounterCategory.Create(CounterCategoryName, "Trade Service PerfMon Counters", PerformanceCounterCategoryType.MultiInstance, counterCollection);
            totalValue = 0;
            microsoftVolume = 0;
        }

        public void InitializeCounters(System.ServiceModel.Description.ServiceEndpointCollection endpoints)
        {
            List<string> names = new List<string>();
            foreach (ServiceEndpoint endpoint in endpoints)
            {
                names.Add(string.Format("{0}@{1}", this.GetType().Name, endpoint.Address.ToString()));
            }

            while (true)
            {
                try
                {
                    foreach (string name in names)
                    {
                        string condition = string.Format("SELECT * FROM Service WHERE Name=\"{0}\"", name);
                        SelectQuery query = new SelectQuery(condition);
                        ManagementScope managementScope = new ManagementScope(@"\\.\root\ServiceModel", new ConnectionOptions());
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(managementScope, query);
                        ManagementObjectCollection instances = searcher.Get();
                        foreach (ManagementBaseObject instance in instances)
                        {
                            PropertyData data = instance.Properties["CounterInstanceName"];

                            this.totalCounter = new PerformanceCounter(CounterCategoryName, TotalCounterName, data.Value.ToString());
                            this.totalCounter.ReadOnly = false;
                            this.totalCounter.RawValue = 0;
                            this.microsoftCounter = new PerformanceCounter(CounterCategoryName, MicrosoftCounterName, data.Value.ToString());
                            this.microsoftCounter.ReadOnly = false;
                            this.microsoftCounter.RawValue = 0;

                            break;
                        }
                    }
                    break;
                }
                catch (COMException)
                {

                }

            }
            Console.WriteLine("Counters initialized.");
        }


        public double TradeSecurity(string ticker, int quantity)
        {
            double result = 0;
            if (quantity < 1)
                throw new ArgumentException(
                    "Invalid quantity", "quantity");
            switch (ticker.ToLower())
            {
                case "ibm":
                    result = quantity * IBM_Price;
                    totalValue = +result;
                    if (this.totalCounter != null)
                        this.totalCounter.RawValue = (int)totalValue;
                    return result;
                case "msft":
                    result = quantity * IBM_Price;
                    totalValue = +result;
                    microsoftVolume = +quantity;
                    if (this.totalCounter != null)
                        this.totalCounter.RawValue = (int)totalValue;
                    if (this.microsoftCounter != null)
                        this.microsoftCounter.RawValue = (int)microsoftVolume;
                    return result;
                default:
                    throw new ArgumentException(
                        "Don't know - only MSFT & IBM", "ticker");

            }
        }

    }
}