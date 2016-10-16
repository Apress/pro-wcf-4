using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.PeerResolvers;

namespace QuickReturnSecureTraderChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class Main : Form, IQuickReturnTraderChat
    {
        IQuickReturnTraderChat channel;
        ServiceHost host = null;
        ChannelFactory<IQuickReturnTraderChat> channelFactory = null;
        string userID = "";
        string password = null;

        public Main()
        {
            InitializeComponent();
            userID = System.Configuration.ConfigurationManager.AppSettings["userID"];
            password = System.Configuration.ConfigurationManager.AppSettings["password"];
        }


        #region IQuickReturnTraderChat Members

        void IQuickReturnTraderChat.Say(string user, string message)
        {
            textBoxChat.Text += user + " says: " + message;
        }       
        #endregion

        private void StartService()
        {
            //Instantiate new ServiceHost 
            host = new ServiceHost(this);

            //Set the password
            host.Credentials.Peer.MeshPassword = password;

            //Open ServiceHost
            host.Open();
            
            //Create a ChannelFactory and load the configuration setting
            channelFactory = new ChannelFactory<IQuickReturnTraderChat>("QuickTraderChatSecurePasswordEndPoint");
            
            //Set the password for the ChannelFactory
            channelFactory.Credentials.Peer.MeshPassword = password;
            
            //Create the Channel
            channel = channelFactory.CreateChannel();

            //Lets others know that someone new has joined
            channel.Say("Admin", "*** New User " + userID + " Joined ****" + Environment.NewLine);
        }

        private void StopService()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (host != null)
                {
                    channel.Say("", "*** User " + userID + " Leaving ****" + Environment.NewLine);

                    if (host.State != CommunicationState.Closed)
                    {
                        channelFactory.Close();
                        host.Close();
                    }
                }
            }
            catch (Exception)
            {
                //eat the ex.
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                StartService();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string temp = textBoxMessage.Text + Environment.NewLine;

            channel.Say(userID, temp);

            textBoxMessage.Clear();
        }
    }

    [ServiceContract()]
    public interface IQuickReturnTraderChat
    {
        [OperationContract(IsOneWay = true)]
        void Say(string user, string message);
    }
}