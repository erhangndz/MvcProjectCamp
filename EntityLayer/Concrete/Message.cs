using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Subject  { get; set; }
        
        public string Content  { get; set; }
        
        public DateTime Date  { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public bool IsRead { get; set; }
    }
}
