using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace QuickReturn
{
    [DataContract]
    public class StockQuote
    {
        public StockQuote(string ticker)
        {
            Random rnd = new Random();
            int deltaTrade = rnd.Next(300);

            switch (ticker)
            {
                case "MSFT":
                    symbol = ticker;
                    companyName = "Microsoft";
                    lastTrade = 35.0M + deltaTrade;
                    //change = 10.0M + deltaChange;
                    //avgVol = 100000.0M;
                    //marketCap = 25000000;
                    //peRatio = 3.5M;
                    //eps = 4.0M;
                    //fiftyTwoWeekHigh = 100.0M;
                    //fiftyTwoWeekLow = 10.0M;
                    break;
                case "IBM":
                    symbol = ticker;
                    companyName = "IBM";
                    lastTrade = 34.0M + deltaTrade;
                    //change = 9.0M + deltaChange;
                    //avgVol = 90000.0M;
                    //marketCap = 24000000;
                    //peRatio = 3.3M;
                    //eps = 3.8M;
                    //fiftyTwoWeekHigh = 90.0M;
                    //fiftyTwoWeekLow = 15.0M;
                    break;
                case "INTU":
                    symbol = ticker;
                    companyName = "Intuit";
                    lastTrade = 33.0M + deltaTrade;
                    //change = 8.0M + deltaChange;
                    //avgVol = 80000.0M;
                    //marketCap = 23000000;
                    //peRatio = 3.1M;
                    //eps = 3.6M;
                    //fiftyTwoWeekHigh = 80.0M;
                    //fiftyTwoWeekLow = 20.0M;
                    break;
                case "GOOG":
                    symbol = ticker;
                    companyName = "Google";
                    lastTrade = 32.0M + deltaTrade;
                    //change = 7.0M + deltaChange;
                    //avgVol = 70000.0M;
                    //marketCap = 22000000;
                    //peRatio = 2.9M;
                    //eps = 3.3M;
                    //fiftyTwoWeekHigh = 70.0M;
                    //fiftyTwoWeekLow = 25.0M;
                    break;
            }
        }

        private string symbol;

        [DataMember(Name = "TickerSymbol")]
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        private string companyName;

        [DataMember]
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }


        private decimal lastTrade;

        [DataMember]
        public decimal LastTrade
        {
            get { return lastTrade; }
            set { lastTrade = value; }
        }


        private decimal change;

        [DataMember]
        public decimal Change
        {
            get { return change; }
            set { change = value; }
        }


        private decimal previousClose;

        [DataMember]
        public decimal PreviousClose
        {
            get { return previousClose; }
            set { previousClose = value; }
        }


        private decimal avgVol;

        [DataMember(Name = "AverageVolume")]
        public decimal AvgVol
        {
            get { return avgVol; }
            set { avgVol = value; }
        }

        private double marketCap;

        [DataMember(Name = "MarketCapital")]
        public double MarketCap
        {
            get { return marketCap; }
            set { marketCap = value; }
        }


        private decimal peRatio;

        [DataMember(Name = "PriceEarningRatio")]
        public decimal PERatio
        {
            get { return peRatio; }
            set { peRatio = value; }
        }


        private decimal eps;

        [DataMember(Name = "EarningsPerShare")]
        public decimal EPS
        {
            get { return eps; }
            set { eps = value; }
        }


        private decimal fiftyTwoWeekHigh;

        [DataMember(Name = "52WkHigh")]
        public decimal FiftyTwoWeekHigh
        {
            get { return fiftyTwoWeekHigh; }
            set { fiftyTwoWeekHigh = value; }
        }


        private decimal fiftyTwoWeekLow;

        [DataMember(Name = "52WkLow")]
        public decimal FiftyTwoWeekLow
        {
            get { return fiftyTwoWeekLow; }
            set { fiftyTwoWeekLow = value; }
        }
    }
}
