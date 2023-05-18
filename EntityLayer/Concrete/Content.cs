using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        public int ContentID { get; set; }
        public string ContentText { get; set; }
        public bool ContentStatus { get; set; }
        public DateTime ContentDate { get; set; }

        //related class 
        public int HeaderID { get; set; }
        public virtual Header Header { get; set; }

        //related class
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
