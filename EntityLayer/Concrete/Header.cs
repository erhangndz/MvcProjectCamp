using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Concrete
{
    public class Header
    {
        public int HeaderID { get; set; }

        public string HeaderName { get; set; }
        public bool HeaderStatus { get; set; }
     
        public DateTime HeaderDate { get; set; }

        //Related class
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //included into
        public ICollection<Content> Contents { get; set;}

        //Related class
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}



