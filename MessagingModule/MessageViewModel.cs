using MessagingModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MessagingModule.ViewModel
{
    public class MessageViewModel //: ViewModelBase
    {
        private ObservableCollection<Message> messageList;
        private Message message;

        //private string testmessage;
        //public string TestMessage { get { return this.testmessage; } set { this.testmessage = value; base.OnPropertyChanged("TestMessage"); } }        

        #region Constructor

        public MessageViewModel()
        {
            //base.DisplayName = "MessageList"; 
            message = new Message();
            messageList = new ObservableCollection<Message>();
        }

        #endregion // Constructor

        public Message Message { get { return this.message; } set { this.message = value; } }//base.OnPropertyChanged("Message") } }

        public ObservableCollection<Message> MessageList { get { return messageList; } set { this.messageList = value; } }
    }
}
