using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace MessagingModule.Model
{
    public enum Priority { Low, High, Medium}

    public class Message
    {      
        //Constructor
        public Message()
        {           
        }

        public String Description { get; set;}
        //public int Line { get; set; }
        //public int Column { get; set; }
        public Priority Priority { get; set; }  

    }
}
