using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using Client.Models;
using Client.ViewModels;
using ServiceLibrary;
using Client.ServiceReference1;

namespace Client.Views
{

    /// <summary>
    /// Interaction logic for LoginP.xaml
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class Chat : Window, IChat
    {
        public Server Server;
        public CallbackService Callback;
        
        public Chat()
        {
            InitializeComponent();

            Callback = new CallbackService();
            Server = new Server(new InstanceContext(Callback));
            StartService();
            
        }

        public Chat(Server server, CallbackService callback)
        {
            InitializeComponent();

            this.Callback = callback;
            this.Server = server;
            StartService();
        }

        IChat channel;
        ServiceHost host = null;
        ChannelFactory<IChat> channelFactory = null;
        string userID = "";

        private void StartService()
        {
            //Instantiate new ServiceHost
            host = new ServiceHost(this);
            //Open ServiceHost
            host.Open();
            //Create a ChannelFactory and load the configuration setting
            channelFactory = new ChannelFactory<IChat>("ChatEndPoint");
            channel = channelFactory.CreateChannel();
            //Lets others know that someone new has joined
            channel.Say("Admin", "*** New User " + userID + " Joined ****" + Environment.NewLine);
        }

        private void StopService()
        {
            if (host != null)
            {
                channel.Say("Admin", "*** User " + userID + " Leaving ****" + Environment.NewLine);
                if (host.State != CommunicationState.Closed)
                {
                    channelFactory.Close();
                    host.Close();
                }
            }
        }

        void IChat.Say(string user, string message)
        {
            this.Text.Text += user + " says: " + message;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string temp = textBoxMessage.Text + Environment.NewLine;
            //Invoke the Service
            channel.Say(userID, temp);
            textBoxMessage.Clear();
        }
    }
}