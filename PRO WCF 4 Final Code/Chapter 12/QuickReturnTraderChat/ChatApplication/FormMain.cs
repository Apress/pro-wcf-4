using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;

namespace QuickReturnTraderChat
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public partial class FormMain : Form, IQuickReturnTraderChat
    {
        IQuickReturnTraderChat channel;
        ServiceHost host = null;
        ChannelFactory<IQuickReturnTraderChat> channelFactory = null;
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            StartService();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopService();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            channel.Say("Amit", richTextBoxMessage.Text);
        }

        #region IQuickReturnTraderChat Members

        void IQuickReturnTraderChat.Say(string user, string message)
        {
            //throw new Exception("The method or operation is not implemented.");
            string temp = "[" + user + "]:" + message + Environment.NewLine;

            richTextBoxChat.Text = message;
        }

        #endregion


        
        private void StartService()
        {
            //Consider putting the baseAddress in the configuration system
            //and getting it here with AppSettings
            //Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
            //binding = new NetPeerTcpBinding("Binding1");

            //Instantiate new ServiceHost 
            //host = new ServiceHost(this, baseAddress);
            host = new ServiceHost(typeof(QuickReturnTraderChat.FormMain));

            //host.AddServiceEndpoint(typeof(IQuickReturnTraderChat), binding, baseAddress);
            
            //Open myServiceHost
            host.Open();

            channelFactory = new ChannelFactory<IQuickReturnTraderChat>("QuickTraderChatEndpoint");
            channel = channelFactory.CreateChannel();
        }

        private  void StopService()
        {
            //Call StopService from your shutdown logic (i.e. dispose method)
            if (host.State != CommunicationState.Closed)
                host.Close();
        }

    }

    //[ServiceContract]
    //public interface IQuickReturnTraderChat
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void Say(string user, string message);
    //}

}